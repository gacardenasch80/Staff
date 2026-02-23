using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MimeKit;
using SelectPdf;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System.Collections.Generic;

namespace CandidatesMS.Services
{
    public interface IPDFGenerator
    {
        Task<MemoryStream> CreateCheckDocumentReportPDFByHTML(Candidate candidate, int companyUserId);
    }

    public class PDFGenerator : IPDFGenerator
    {
        private readonly IBasicInformationRepository _basicInformationRepository;
        private readonly ICandidateCompanyRepository _candidateCompanyRepository;
        private readonly IDocumentCheckRepository _documentCheckRepository;

        public PDFGenerator(IBasicInformationRepository basicInformationRepository,
                            ICandidateCompanyRepository candidateCompanyRepository,
                            IDocumentCheckRepository documentCheckRepository)
        {
            _basicInformationRepository = basicInformationRepository;
            _candidateCompanyRepository = candidateCompanyRepository;
            _documentCheckRepository = documentCheckRepository;
        }

        public async Task<MemoryStream> CreateCheckDocumentReportPDFByHTML(Candidate candidate, int companyUserId)
        {
            GlobalProperties.EnableRestrictedRenderingEngine = true;

            BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidate.CandidateId);

            CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidate.CandidateId, companyUserId);

            List<DocumentCheck> documentChecks = await _documentCheckRepository.GetAllByCandidateId(candidate.CandidateId, companyUserId);

            string others = string.Empty;

            if (basicInformation == null)
                basicInformation = new BasicInformation();

            if(candidateCompany == null)
                candidateCompany = new CandidateCompany();

            if(documentChecks == null)
                documentChecks = new List<DocumentCheck>();

            List<string> checksDocuments = new List<string>();

            if(documentChecks != null && documentChecks.Count > 0)
            {
                foreach(DocumentCheck documentCheck in documentChecks)
                {
                    string check = documentCheck.IsCheck ? "X" : "";

                    if(documentCheck.OrderId > 20)
                        checksDocuments.Add(check);

                    if(!string.IsNullOrEmpty(documentCheck.Text))
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

            if (!string.IsNullOrEmpty(basicInformation.Document))
                candidateDocument = basicInformation.Document;
            if (string.IsNullOrEmpty(candidateDocument) && !string.IsNullOrEmpty(candidateCompany.Document))
                candidateDocument = candidateCompany.Document;

            if (!string.IsNullOrEmpty(basicInformation.Phone))
                candidatePhone = basicInformation.Phone;
            if (string.IsNullOrEmpty(candidatePhone) && !string.IsNullOrEmpty(basicInformation.Cellphone))
                candidatePhone = basicInformation.Cellphone;
            if (string.IsNullOrEmpty(candidatePhone) && (basicInformation.Phones != null && basicInformation.Phones.Count > 0))
            {
                foreach (Phone phone in basicInformation.Phones)
                {
                    if (phone.CompanyUserId == companyUserId && !string.IsNullOrEmpty(phone.Number))
                    {
                        candidatePhone = phone.Number;

                        break;
                    }
                }
            }

            BodyBuilder builder = new BodyBuilder();

            string html = "https://recursos-correos-lambda.s3.amazonaws.com/plantillaVerificacionDocumentos.html";

            WebClient client = new WebClient();
            Uri uri = new Uri(html);
            Stream stream = await client.OpenReadTaskAsync(uri);
            StreamReader reader = new StreamReader(stream);

            builder.HtmlBody = reader.ReadToEnd()
                .Replace("nameCandidate", candidateName)
                .Replace("identificationCandidate", candidateDocument)
                .Replace("phoneCandidate", candidatePhone)
                .Replace("checkDocument01", checksDocuments[0])
                .Replace("checkDocument02", checksDocuments[1])
                .Replace("checkDocument03", checksDocuments[2])
                .Replace("checkDocument04", checksDocuments[3])
                .Replace("checkDocument05", checksDocuments[4])
                .Replace("checkDocument06", checksDocuments[5])
                .Replace("checkDocument07", checksDocuments[6])
                .Replace("checkDocument08", checksDocuments[7])
                .Replace("checkDocument09", checksDocuments[8])
                .Replace("checkDocument10", checksDocuments[9])
                .Replace("checkDocument11", checksDocuments[10])
                .Replace("checkDocument12", checksDocuments[11])
                .Replace("checkDocument13", checksDocuments[12])
                .Replace("checkDocument14", checksDocuments[13])
                .Replace("checkDocument15", checksDocuments[14])
                .Replace("checkDocument16", checksDocuments[15])
                .Replace("checkDocument17", checksDocuments[16])
                .Replace("checkDocument18", checksDocuments[17])
                .Replace("checkDocument19", checksDocuments[18])
                .Replace("checkDocument20", checksDocuments[19])
                .Replace("checkDocument21", checksDocuments[20])
                .Replace("checkDocument22", checksDocuments[21])
                .Replace("checkDocument23", checksDocuments[22])
                .Replace("checkDocument24", checksDocuments[23])
                .Replace("checkDocument25", checksDocuments[24])
                .Replace("checkDocument26", checksDocuments[25])
                .Replace("checkDocument27", checksDocuments[26])
                .Replace("checkDocument28", checksDocuments[27])
                .Replace("checkDocument29", checksDocuments[28])
                .Replace("textOtherDocuments", others);

            HtmlToPdf htmlToPdf = new HtmlToPdf();

            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(builder.HtmlBody);

            byte[] pdf = pdfDocument.Save();
            pdfDocument.Close();

            MemoryStream memoryStream = new MemoryStream(pdf);

            return memoryStream;
        }
    }
}
