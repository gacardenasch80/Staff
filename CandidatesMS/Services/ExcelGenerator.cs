using System;
using System.IO;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight.Drawing;
using System.Collections.Generic;

namespace CandidatesMS.Services
{
    public interface IExcelGenerator
    {
        Task<MemoryStream> CreateCheckDocumentReportExcelByHTML(Candidate candidate, int companyUserId);
    }

    public class ExcelGenerator : IExcelGenerator
    {
        private readonly IBasicInformationRepository _basicInformationRepository;
        private readonly ICandidateCompanyRepository _candidateCompanyRepository;
        private readonly IDocumentCheckRepository _documentCheckRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public ExcelGenerator(IBasicInformationRepository basicInformationRepository,
                            ICandidateCompanyRepository candidateCompanyRepository,
                            IDocumentCheckRepository documentCheckRepository,
                            IDocumentTypeRepository documentTypeRepository)
        {
            _basicInformationRepository = basicInformationRepository;
            _candidateCompanyRepository = candidateCompanyRepository;
            _documentCheckRepository = documentCheckRepository;
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<MemoryStream> CreateCheckDocumentReportExcelByHTML(Candidate candidate, int companyUserId)
        {
            BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidate.CandidateId);

            CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidate.CandidateId, companyUserId);

            List<DocumentCheck> documentChecks = await _documentCheckRepository.GetAllByCandidateId(candidate.CandidateId, companyUserId);

            string others = string.Empty;

            if (basicInformation == null)
                basicInformation = new BasicInformation();

            if (candidateCompany == null)
                candidateCompany = new CandidateCompany();

            if (documentChecks == null)
                documentChecks = new List<DocumentCheck>();

            List<string> checksDocuments = new List<string>();

            if (documentChecks != null && documentChecks.Count > 0)
            {
                foreach (DocumentCheck documentCheck in documentChecks)
                {
                    string check = documentCheck.IsCheck ? "X" : " ";

                    if (documentCheck.OrderId > 20)
                        checksDocuments.Add(check);

                    if (!string.IsNullOrEmpty(documentCheck.Text))
                        others = documentCheck.Text;
                }
            }

            string candidateName = string.Empty;
            string candidateDocument = string.Empty;
            string candidatePhone = string.Empty;

            if (!string.IsNullOrEmpty(basicInformation.Name))
                candidateName = basicInformation.Name;
            if (!string.IsNullOrEmpty(basicInformation.Surname))
                candidateName += " " + basicInformation.Surname;

            int documentTypeId = basicInformation.DocumentTypeId != null ? (int)basicInformation.DocumentTypeId : 0;

            DocumentType documentType = await _documentTypeRepository.GetById(documentTypeId);

            if (basicInformation != null && documentType != null)
            {
                if (documentType.DocumentTypeId == 4 && !string.IsNullOrEmpty(basicInformation.OtherDocument))
                    candidateDocument = basicInformation.OtherDocument;
                else
                    candidateDocument = documentType.Initials;
            }
            else
                candidateDocument = "";

            if (!string.IsNullOrEmpty(basicInformation.Document))
                candidateDocument += ": " + basicInformation.Document;
            if (string.IsNullOrEmpty(candidateDocument) && !string.IsNullOrEmpty(candidateCompany.Document))
            {
                int documentTypeCompanyId = 0;

                if (candidateCompany.DocumentTypeId != null)
                    documentTypeCompanyId = (int)candidateCompany.DocumentTypeId;

                DocumentType documentTypeCompany = await _documentTypeRepository.GetById(documentTypeCompanyId);

                candidateDocument = documentTypeCompany.Initials + ": " + candidateCompany.Document;
            }

            List<string> phones = new List<string>();

            if (!string.IsNullOrEmpty(basicInformation.Phone))
                phones.Add(basicInformation.Phone);
            if (!string.IsNullOrEmpty(basicInformation.Cellphone))
                phones.Add(basicInformation.Cellphone);
            
            if (basicInformation.Phones != null && basicInformation.Phones.Count > 0)
            {
                foreach (Phone phone in basicInformation.Phones)
                {
                    if (phone.CompanyUserId == companyUserId && !string.IsNullOrEmpty(phone.Number))
                    {
                        phones.Add(phone.Number);
                    }
                }
            }

            if (phones != null && phones.Count > 0)
            {
                for(int i = 0; i < phones.Count; i++)
                {
                    candidatePhone += phones[i];

                    if (i != phones.Count - 1)
                        candidatePhone += " - ";
                }
            }

            /**/

            SLDocument document = new SLDocument();

            document.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Listado de Verificacion");

            SLStyle lightBlueCell = document.CreateStyle();
            lightBlueCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            lightBlueCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            lightBlueCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#E5FAFF"), System.Drawing.ColorTranslator.FromHtml("#E5FAFF"));
            lightBlueCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#0B2E65"));
            lightBlueCell.Border.Outline = true;
            lightBlueCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            lightBlueCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            lightBlueCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            lightBlueCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            lightBlueCell.Font.FontSize = 10;
            lightBlueCell.SetFontBold(true);
            lightBlueCell.SetWrapText(true);

            SLStyle lightBlueCellNoBorder = document.CreateStyle();
            lightBlueCellNoBorder.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            lightBlueCellNoBorder.Alignment.Vertical = VerticalAlignmentValues.Center;
            lightBlueCellNoBorder.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#E5FAFF"), System.Drawing.ColorTranslator.FromHtml("#E5FAFF"));
            lightBlueCellNoBorder.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#0B2E65"));
            lightBlueCellNoBorder.Border.Outline = true;
            lightBlueCellNoBorder.Font.FontSize = 10;
            lightBlueCellNoBorder.SetFontBold(true);
            lightBlueCellNoBorder.SetWrapText(true);

            SLStyle whiteCell = document.CreateStyle();
            whiteCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            whiteCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#0B2E65"));
            whiteCell.Border.Outline = true;
            whiteCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteCell.Font.FontSize = 10;
            whiteCell.SetWrapText(true);

            SLStyle whiteCellNoBorder = document.CreateStyle();
            whiteCellNoBorder.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            whiteCellNoBorder.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteCellNoBorder.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteCellNoBorder.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#0B2E65"));
            whiteCellNoBorder.Border.Outline = true;
            whiteCellNoBorder.Font.FontSize = 10;
            whiteCellNoBorder.SetWrapText(true);

            SLStyle whiteGrayCell = document.CreateStyle();
            whiteGrayCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            whiteGrayCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteGrayCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteGrayCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#888888"));
            whiteGrayCell.Border.Outline = true;
            whiteGrayCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteGrayCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteGrayCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteGrayCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteGrayCell.Font.FontSize = 10;
            whiteGrayCell.SetWrapText(true);

            SLStyle whiteBlackCell = document.CreateStyle();
            whiteBlackCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            whiteBlackCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteBlackCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteBlackCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCell.Border.Outline = true;
            whiteBlackCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCell.Font.FontSize = 10;
            whiteBlackCell.SetWrapText(true);

            SLStyle whiteBlackCellLeft = document.CreateStyle();
            whiteBlackCellLeft.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            whiteBlackCellLeft.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteBlackCellLeft.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteBlackCellLeft.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCellLeft.Border.Outline = true;
            whiteBlackCellLeft.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCellLeft.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCellLeft.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCellLeft.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackCellLeft.Font.FontSize = 10;
            whiteBlackCellLeft.SetWrapText(true);

            SLStyle whiteBlackBoldCell = document.CreateStyle();
            whiteBlackBoldCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            whiteBlackBoldCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteBlackBoldCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteBlackBoldCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldCell.SetFontBold(true);
            whiteBlackBoldCell.Border.Outline = true;
            whiteBlackBoldCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldCell.Font.FontSize = 10;
            whiteBlackBoldCell.SetWrapText(true);

            SLStyle whiteBlackBoldLeftCell = document.CreateStyle();
            whiteBlackBoldLeftCell.Alignment.Horizontal = HorizontalAlignmentValues.Left;
            whiteBlackBoldLeftCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            whiteBlackBoldLeftCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#FFFFFF"), System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            whiteBlackBoldLeftCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldLeftCell.SetFontBold(true);
            whiteBlackBoldLeftCell.Border.Outline = true;
            whiteBlackBoldLeftCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldLeftCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldLeftCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldLeftCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            whiteBlackBoldLeftCell.Font.FontSize = 10;
            whiteBlackBoldLeftCell.SetWrapText(true);

            SLStyle darkBlueCell = document.CreateStyle();
            darkBlueCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            darkBlueCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            darkBlueCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#002E64"), System.Drawing.ColorTranslator.FromHtml("#002E64"));
            darkBlueCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            darkBlueCell.Border.Outline = true;
            darkBlueCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            darkBlueCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            darkBlueCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            darkBlueCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            darkBlueCell.Font.FontSize = 10;
            darkBlueCell.SetWrapText(true);

            SLStyle mediumBlueCell = document.CreateStyle();
            mediumBlueCell.Alignment.Horizontal = HorizontalAlignmentValues.Center;
            mediumBlueCell.Alignment.Vertical = VerticalAlignmentValues.Center;
            mediumBlueCell.Fill.
                SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml("#00AEEF"), System.Drawing.ColorTranslator.FromHtml("#00AEEF"));
            mediumBlueCell.SetFontColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
            mediumBlueCell.Border.Outline = true;
            mediumBlueCell.Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            mediumBlueCell.Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            mediumBlueCell.Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            mediumBlueCell.Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.ColorTranslator.FromHtml("#000000"));
            mediumBlueCell.Font.FontSize = 10;
            lightBlueCell.SetWrapText(true);

            document.RenameWorksheet(SLDocument.DefaultFirstSheetName, "Listado de Verificacion Documentos de Ingreso");

            document.MergeWorksheetCells("A1", "A4");
            document.SetCellStyle("A1", whiteCellNoBorder);
            document.SetCellStyle("A2", whiteCellNoBorder);
            document.SetCellStyle("A3", whiteCellNoBorder);
            document.SetCellStyle("A4", whiteCellNoBorder);

            document.SetCellValue("B1", "Listado de Verificación de Documentos de Ingreso");
            document.MergeWorksheetCells("B1", "D4");
            document.SetCellStyle("B1", lightBlueCellNoBorder);
            document.SetCellStyle("B2", lightBlueCellNoBorder);
            document.SetCellStyle("B3", lightBlueCellNoBorder);
            document.SetCellStyle("B4", lightBlueCellNoBorder);
            document.SetCellStyle("C1", lightBlueCellNoBorder);
            document.SetCellStyle("C2", lightBlueCellNoBorder);
            document.SetCellStyle("C3", lightBlueCellNoBorder);
            document.SetCellStyle("C4", lightBlueCellNoBorder);
            document.SetCellStyle("D1", lightBlueCellNoBorder);
            document.SetCellStyle("D2", lightBlueCellNoBorder);
            document.SetCellStyle("D3", lightBlueCellNoBorder);
            document.SetCellStyle("D4", lightBlueCellNoBorder);

            document.SetCellValue("E1", "Fecha de emisión");
            document.SetCellStyle("E1", whiteCellNoBorder);

            document.SetCellValue("F1", "Clasificación");
            document.SetCellStyle("F1", whiteCellNoBorder);

            document.SetCellValue("E2", "26-02-2020");
            document.SetCellStyle("E2", lightBlueCellNoBorder);

            document.SetCellValue("F2", "Clasificado");
            document.SetCellStyle("F2", lightBlueCellNoBorder);

            document.SetCellValue("E3", "Revisión No");
            document.SetCellStyle("E3", whiteCellNoBorder);

            document.SetCellValue("F3", "Página");
            document.SetCellStyle("F3", whiteCellNoBorder);

            document.SetCellValue("E4", "01");
            document.SetCellStyle("E4", lightBlueCellNoBorder);

            document.SetCellValue("F4", "1 de 1");
            document.SetCellStyle("F4", lightBlueCellNoBorder);

            document.MergeWorksheetCells("A5", "F5");

            document.SetCellValue("A6", "DATOS PERSONALES");
            document.MergeWorksheetCells("A6", "F6");
            document.SetCellStyle("A6", darkBlueCell);
            document.SetCellStyle("B6", darkBlueCell);
            document.SetCellStyle("C6", darkBlueCell);
            document.SetCellStyle("D6", darkBlueCell);
            document.SetCellStyle("E6", darkBlueCell);
            document.SetCellStyle("F6", darkBlueCell);

            document.SetCellValue("A7", "Foto");
            document.MergeWorksheetCells("A7", "A10");
            document.SetCellStyle("A7", whiteGrayCell);
            document.SetCellStyle("A8", whiteGrayCell);
            document.SetCellStyle("A9", whiteGrayCell);
            document.SetCellStyle("A10", whiteGrayCell);

            document.SetCellValue("B7", "NOMBRES Y APELLIDOS:");
            document.MergeWorksheetCells("B7", "C7");
            document.SetCellStyle("B7", whiteBlackBoldLeftCell);
            document.SetCellStyle("C7", whiteBlackBoldLeftCell);

            document.SetCellValue("B8", "CÉDULA:");
            document.MergeWorksheetCells("B8", "C8");
            document.SetCellStyle("B8", whiteBlackBoldLeftCell);
            document.SetCellStyle("C8", whiteBlackBoldLeftCell);

            document.SetCellValue("B9", "TELÉFONO DE CONTACTO:");
            document.MergeWorksheetCells("B9", "C9");
            document.SetCellStyle("B9", whiteBlackBoldLeftCell);
            document.SetCellStyle("C9", whiteBlackBoldLeftCell);

            document.SetCellValue("B10", "CARGO:");
            document.MergeWorksheetCells("B10", "C10");
            document.SetCellStyle("B10", whiteBlackBoldLeftCell);
            document.SetCellStyle("C10", whiteBlackBoldLeftCell);

            document.SetCellValue("D7", candidateName);
            document.MergeWorksheetCells("D7", "F7");
            document.SetCellStyle("D7", whiteBlackCell);
            document.SetCellStyle("E7", whiteBlackCell);
            document.SetCellStyle("F7", whiteBlackCell);

            document.SetCellValue("D8", candidateDocument);
            document.MergeWorksheetCells("D8", "F8");
            document.SetCellStyle("D8", whiteBlackCell);
            document.SetCellStyle("E8", whiteBlackCell);
            document.SetCellStyle("F8", whiteBlackCell);

            document.SetCellValue("D9", candidatePhone);
            document.MergeWorksheetCells("D9", "F9");
            document.SetCellStyle("D9", whiteBlackCell);
            document.SetCellStyle("E9", whiteBlackCell);
            document.SetCellStyle("F9", whiteBlackCell);

            document.SetCellValue("D10", "");
            document.MergeWorksheetCells("D10", "F10");
            document.SetCellStyle("D10", whiteBlackCell);
            document.SetCellStyle("E10", whiteBlackCell);
            document.SetCellStyle("F10", whiteBlackCell);

            document.MergeWorksheetCells("A11", "F11");

            document.SetCellValue("A12", "DOCUMENTOS PROCEDIMIENTO CONTRATACIÓN");
            document.MergeWorksheetCells("A12", "F12");
            document.SetCellStyle("A12", darkBlueCell);
            document.SetCellStyle("B12", darkBlueCell);
            document.SetCellStyle("C12", darkBlueCell);
            document.SetCellStyle("D12", darkBlueCell);
            document.SetCellStyle("E12", darkBlueCell);
            document.SetCellStyle("F12", darkBlueCell);

            document.SetCellValue("A13", "1. VINCULACIÓN");
            document.MergeWorksheetCells("A13", "E13");
            document.SetCellStyle("A13", mediumBlueCell);
            document.SetCellStyle("B13", mediumBlueCell);
            document.SetCellStyle("C13", mediumBlueCell);
            document.SetCellStyle("D13", mediumBlueCell);
            document.SetCellStyle("E13", mediumBlueCell);

            document.SetCellValue("F13", "CHECK");
            document.SetCellStyle("F13", mediumBlueCell);

            document.SetCellValue("A14", "Contrato y anexos");
            document.MergeWorksheetCells("A14", "E14");
            document.SetCellStyle("A14", whiteBlackCellLeft);
            document.SetCellStyle("B14", whiteBlackCellLeft);
            document.SetCellStyle("C14", whiteBlackCellLeft);
            document.SetCellStyle("D14", whiteBlackCellLeft);
            document.SetCellStyle("E14", whiteBlackCellLeft);

            document.SetCellValue("A15", "Especificaciones del cargo");
            document.MergeWorksheetCells("A15", "E15");
            document.SetCellStyle("A15", whiteBlackCellLeft);
            document.SetCellStyle("B15", whiteBlackCellLeft);
            document.SetCellStyle("C15", whiteBlackCellLeft);
            document.SetCellStyle("D15", whiteBlackCellLeft);
            document.SetCellStyle("E15", whiteBlackCellLeft);

            document.SetCellValue("A16", "Cláusulas (Seguridad en la información, Habeas Data)");
            document.MergeWorksheetCells("A16", "E16");
            document.SetCellStyle("A16", whiteBlackCellLeft);
            document.SetCellStyle("B16", whiteBlackCellLeft);
            document.SetCellStyle("C16", whiteBlackCellLeft);
            document.SetCellStyle("D16", whiteBlackCellLeft);
            document.SetCellStyle("E16", whiteBlackCellLeft);

            document.SetCellValue("A17", "Perfil sociodemográfico y responsabilidades de SG-SST");
            document.MergeWorksheetCells("A17", "E17");
            document.SetCellStyle("A17", whiteBlackCellLeft);
            document.SetCellStyle("B17", whiteBlackCellLeft);
            document.SetCellStyle("C17", whiteBlackCellLeft);
            document.SetCellStyle("D17", whiteBlackCellLeft);
            document.SetCellStyle("E17", whiteBlackCellLeft);

            document.SetCellValue("A18", "Soporte afiliación ARL");
            document.MergeWorksheetCells("A18", "E18");
            document.SetCellStyle("A18", whiteBlackCellLeft);
            document.SetCellStyle("B18", whiteBlackCellLeft);
            document.SetCellStyle("C18", whiteBlackCellLeft);
            document.SetCellStyle("D18", whiteBlackCellLeft);
            document.SetCellStyle("E18", whiteBlackCellLeft);

            document.SetCellValue("A19", "Soporte afiliación EPS");
            document.MergeWorksheetCells("A19", "E19");
            document.SetCellStyle("A19", whiteBlackCellLeft);
            document.SetCellStyle("B19", whiteBlackCellLeft);
            document.SetCellStyle("C19", whiteBlackCellLeft);
            document.SetCellStyle("D19", whiteBlackCellLeft);
            document.SetCellStyle("E19", whiteBlackCellLeft);

            document.SetCellValue("A20", "Soporte afiliación caja de compensación");
            document.MergeWorksheetCells("A20", "E20");
            document.SetCellStyle("A20", whiteBlackCellLeft);
            document.SetCellStyle("B20", whiteBlackCellLeft);
            document.SetCellStyle("C20", whiteBlackCellLeft);
            document.SetCellStyle("D20", whiteBlackCellLeft);
            document.SetCellStyle("E20", whiteBlackCellLeft);

            document.SetCellValue("A21", "Soporte examen médico ocupacional de ingreso");
            document.MergeWorksheetCells("A21", "E21");
            document.SetCellStyle("A21", whiteBlackCellLeft);
            document.SetCellStyle("B21", whiteBlackCellLeft);
            document.SetCellStyle("C21", whiteBlackCellLeft);
            document.SetCellStyle("D21", whiteBlackCellLeft);
            document.SetCellStyle("E21", whiteBlackCellLeft);

            document.SetCellValue("A22", "Soporte carta seguimiento recomendación ocupacional");
            document.MergeWorksheetCells("A22", "E22");
            document.SetCellStyle("A22", whiteBlackCellLeft);
            document.SetCellStyle("B22", whiteBlackCellLeft);
            document.SetCellStyle("C22", whiteBlackCellLeft);
            document.SetCellStyle("D22", whiteBlackCellLeft);
            document.SetCellStyle("E22", whiteBlackCellLeft);

            document.SetCellValue("A23", "Certificado de afiliación fondo de pensiones y cesantías");
            document.MergeWorksheetCells("A23", "E23");
            document.SetCellStyle("A23", whiteBlackCellLeft);
            document.SetCellStyle("B23", whiteBlackCellLeft);
            document.SetCellStyle("C23", whiteBlackCellLeft);
            document.SetCellStyle("D23", whiteBlackCellLeft);
            document.SetCellStyle("E23", whiteBlackCellLeft);

            document.SetCellValue("A24", "Certificado de afiliación EPS");
            document.MergeWorksheetCells("A24", "E24");
            document.SetCellStyle("A24", whiteBlackCellLeft);
            document.SetCellStyle("B24", whiteBlackCellLeft);
            document.SetCellStyle("C24", whiteBlackCellLeft);
            document.SetCellStyle("D24", whiteBlackCellLeft);
            document.SetCellStyle("E24", whiteBlackCellLeft);

            document.SetCellValue("A25", "Certificado de cuenta bancaria");
            document.MergeWorksheetCells("A25", "E25");
            document.SetCellStyle("A25", whiteBlackCellLeft);
            document.SetCellStyle("B25", whiteBlackCellLeft);
            document.SetCellStyle("C25", whiteBlackCellLeft);
            document.SetCellStyle("D25", whiteBlackCellLeft);
            document.SetCellStyle("E25", whiteBlackCellLeft);

            document.SetCellValue("A26", "2. EVALUACIÓN");
            document.MergeWorksheetCells("A26", "E26");
            document.SetCellStyle("A26", mediumBlueCell);
            document.SetCellStyle("B26", mediumBlueCell);
            document.SetCellStyle("C26", mediumBlueCell);
            document.SetCellStyle("D26", mediumBlueCell);
            document.SetCellStyle("E26", mediumBlueCell);

            document.SetCellValue("F26", "CHECK");
            document.SetCellStyle("F26", mediumBlueCell);

            document.SetCellValue("A27", "Evaluación de desempeño");
            document.MergeWorksheetCells("A27", "E27");
            document.SetCellStyle("A27", whiteBlackCellLeft);
            document.SetCellStyle("B27", whiteBlackCellLeft);
            document.SetCellStyle("C27", whiteBlackCellLeft);
            document.SetCellStyle("D27", whiteBlackCellLeft);
            document.SetCellStyle("E27", whiteBlackCellLeft);

            document.SetCellValue("A28", "Inducción a empleados nuevos");
            document.MergeWorksheetCells("A28", "E28");
            document.SetCellStyle("A28", whiteBlackCellLeft);
            document.SetCellStyle("B28", whiteBlackCellLeft);
            document.SetCellStyle("C28", whiteBlackCellLeft);
            document.SetCellStyle("D28", whiteBlackCellLeft);
            document.SetCellStyle("E28", whiteBlackCellLeft);

            document.SetCellValue("A29", "Informe de selección");
            document.MergeWorksheetCells("A29", "E29");
            document.SetCellStyle("A29", whiteBlackCellLeft);
            document.SetCellStyle("B29", whiteBlackCellLeft);
            document.SetCellStyle("C29", whiteBlackCellLeft);
            document.SetCellStyle("D29", whiteBlackCellLeft);
            document.SetCellStyle("E29", whiteBlackCellLeft);

            document.SetCellValue("A30", "3. SOPORTE EXPERIENCIA Y REFERENCIAS");
            document.MergeWorksheetCells("A30", "E30");
            document.SetCellStyle("A30", mediumBlueCell);
            document.SetCellStyle("B30", mediumBlueCell);
            document.SetCellStyle("C30", mediumBlueCell);
            document.SetCellStyle("D30", mediumBlueCell);
            document.SetCellStyle("E30", mediumBlueCell);

            document.SetCellValue("F30", "CHECK");
            document.SetCellStyle("F30", mediumBlueCell);

            document.SetCellValue("A31", "Formato verificación de referencias laborales");
            document.MergeWorksheetCells("A31", "E31");
            document.SetCellStyle("A31", whiteBlackCellLeft);
            document.SetCellStyle("B31", whiteBlackCellLeft);
            document.SetCellStyle("C31", whiteBlackCellLeft);
            document.SetCellStyle("D31", whiteBlackCellLeft);
            document.SetCellStyle("E31", whiteBlackCellLeft);

            document.SetCellValue("A32", "Certificados laborales");
            document.MergeWorksheetCells("A32", "E32");
            document.SetCellStyle("A32", whiteBlackCellLeft);
            document.SetCellStyle("B32", whiteBlackCellLeft);
            document.SetCellStyle("C32", whiteBlackCellLeft);
            document.SetCellStyle("D32", whiteBlackCellLeft);
            document.SetCellStyle("E32", whiteBlackCellLeft);

            document.SetCellValue("A33", "Formato verificación de referencias personales");
            document.MergeWorksheetCells("A33", "E33");
            document.SetCellStyle("A33", whiteBlackCellLeft);
            document.SetCellStyle("B33", whiteBlackCellLeft);
            document.SetCellStyle("C33", whiteBlackCellLeft);
            document.SetCellStyle("D33", whiteBlackCellLeft);
            document.SetCellStyle("E33", whiteBlackCellLeft);

            document.SetCellValue("A34", "2 referencias personales con teléfono, nombre y firma de la persona que lo refiere");
            document.MergeWorksheetCells("A34", "E34");
            document.SetCellStyle("A34", whiteBlackCellLeft);
            document.SetCellStyle("B34", whiteBlackCellLeft);
            document.SetCellStyle("C34", whiteBlackCellLeft);
            document.SetCellStyle("D34", whiteBlackCellLeft);
            document.SetCellStyle("E34", whiteBlackCellLeft);

            document.SetCellValue("A35", "4. SOPORTE EDUCACIÓN Y FORMACIÓN");
            document.MergeWorksheetCells("A35", "E35");
            document.SetCellStyle("A35", mediumBlueCell);
            document.SetCellStyle("B35", mediumBlueCell);
            document.SetCellStyle("C35", mediumBlueCell);
            document.SetCellStyle("D35", mediumBlueCell);
            document.SetCellStyle("E35", mediumBlueCell);

            document.SetCellValue("F35", "CHECK");
            document.SetCellStyle("F35", mediumBlueCell);

            document.SetCellValue("A36", "Autorización de Tratamiento de Datos Personales");
            document.MergeWorksheetCells("A36", "E36");
            document.SetCellStyle("A36", whiteBlackCellLeft);
            document.SetCellStyle("B36", whiteBlackCellLeft);
            document.SetCellStyle("C36", whiteBlackCellLeft);
            document.SetCellStyle("D36", whiteBlackCellLeft);
            document.SetCellStyle("E36", whiteBlackCellLeft);

            document.SetCellValue("A37", "Verificación de Estudios");
            document.MergeWorksheetCells("A37", "E37");
            document.SetCellStyle("A37", whiteBlackCellLeft);
            document.SetCellStyle("B37", whiteBlackCellLeft);
            document.SetCellStyle("C37", whiteBlackCellLeft);
            document.SetCellStyle("D37", whiteBlackCellLeft);
            document.SetCellStyle("E37", whiteBlackCellLeft);

            document.SetCellValue("A38", "Fotocopia de la tarjeta profesional (Si aplica)");
            document.MergeWorksheetCells("A38", "E38");
            document.SetCellStyle("A38", whiteBlackCellLeft);
            document.SetCellStyle("B38", whiteBlackCellLeft);
            document.SetCellStyle("C38", whiteBlackCellLeft);
            document.SetCellStyle("D38", whiteBlackCellLeft);
            document.SetCellStyle("E38", whiteBlackCellLeft);

            document.SetCellValue("A39", "Certificados de estudios (Bachiller o técnico o tecnólogo o profesionales)");
            document.MergeWorksheetCells("A39", "E39");
            document.SetCellStyle("A39", whiteBlackCellLeft);
            document.SetCellStyle("B39", whiteBlackCellLeft);
            document.SetCellStyle("C39", whiteBlackCellLeft);
            document.SetCellStyle("D39", whiteBlackCellLeft);
            document.SetCellStyle("E39", whiteBlackCellLeft);

            document.SetCellValue("A40", "Certificados de educación no formal (diplomados, cursos entre otros) (Si aplica)");
            document.MergeWorksheetCells("A40", "E40");
            document.SetCellStyle("A40", whiteBlackCellLeft);
            document.SetCellStyle("B40", whiteBlackCellLeft);
            document.SetCellStyle("C40", whiteBlackCellLeft);
            document.SetCellStyle("D40", whiteBlackCellLeft);
            document.SetCellStyle("E40", whiteBlackCellLeft);

            document.SetCellValue("A41", "5. HOJA DE VIDA");
            document.MergeWorksheetCells("A41", "E41");
            document.SetCellStyle("A41", mediumBlueCell);
            document.SetCellStyle("B41", mediumBlueCell);
            document.SetCellStyle("C41", mediumBlueCell);
            document.SetCellStyle("D41", mediumBlueCell);
            document.SetCellStyle("E41", mediumBlueCell);

            document.SetCellValue("F41", "CHECK");
            document.SetCellStyle("F41", mediumBlueCell);

            document.SetCellValue("A42", "Solicitud de personal (Correo)");
            document.MergeWorksheetCells("A42", "E42");
            document.SetCellStyle("A42", whiteBlackCellLeft);
            document.SetCellStyle("B42", whiteBlackCellLeft);
            document.SetCellStyle("C42", whiteBlackCellLeft);
            document.SetCellStyle("D42", whiteBlackCellLeft);
            document.SetCellStyle("E42", whiteBlackCellLeft);

            document.SetCellValue("A43", "Hoja de vida actualizada");
            document.MergeWorksheetCells("A43", "E43");
            document.SetCellStyle("A43", whiteBlackCellLeft);
            document.SetCellStyle("B43", whiteBlackCellLeft);
            document.SetCellStyle("C43", whiteBlackCellLeft);
            document.SetCellStyle("D43", whiteBlackCellLeft);
            document.SetCellStyle("E43", whiteBlackCellLeft);

            document.SetCellValue("A44", "Fotocopia de la cédula legible ampliada al 150%");
            document.MergeWorksheetCells("A44", "E44");
            document.SetCellStyle("A44", whiteBlackCellLeft);
            document.SetCellStyle("B44", whiteBlackCellLeft);
            document.SetCellStyle("C44", whiteBlackCellLeft);
            document.SetCellStyle("D44", whiteBlackCellLeft);
            document.SetCellStyle("E44", whiteBlackCellLeft);

            document.SetCellValue("A45", "Fotocopia de pasaporte (Si aplica)");
            document.MergeWorksheetCells("A45", "E45");
            document.SetCellStyle("A45", whiteBlackCellLeft);
            document.SetCellStyle("B45", whiteBlackCellLeft);
            document.SetCellStyle("C45", whiteBlackCellLeft);
            document.SetCellStyle("D45", whiteBlackCellLeft);
            document.SetCellStyle("E45", whiteBlackCellLeft);

            document.SetCellValue("A46", "Certificados de antecedentes disciplinarios, judiciales y fiscales");
            document.MergeWorksheetCells("A46", "E46");
            document.SetCellStyle("A46", whiteBlackCellLeft);
            document.SetCellStyle("B46", whiteBlackCellLeft);
            document.SetCellStyle("C46", whiteBlackCellLeft);
            document.SetCellStyle("D46", whiteBlackCellLeft);
            document.SetCellStyle("E46", whiteBlackCellLeft);

            document.SetCellValue("A47", "6. OTROS DOCUMENTOS");
            document.MergeWorksheetCells("A47", "F47");
            document.SetCellStyle("A47", mediumBlueCell);
            document.SetCellStyle("B47", mediumBlueCell);
            document.SetCellStyle("C47", mediumBlueCell);
            document.SetCellStyle("D47", mediumBlueCell);
            document.SetCellStyle("E47", mediumBlueCell);
            document.SetCellStyle("F47", mediumBlueCell);

            document.SetCellValue("A48", others);
            document.MergeWorksheetCells("A48", "F49");
            document.SetCellStyle("A48", whiteBlackCell);
            document.SetCellStyle("B48", whiteBlackCell);
            document.SetCellStyle("C48", whiteBlackCell);
            document.SetCellStyle("D48", whiteBlackCell);
            document.SetCellStyle("E48", whiteBlackCell);
            document.SetCellStyle("F48", whiteBlackCell);
            document.SetCellStyle("A49", whiteBlackCell);
            document.SetCellStyle("B49", whiteBlackCell);
            document.SetCellStyle("C49", whiteBlackCell);
            document.SetCellStyle("D49", whiteBlackCell);
            document.SetCellStyle("E49", whiteBlackCell);
            document.SetCellStyle("F49", whiteBlackCell);

            document.MergeWorksheetCells("A50", "F50");

            document.SetCellValue("A51", "APROBADO POR:");
            document.MergeWorksheetCells("A51", "F51");
            document.SetCellStyle("A51", darkBlueCell);
            document.SetCellStyle("B52", darkBlueCell);
            document.SetCellStyle("C52", darkBlueCell);
            document.SetCellStyle("D52", darkBlueCell);
            document.SetCellStyle("E52", darkBlueCell);
            document.SetCellStyle("F52", darkBlueCell);

            document.SetCellValue("A52", "Nombre:");
            document.SetCellStyle("A52", whiteBlackBoldCell);

            document.SetCellValue("B52", "");
            document.MergeWorksheetCells("B52", "C52");
            document.SetCellStyle("B52", whiteBlackBoldCell);
            document.SetCellStyle("C52", whiteBlackBoldCell);

            document.SetCellValue("D52", "Cargo:");
            document.SetCellStyle("D52", whiteBlackBoldCell);

            document.SetCellValue("E52", "");
            document.MergeWorksheetCells("E52", "F52");
            document.SetCellStyle("E52", whiteBlackBoldCell);
            document.SetCellStyle("F52", whiteBlackBoldCell);

            document.SetCellValue("A53", "Fecha:");
            document.SetCellStyle("A53", whiteBlackBoldCell);

            document.SetCellValue("B53", "");
            document.MergeWorksheetCells("B53", "C53");
            document.SetCellStyle("B53", whiteBlackBoldCell);
            document.SetCellStyle("C53", whiteBlackBoldCell);

            document.SetCellValue("D53", "Firma:");
            document.SetCellStyle("D53", whiteBlackBoldCell);

            document.SetCellValue("E53", "");
            document.MergeWorksheetCells("E53", "F53");
            document.SetCellStyle("E53", whiteBlackBoldCell);
            document.SetCellStyle("F53", whiteBlackBoldCell);

            int aux = 0;

            if (checksDocuments != null && checksDocuments.Count > 0)
            {
                for (int i = 0; i < checksDocuments.Count; i++)
                {
                    if (!string.IsNullOrEmpty(document.GetCellValueAsString("F" + (14 + i + aux).ToString())))
                    {
                        aux++;
                    }

                    document.SetCellValue("F" + (14 + i + aux).ToString(), checksDocuments[i]);
                }
            }

            document.SetCellStyle("F14", whiteBlackCell);
            document.SetCellStyle("F15", whiteBlackCell);
            document.SetCellStyle("F16", whiteBlackCell);
            document.SetCellStyle("F17", whiteBlackCell);
            document.SetCellStyle("F18", whiteBlackCell);
            document.SetCellStyle("F19", whiteBlackCell);
            document.SetCellStyle("F20", whiteBlackCell);
            document.SetCellStyle("F21", whiteBlackCell);
            document.SetCellStyle("F22", whiteBlackCell);
            document.SetCellStyle("F23", whiteBlackCell);
            document.SetCellStyle("F24", whiteBlackCell);
            document.SetCellStyle("F25", whiteBlackCell);
            document.SetCellStyle("F27", whiteBlackCell);
            document.SetCellStyle("F28", whiteBlackCell);
            document.SetCellStyle("F29", whiteBlackCell);
            document.SetCellStyle("F31", whiteBlackCell);
            document.SetCellStyle("F32", whiteBlackCell);
            document.SetCellStyle("F33", whiteBlackCell);
            document.SetCellStyle("F34", whiteBlackCell);
            document.SetCellStyle("F36", whiteBlackCell);
            document.SetCellStyle("F37", whiteBlackCell);
            document.SetCellStyle("F38", whiteBlackCell);
            document.SetCellStyle("F39", whiteBlackCell);
            document.SetCellStyle("F40", whiteBlackCell);
            document.SetCellStyle("F42", whiteBlackCell);
            document.SetCellStyle("F43", whiteBlackCell);
            document.SetCellStyle("F44", whiteBlackCell);
            document.SetCellStyle("F45", whiteBlackCell);
            document.SetCellStyle("F46", whiteBlackCell);

            document.SetColumnWidth("A1", 15);
            document.SetColumnWidth("A2", 15);
            document.SetColumnWidth("A3", 15);
            document.SetColumnWidth("A4", 15);
            document.SetColumnWidth("A5", 15);
            document.SetColumnWidth("A6", 15);
            document.SetColumnWidth("A7", 15);
            document.SetColumnWidth("A8", 15);
            document.SetColumnWidth("A9", 15);
            document.SetColumnWidth("A10", 15);
            document.SetColumnWidth("A11", 15);
            document.SetColumnWidth("A12", 15);
            document.SetColumnWidth("A13", 15);
            document.SetColumnWidth("A14", 15);
            document.SetColumnWidth("A15", 15);
            document.SetColumnWidth("A16", 15);
            document.SetColumnWidth("A17", 15);
            document.SetColumnWidth("A18", 15);
            document.SetColumnWidth("A19", 15);
            document.SetColumnWidth("A20", 15);
            document.SetColumnWidth("A21", 15);
            document.SetColumnWidth("A22", 15);
            document.SetColumnWidth("A23", 15);
            document.SetColumnWidth("A24", 15);
            document.SetColumnWidth("A25", 15);
            document.SetColumnWidth("A26", 15);
            document.SetColumnWidth("A27", 15);
            document.SetColumnWidth("A28", 15);
            document.SetColumnWidth("A29", 15);
            document.SetColumnWidth("A30", 15);
            document.SetColumnWidth("A31", 15);
            document.SetColumnWidth("A32", 15);
            document.SetColumnWidth("A33", 15);
            document.SetColumnWidth("A34", 15);
            document.SetColumnWidth("A35", 15);
            document.SetColumnWidth("A36", 15);
            document.SetColumnWidth("A37", 15);
            document.SetColumnWidth("A38", 15);
            document.SetColumnWidth("A39", 15);
            document.SetColumnWidth("A40", 15);
            document.SetColumnWidth("A41", 15);
            document.SetColumnWidth("A42", 15);
            document.SetColumnWidth("A43", 15);
            document.SetColumnWidth("A44", 15);
            document.SetColumnWidth("A45", 15);
            document.SetColumnWidth("A46", 15);
            document.SetColumnWidth("A47", 15);
            document.SetColumnWidth("A48", 15);
            document.SetColumnWidth("A49", 15);
            document.SetColumnWidth("A50", 15);
            document.SetColumnWidth("A51", 15);
            document.SetColumnWidth("A52", 15);
            document.SetColumnWidth("B1", 15);
            document.SetColumnWidth("B2", 15);
            document.SetColumnWidth("B3", 15);
            document.SetColumnWidth("B4", 15);
            document.SetColumnWidth("B5", 15);
            document.SetColumnWidth("B6", 15);
            document.SetColumnWidth("B7", 15);
            document.SetColumnWidth("B8", 15);
            document.SetColumnWidth("B9", 15);
            document.SetColumnWidth("B10", 15);
            document.SetColumnWidth("B11", 15);
            document.SetColumnWidth("B12", 15);
            document.SetColumnWidth("B13", 15);
            document.SetColumnWidth("B14", 15);
            document.SetColumnWidth("B15", 15);
            document.SetColumnWidth("B16", 15);
            document.SetColumnWidth("B17", 15);
            document.SetColumnWidth("B18", 15);
            document.SetColumnWidth("B19", 15);
            document.SetColumnWidth("B20", 15);
            document.SetColumnWidth("B21", 15);
            document.SetColumnWidth("B22", 15);
            document.SetColumnWidth("B23", 15);
            document.SetColumnWidth("B24", 15);
            document.SetColumnWidth("B25", 15);
            document.SetColumnWidth("B26", 15);
            document.SetColumnWidth("B27", 15);
            document.SetColumnWidth("B28", 15);
            document.SetColumnWidth("B29", 15);
            document.SetColumnWidth("B30", 15);
            document.SetColumnWidth("B31", 15);
            document.SetColumnWidth("B32", 15);
            document.SetColumnWidth("B33", 15);
            document.SetColumnWidth("B34", 15);
            document.SetColumnWidth("B35", 15);
            document.SetColumnWidth("B36", 15);
            document.SetColumnWidth("B37", 15);
            document.SetColumnWidth("B38", 15);
            document.SetColumnWidth("B39", 15);
            document.SetColumnWidth("B40", 15);
            document.SetColumnWidth("B41", 15);
            document.SetColumnWidth("B42", 15);
            document.SetColumnWidth("B43", 15);
            document.SetColumnWidth("B44", 15);
            document.SetColumnWidth("B45", 15);
            document.SetColumnWidth("B46", 15);
            document.SetColumnWidth("B47", 15);
            document.SetColumnWidth("B48", 15);
            document.SetColumnWidth("B49", 15);
            document.SetColumnWidth("B50", 15);
            document.SetColumnWidth("B51", 15);
            document.SetColumnWidth("B52", 15);
            document.SetColumnWidth("C1", 15);
            document.SetColumnWidth("C2", 15);
            document.SetColumnWidth("C3", 15);
            document.SetColumnWidth("C4", 15);
            document.SetColumnWidth("C5", 15);
            document.SetColumnWidth("C6", 15);
            document.SetColumnWidth("C7", 15);
            document.SetColumnWidth("C8", 15);
            document.SetColumnWidth("C9", 15);
            document.SetColumnWidth("C10", 15);
            document.SetColumnWidth("C11", 15);
            document.SetColumnWidth("C12", 15);
            document.SetColumnWidth("C13", 15);
            document.SetColumnWidth("C14", 15);
            document.SetColumnWidth("C15", 15);
            document.SetColumnWidth("C16", 15);
            document.SetColumnWidth("C17", 15);
            document.SetColumnWidth("C18", 15);
            document.SetColumnWidth("C19", 15);
            document.SetColumnWidth("C20", 15);
            document.SetColumnWidth("C21", 15);
            document.SetColumnWidth("C22", 15);
            document.SetColumnWidth("C23", 15);
            document.SetColumnWidth("C24", 15);
            document.SetColumnWidth("C25", 15);
            document.SetColumnWidth("C26", 15);
            document.SetColumnWidth("C27", 15);
            document.SetColumnWidth("C28", 15);
            document.SetColumnWidth("C29", 15);
            document.SetColumnWidth("C30", 15);
            document.SetColumnWidth("C31", 15);
            document.SetColumnWidth("C32", 15);
            document.SetColumnWidth("C33", 15);
            document.SetColumnWidth("C34", 15);
            document.SetColumnWidth("C35", 15);
            document.SetColumnWidth("C36", 15);
            document.SetColumnWidth("C37", 15);
            document.SetColumnWidth("C38", 15);
            document.SetColumnWidth("C39", 15);
            document.SetColumnWidth("C40", 15);
            document.SetColumnWidth("C41", 15);
            document.SetColumnWidth("C42", 15);
            document.SetColumnWidth("C43", 15);
            document.SetColumnWidth("C44", 15);
            document.SetColumnWidth("C45", 15);
            document.SetColumnWidth("C46", 15);
            document.SetColumnWidth("C47", 15);
            document.SetColumnWidth("C48", 15);
            document.SetColumnWidth("C49", 15);
            document.SetColumnWidth("C50", 15);
            document.SetColumnWidth("C51", 15);
            document.SetColumnWidth("C52", 15);
            document.SetColumnWidth("D1", 15);
            document.SetColumnWidth("D2", 15);
            document.SetColumnWidth("D3", 15);
            document.SetColumnWidth("D4", 15);
            document.SetColumnWidth("D5", 15);
            document.SetColumnWidth("D6", 15);
            document.SetColumnWidth("D7", 15);
            document.SetColumnWidth("D8", 15);
            document.SetColumnWidth("D9", 15);
            document.SetColumnWidth("D10", 15);
            document.SetColumnWidth("D11", 15);
            document.SetColumnWidth("D12", 15);
            document.SetColumnWidth("D13", 15);
            document.SetColumnWidth("D14", 15);
            document.SetColumnWidth("D15", 15);
            document.SetColumnWidth("D16", 15);
            document.SetColumnWidth("D17", 15);
            document.SetColumnWidth("D18", 15);
            document.SetColumnWidth("D19", 15);
            document.SetColumnWidth("D20", 15);
            document.SetColumnWidth("D21", 15);
            document.SetColumnWidth("D22", 15);
            document.SetColumnWidth("D23", 15);
            document.SetColumnWidth("D24", 15);
            document.SetColumnWidth("D25", 15);
            document.SetColumnWidth("D26", 15);
            document.SetColumnWidth("D27", 15);
            document.SetColumnWidth("D28", 15);
            document.SetColumnWidth("D29", 15);
            document.SetColumnWidth("D30", 15);
            document.SetColumnWidth("D31", 15);
            document.SetColumnWidth("D32", 15);
            document.SetColumnWidth("D33", 15);
            document.SetColumnWidth("D34", 15);
            document.SetColumnWidth("D35", 15);
            document.SetColumnWidth("D36", 15);
            document.SetColumnWidth("D37", 15);
            document.SetColumnWidth("D38", 15);
            document.SetColumnWidth("D39", 15);
            document.SetColumnWidth("D40", 15);
            document.SetColumnWidth("D41", 15);
            document.SetColumnWidth("D42", 15);
            document.SetColumnWidth("D43", 15);
            document.SetColumnWidth("D44", 15);
            document.SetColumnWidth("D45", 15);
            document.SetColumnWidth("D46", 15);
            document.SetColumnWidth("D47", 15);
            document.SetColumnWidth("D48", 15);
            document.SetColumnWidth("D49", 15);
            document.SetColumnWidth("D50", 15);
            document.SetColumnWidth("D51", 15);
            document.SetColumnWidth("D52", 15);
            document.SetColumnWidth("E1", 15);
            document.SetColumnWidth("E2", 15);
            document.SetColumnWidth("E3", 15);
            document.SetColumnWidth("E4", 15);
            document.SetColumnWidth("E5", 15);
            document.SetColumnWidth("E6", 15);
            document.SetColumnWidth("E7", 15);
            document.SetColumnWidth("E8", 15);
            document.SetColumnWidth("E9", 15);
            document.SetColumnWidth("E10", 15);
            document.SetColumnWidth("E11", 15);
            document.SetColumnWidth("E12", 15);
            document.SetColumnWidth("E13", 15);
            document.SetColumnWidth("E14", 15);
            document.SetColumnWidth("E15", 15);
            document.SetColumnWidth("E16", 15);
            document.SetColumnWidth("E17", 15);
            document.SetColumnWidth("E18", 15);
            document.SetColumnWidth("E19", 15);
            document.SetColumnWidth("E20", 15);
            document.SetColumnWidth("E21", 15);
            document.SetColumnWidth("E22", 15);
            document.SetColumnWidth("E23", 15);
            document.SetColumnWidth("E24", 15);
            document.SetColumnWidth("E25", 15);
            document.SetColumnWidth("E26", 15);
            document.SetColumnWidth("E27", 15);
            document.SetColumnWidth("E28", 15);
            document.SetColumnWidth("E29", 15);
            document.SetColumnWidth("E30", 15);
            document.SetColumnWidth("E31", 15);
            document.SetColumnWidth("E32", 15);
            document.SetColumnWidth("E33", 15);
            document.SetColumnWidth("E34", 15);
            document.SetColumnWidth("E35", 15);
            document.SetColumnWidth("E36", 15);
            document.SetColumnWidth("E37", 15);
            document.SetColumnWidth("E38", 15);
            document.SetColumnWidth("E39", 15);
            document.SetColumnWidth("E40", 15);
            document.SetColumnWidth("E41", 15);
            document.SetColumnWidth("E42", 15);
            document.SetColumnWidth("E43", 15);
            document.SetColumnWidth("E44", 15);
            document.SetColumnWidth("E45", 15);
            document.SetColumnWidth("E46", 15);
            document.SetColumnWidth("E47", 15);
            document.SetColumnWidth("E48", 15);
            document.SetColumnWidth("E49", 15);
            document.SetColumnWidth("E50", 15);
            document.SetColumnWidth("E51", 15);
            document.SetColumnWidth("E52", 15);
            document.SetColumnWidth("F1", 15);
            document.SetColumnWidth("F2", 15);
            document.SetColumnWidth("F3", 15);
            document.SetColumnWidth("F4", 15);
            document.SetColumnWidth("F5", 15);
            document.SetColumnWidth("F6", 15);
            document.SetColumnWidth("F7", 15);
            document.SetColumnWidth("F8", 15);
            document.SetColumnWidth("F9", 15);
            document.SetColumnWidth("F10", 15);
            document.SetColumnWidth("F11", 15);
            document.SetColumnWidth("F12", 15);
            document.SetColumnWidth("F13", 15);
            document.SetColumnWidth("F14", 15);
            document.SetColumnWidth("F15", 15);
            document.SetColumnWidth("F16", 15);
            document.SetColumnWidth("F17", 15);
            document.SetColumnWidth("F18", 15);
            document.SetColumnWidth("F19", 15);
            document.SetColumnWidth("F20", 15);
            document.SetColumnWidth("F21", 15);
            document.SetColumnWidth("F22", 15);
            document.SetColumnWidth("F23", 15);
            document.SetColumnWidth("F24", 15);
            document.SetColumnWidth("F25", 15);
            document.SetColumnWidth("F26", 15);
            document.SetColumnWidth("F27", 15);
            document.SetColumnWidth("F28", 15);
            document.SetColumnWidth("F29", 15);
            document.SetColumnWidth("F30", 15);
            document.SetColumnWidth("F31", 15);
            document.SetColumnWidth("F32", 15);
            document.SetColumnWidth("F33", 15);
            document.SetColumnWidth("F34", 15);
            document.SetColumnWidth("F35", 15);
            document.SetColumnWidth("F36", 15);
            document.SetColumnWidth("F37", 15);
            document.SetColumnWidth("F38", 15);
            document.SetColumnWidth("F39", 15);
            document.SetColumnWidth("F40", 15);
            document.SetColumnWidth("F41", 15);
            document.SetColumnWidth("F42", 15);
            document.SetColumnWidth("F43", 15);
            document.SetColumnWidth("F44", 15);
            document.SetColumnWidth("F45", 15);
            document.SetColumnWidth("F46", 15);
            document.SetColumnWidth("F47", 15);
            document.SetColumnWidth("F48", 15);
            document.SetColumnWidth("F49", 15);
            document.SetColumnWidth("F50", 15);
            document.SetColumnWidth("F51", 15);
            document.SetColumnWidth("F52", 15);


            /**/

            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));

            Directory.CreateDirectory(folderPath);

            string pathWithExtension = Path.GetFullPath(Path.Combine(folderPath, document.GetCurrentWorksheetName() + ".xlsx"));

            document.SaveAs(pathWithExtension);

            FileStream fs = new FileStream(pathWithExtension, FileMode.Open);

            MemoryStream ms = new MemoryStream();
            
            fs.CopyTo(ms);
            fs.Dispose();

            try
            {
                File.Delete(pathWithExtension);

                return ms;
            }
            catch (Exception ex)
            {
                return null;
            }
        }   
    }
}
