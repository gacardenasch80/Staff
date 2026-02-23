using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentCheckController : ControllerBase
    {
        private IAttachedFileRepository _attachedFileRepository;
        private ICVRepository _cvRepository;
        private ICandidateRepository _candidateRepository;
        private IDocumentCheckRepository _documentCheckRepository;
        private IDocumentCheckGroupRepository _documentCheckGroupRepository;
        private IMemberUserRepository _memberUserRepository;
        private IStudyRepository _studyRepository;
        private IStudyCertificateRepository _studyCertificateRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private IDocumentCheckService _documentCheckService;

        private IPDFGenerator _PDFGenerator;
        private IExcelGenerator _excelGenerator;

        private IMapper _mapper;

        public DocumentCheckController
            (
                            IAttachedFileRepository attachedFileRepository,
                            ICVRepository basicInformationRepository,
                            ICandidateRepository candidateRepository,
                            IDocumentCheckRepository documentCheckRepository,
                            IDocumentCheckGroupRepository documentCheckGroupRepository,
                            IMemberUserRepository memberUserRepository,
                            IStudyRepository studyRepository,
                            IStudyCertificateRepository studyCertificateRepository,
                            
                            ICompanyRemoteRepository companyRemoteRepository,

                            IAuthorizationHelper authorizationHelper,
                            IDocumentCheckService documentCheckService,
                            
                            IPDFGenerator PDFGenerator,
                            IExcelGenerator excelGenerator,
                            
                            IMapper mapper
            )
        {
            _attachedFileRepository = attachedFileRepository;
            _cvRepository = basicInformationRepository;
            _candidateRepository = candidateRepository;
            _documentCheckRepository = documentCheckRepository;
            _documentCheckGroupRepository = documentCheckGroupRepository;
            _memberUserRepository = memberUserRepository;
            _studyRepository = studyRepository;
            _studyCertificateRepository = studyCertificateRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _documentCheckService = documentCheckService;

            _PDFGenerator = PDFGenerator;
            _excelGenerator = excelGenerator;

            _mapper = mapper;
        }

        [HttpPost("selection/{candidateId}")]
        public async Task<IActionResult> GetDocumentChecksSelectionByCandidateId(int candidateId, [FromBody] DocumentCheckStructureDTO currentCheckStructure)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            List<DocumentCheck> currentDocumentChecks = await _documentCheckRepository.GetAllByCandidateId(candidateId, memberUser.CompanyUserId);
            List<DocumentCheck> newDocumentChecks = new List<DocumentCheck>();

            DocumentCheckStructureDTO documentCheckStructureDTO = new DocumentCheckStructureDTO();
            List<DocumentCheckGroupDTO> documentCheckGroupsDTO = new List<DocumentCheckGroupDTO>();

            List<DocumentCheckGroup> documentCheckGroups = await _documentCheckGroupRepository.GetAllInRange(1, 3);

            if (documentCheckGroups != null && documentCheckGroups.Count > 0)
            {
                foreach (DocumentCheckGroup documentCheckGroup in documentCheckGroups)
                {
                    DocumentCheckGroupDTO documentCheckGroupDTO = new DocumentCheckGroupDTO
                    {
                        DocumentCheckGroupId = documentCheckGroup.DocumentCheckGroupId,
                        Name = documentCheckGroup.Name,
                        NameEnglish = documentCheckGroup.NameEnglish
                    };

                    documentCheckGroupsDTO.Add(documentCheckGroupDTO);
                }

                documentCheckStructureDTO.DocumentCheckGroups = documentCheckGroupsDTO;
            }
            else
                documentCheckStructureDTO.DocumentCheckGroups = new List<DocumentCheckGroupDTO>();

            /* HOJA DE VIDA */

            /* Hoja de vida */
            CV cvDB = await _cvRepository.GetByCandidateIdToCandidate(candidateId);

            CV cvOverViewDB = await _cvRepository.ExsistOverViewCvByCandidateId(candidateId);

            List<CV> cvsCompany = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, memberUser.CompanyUserId);

            List<AttachedFile> candidateCV =
                await _attachedFileRepository.GetByFileTypeAndCompanyIdOrOwnAndCandidateId(candidateId, memberUser.CompanyUserId, 5);

            List<AttachedFile> anyCV =
                await _attachedFileRepository.GetByFileTypeAndCompanyIdOrOwnAndCandidateId(candidateId, memberUser.CompanyUserId, 6);

            List<AttachedFile> adminCV =
                await _attachedFileRepository.GetByFileTypeAndCompanyIdOrOwnAndCandidateId(candidateId, memberUser.CompanyUserId, 8);

             DocumentCheck cv = new DocumentCheck
            {
                OrderId = 1,
                CandidateId = candidateId,
                DocumentCheckGroupId = 1,
                DocumentCheckStateId = 1,
                IsCheck = false,
                IsEnabled = false,
                CompanyUserId = memberUser.CompanyUserId,
                Name = "Hoja de vida",
                NameEnglish = "Resume"
            };

            if (cvDB != null || cvOverViewDB != null || (cvsCompany != null && cvsCompany.Count > 0) ||
                (candidateCV != null && candidateCV.Count > 0) || (anyCV != null && anyCV.Count > 0) || (adminCV != null && adminCV.Count > 0))
                cv.IsCheck = true;

            if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
            {
                foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                    if (group.DocumentCheckGroupId == 1 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                        foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                            if (item.OrderId == 1)
                                cv.DocumentCheckId = item.DocumentCheckId;
            }
            else
            {
                if (await _documentCheckRepository.ExistByOrderId(1, memberUser.CompanyUserId))
                {
                    DocumentCheck oldCheck = await _documentCheckRepository.GetByCandidateIdAndOrderId(candidateId, 1, memberUser.CompanyUserId);

                    if (oldCheck != null)
                        cv.DocumentCheckId = oldCheck.DocumentCheckId;
                }
            }

            /* SOPORTES */

            /* Académicos */
            DocumentCheck academics = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 2, 2,
                "Títulos académicos", "Academic degrees", currentCheckStructure);

            /* Referencias laborales */
            DocumentCheck workReferences = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 15, 3, 2,
                "Referencias laborales", "Work references", currentCheckStructure);

            /* Pruebas psicotécnicas */
            DocumentCheck psicotechnicalTests = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 2, 4, 2,
                "Pruebas psicotécnicas", "Psycho-technical tests", currentCheckStructure);

            /* Pruebas técnicas */
            DocumentCheck technicalTests = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 1, 5, 2,
                "Pruebas técnicas", "Technical tests", currentCheckStructure);

            /* Pruebas idioma */
            DocumentCheck languageTests = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 3, 6, 2,
                "Pruebas idioma", "Language tests", currentCheckStructure);

            /* Referencias personales */
            DocumentCheck personalReferences = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 16, 7, 2,
                "Referencias personales", "Personal references", currentCheckStructure);

            /* Propuesta laboral */
            DocumentCheck jobProposal = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 12, 8, 2,
                "Propuesta laboral", "Job offer", currentCheckStructure);

            /* Aceptación de propuesta laboral */
            DocumentCheck jobProposalAcceptance = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 13, 9, 2,
                "Aceptación de propuesta laboral", "Acceptance of job offer", currentCheckStructure);

            /* Confirmación de jefe inmediato */
            DocumentCheck immediateBoss = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 14, 10, 2,
                "Confirmación de jefe inmediato", "Confirmation from immediate boss", currentCheckStructure);

            /* Validación académica */
            DocumentCheck academicCheck = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 17, 11, 2,
                "Validación académica", "Academic validation", currentCheckStructure);

            /* Validación de antecedentes */
            DocumentCheck backgroundCheck = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 21, 12, 2,
                "Validación de antecedentes", "Background validation", currentCheckStructure);

            /* DOCUMENTACIÓN ADICIONAL */

            /* Tarjeta profesional */
            DocumentCheck proffesionalCard = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 13, 3,
                "Tarjeta profesional", "Proffesional card", currentCheckStructure);

            /* Documento de identidad */
            DocumentCheck idCard = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 22, 14, 3,
                "Documento de identidad", "Identity card", currentCheckStructure);

            /* Autorización de datos personales */
            DocumentCheck personalDataAuth = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 9, 15, 3,
                "Autorización de datos personales", "Authorization of personal data", currentCheckStructure);

            /* Publicación de vacante */
            DocumentCheck jobPublication = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 10, 16, 3,
                "Publicación de vacante", "Publication of vacancy", currentCheckStructure);

            /* Informe de selección */
            DocumentCheck selectionReport = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 11, 17, 3,
                "Informe de selección", "Selection report", currentCheckStructure);

            /* Novedad de ingreso */
            DocumentCheck noveltyAdmission = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 18, 18, 3,
                "Novedad de ingreso", "New entry", currentCheckStructure);

            /* Solicitud de personal */
            DocumentCheck staffRequest = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 19, 19, 3,
                "Solicitud de personal", "Personnel application", currentCheckStructure);

            /* RUT actualizado */
            DocumentCheck rut = await _documentCheckService.AutomaticCheckValue(memberUser.CompanyUserId, candidateId, 20, 20, 3,
                "RUT actualizado", "Updated RUT", currentCheckStructure);

            /**/

            List<DocumentCheck> documentChecksOld = await _documentCheckRepository.GetByCandidateIdAndLimitGroups(candidateId, memberUser.CompanyUserId, 1, 3);

            bool isSaved = true;

            newDocumentChecks.Add(cv);

            newDocumentChecks.Add(academics);
            newDocumentChecks.Add(workReferences);
            newDocumentChecks.Add(psicotechnicalTests);
            newDocumentChecks.Add(technicalTests);
            newDocumentChecks.Add(languageTests);
            newDocumentChecks.Add(personalReferences);
            newDocumentChecks.Add(jobProposal);
            newDocumentChecks.Add(jobProposalAcceptance);
            newDocumentChecks.Add(immediateBoss);
            newDocumentChecks.Add(academicCheck);
            newDocumentChecks.Add(backgroundCheck);

            newDocumentChecks.Add(proffesionalCard);
            newDocumentChecks.Add(idCard);
            newDocumentChecks.Add(personalDataAuth);
            newDocumentChecks.Add(jobPublication);
            newDocumentChecks.Add(selectionReport);
            newDocumentChecks.Add(noveltyAdmission);
            newDocumentChecks.Add(staffRequest);
            newDocumentChecks.Add(rut);

            if (documentChecksOld != null && documentChecksOld.Count > 0)
            {
                try
                {
                    //foreach (DocumentCheck check in documentChecksOld)
                    //    await _documentCheckRepository.Remove(check.DocumentCheckId);

                    for (int i = 0; i < documentChecksOld.Count; i++)
                    {
                        foreach (DocumentCheck newDocumentCheck in newDocumentChecks)
                        {
                            //if (newDocumentCheck.OrderId == documentChecksOld[i].OrderId
                            if (newDocumentCheck.DocumentCheckId == documentChecksOld[i].DocumentCheckId)
                            {
                                newDocumentCheck.DocumentCheckId = documentChecksOld[i].DocumentCheckId;

                                await _documentCheckRepository.Remove(documentChecksOld[i].DocumentCheckId);

                                await _documentCheckRepository.Add(newDocumentCheck);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    isSaved = false;
                }
            }
            else
            {
                isSaved = await _documentCheckRepository.AddRange(newDocumentChecks);
            }

            if (isSaved)
            {
                if (documentCheckStructureDTO.DocumentCheckGroups != null && documentCheckStructureDTO.DocumentCheckGroups.Count > 0)
                {
                    foreach (DocumentCheckGroupDTO group in documentCheckStructureDTO.DocumentCheckGroups)
                    {
                        List<DocumentCheckDTO> listItems = new List<DocumentCheckDTO>();

                        if (group.DocumentCheckGroupId == 1)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(cv));
                        }

                        if (group.DocumentCheckGroupId == 2)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(academics));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(workReferences));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(psicotechnicalTests));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(technicalTests));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(languageTests));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(personalReferences));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(jobProposal));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(jobProposalAcceptance));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(immediateBoss));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(academicCheck));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(backgroundCheck));
                        }

                        if (group.DocumentCheckGroupId == 3)
                        {

                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(proffesionalCard));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(idCard));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(personalDataAuth));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(jobPublication));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(selectionReport));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(noveltyAdmission));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(staffRequest));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(rut));
                        }

                        group.DocumentCheckItems = listItems;
                    }

                    documentCheckStructureDTO.DocumentCheckGroups.Sort((x, y) => x.DocumentCheckGroupId.CompareTo(y.DocumentCheckGroupId));
                    documentCheckStructureDTO.CandidateId = candidateId;
                }

                return Ok(new { message = "Checks cambiados exitosamente", obj = documentCheckStructureDTO });
            }
            else
                return StatusCode(500, new { message = "No se pudieron actualizar los checks", obj = documentCheckStructureDTO });
        }

        [HttpPost("hiring/{candidateId}")]
        public async Task<IActionResult> GetDocumentChecksHiringByCandidateId(int candidateId, [FromBody] DocumentCheckStructureDTO currentCheckStructure)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            List<DocumentCheck> currentDocumentChecks = await _documentCheckRepository.GetAllByCandidateId(candidateId, memberUser.CompanyUserId);
            List<DocumentCheck> newDocumentChecks = new List<DocumentCheck>();

            DocumentCheckStructureDTO documentCheckStructureDTO = new DocumentCheckStructureDTO();
            List<DocumentCheckGroupDTO> documentCheckGroupsDTO = new List<DocumentCheckGroupDTO>();

            List<DocumentCheckGroup> documentCheckGroups = await _documentCheckGroupRepository.GetAllInRange(4, 9);

            if (documentCheckGroups != null && documentCheckGroups.Count > 0)
            {
                foreach (DocumentCheckGroup documentCheckGroup in documentCheckGroups)
                {
                    DocumentCheckGroupDTO documentCheckGroupDTO = new DocumentCheckGroupDTO
                    {
                        DocumentCheckGroupId = documentCheckGroup.DocumentCheckGroupId,
                        Name = documentCheckGroup.Name,
                        NameEnglish = documentCheckGroup.NameEnglish
                    };

                    documentCheckGroupsDTO.Add(documentCheckGroupDTO);
                }

                documentCheckStructureDTO.DocumentCheckGroups = documentCheckGroupsDTO;
            }
            else
                documentCheckStructureDTO.DocumentCheckGroups = new List<DocumentCheckGroupDTO>();

            /* VINCULACIÓN */

            /* Contrato y anexos */
            DocumentCheck contract = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 21, 4,
                "Contrato y anexos", "Contract and attachments", currentCheckStructure);

            /* Especificaciones del cargo */
            DocumentCheck position = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 22, 4,
                "Especificaciones del cargo", "Job specifications", currentCheckStructure);

            /* Cláusulas SI */
            DocumentCheck si = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 23, 4,
                "Cláusulas SI", "IS Clauses", currentCheckStructure);

            /* Perfil sociodm. y respon. SG-SST */
            DocumentCheck sgsst = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 24, 4,
                "Perfil sociodm. y respon. SG-SST", "Sociodm. profile and respon. SG-SST", currentCheckStructure);

            /* Soporte afiliación ARL */
            DocumentCheck arl = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 25, 4,
                "Soporte afiliación ARL", "ARL affiliation support", currentCheckStructure);

            /* Soporte afiliación EPS */
            DocumentCheck eps = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 26, 4,
                "Soporte afiliación EPS", "EPS affiliation support", currentCheckStructure);

            /* Soporte afiliación caja de compensación */
            DocumentCheck compensationBox = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 27, 4,
                "Soporte afiliación caja de compensación", "Compensation fund affiliation support", currentCheckStructure);

            /* Soporte examen médico */
            DocumentCheck medicalExamination = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 28, 4,
                "Soporte examen médico", "Medical examination support", currentCheckStructure);

            /* Soporte carta recomendación ocupacional */
            DocumentCheck letterSupport = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 29, 4,
                "Soporte carta recomendación ocupacional", "Support occupational recommendation letter", currentCheckStructure);

            /* Certificado AFP y cesantías */
            DocumentCheck afpCert = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 11, 30, 4,
                "Certificado AFP y cesantías", "AFP and severance pay certificate", currentCheckStructure);

            /* Certificado de afiliación EPS */
            DocumentCheck epsCert = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 12, 31, 4,
                "Certificado de afiliación EPS", "EPS affiliation certificate", currentCheckStructure);

            /* Certificado de cuenta bancaria */
            DocumentCheck bankAccount = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 13, 32, 4,
                "Certificado de cuenta bancaria", "Bank account certificate", currentCheckStructure);

            /* EVALUACIÓN */

            /* Evaluación de desempeño */
            DocumentCheck permormanceEval = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 33, 5,
                "Evaluación de desempeño", "Performance evaluation", currentCheckStructure);

            /* Inducción a empleados nuevos */
            DocumentCheck induction = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 34, 5,
                "Inducción a empleados nuevos", "Induction of new employees", currentCheckStructure);

            /* Informe de selección  */
            DocumentCheck selectionReport = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 14, 35, 5,
                "Informe de selección", "Selection report", currentCheckStructure);

            /* SOPORTE EXPERIENCIA Y REFERENCIAS */

            /* Formato verificación de referencias laborales  */
            DocumentCheck workReferencesVerification = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 22, 36, 6,
                "Formato verificación de referencias laborales", "Labor references verification form", currentCheckStructure);

            /* Certificados laborales  */
            DocumentCheck workCert = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 8, 37, 6,
                "Certificados laborales", "Labor certificates", currentCheckStructure);

            /* Formato verificación de referencias personales  */
            DocumentCheck personalReferencesVerification = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 9, 38, 6,
                "Formato verificación de referencias personales", "Personal references verification form", currentCheckStructure);

            /* 2 cartas referencias personales  */
            DocumentCheck personalReferences = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 23, 39, 6,
                "2 cartas referencias personales", "2 letters of personal references", currentCheckStructure, 2);

            /* SOPORTE EDUCACIÓN Y FORMACIÓN */

            /* Autorización de  datos personales */
            DocumentCheck personalData = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 15, 40, 7,
                "Autorización de  datos personales", "Authorization of personal data", currentCheckStructure);

            /* Verificación de Estudios */
            DocumentCheck studiesVerification = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 24, 41, 7,
                "Verificación de estudios", "Verification of studies", currentCheckStructure);

            /* Fotocopia de la tarjeta profesional */
            DocumentCheck copyProffesionalCard = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 7, 42, 7,
                "Fotocopia de la tarjeta profesional", "Photocopy of professional card", currentCheckStructure);

            /* Certificados de estudios educación formal */
            DocumentCheck formalEducationCert = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 43, 7,
                "Certificados de estudios educación formal", "Certificates of formal education", currentCheckStructure);

            /* Certificados de educación no formal  */
            DocumentCheck nonFormalEducationCert = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 44, 7,
                "Certificados de educación no formal", "Certificates of non-formal education", currentCheckStructure);

            /* HOJA DE VIDA */

            /* Solicitud de personal */
            DocumentCheck staffRequest = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 18, 45, 8,
                "Solicitud de personal", "Personnel application", currentCheckStructure);

            /* Hoja de vida actualizada */
            DocumentCheck cv = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 1, 46, 8,
                "Hoja de vida actualizada", "Updated resume", currentCheckStructure);

            /* Documento de identidad al 150% */
            DocumentCheck idCardCopy = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 2, 47, 8,
                "Documento de identidad al 150%", "Identity document at 150%", currentCheckStructure);

            /* Fotocopia de pasaporte */
            DocumentCheck passportCopy = await _documentCheckService.ManualCheckValue(memberUser.CompanyUserId, candidateId, 48, 8,
                "Fotocopia de pasaporte", "Photocopy of passport", currentCheckStructure);

            /* Validación de antecedentes */
            DocumentCheck backgroundValidation = await _documentCheckService.AutomaticCheckHiringValue(memberUser.CompanyUserId, candidateId, 16, 49, 8,
                "Validación de antecedentes", "Background validation", currentCheckStructure);

            /* OTROS */

            /* Otros */
            DocumentCheck others = new DocumentCheck
            {
                OrderId = 50,
                CandidateId = candidateId,
                DocumentCheckGroupId = 9,
                DocumentCheckStateId = 2,
                IsCheck = false,
                IsEnabled = false,
                CompanyUserId = memberUser.CompanyUserId,
                Name = "Otros documentos",
                NameEnglish = "Other documents"
            };

            if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
            {
                foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                    if (group.DocumentCheckGroupId == 9 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                        foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                            if (item.OrderId == 50)
                            {

                                others.DocumentCheckId = item.DocumentCheckId;

                                others.Text = item.Text;

                                break;
                            }
            }
            else
            {
                if (await _documentCheckRepository.ExistByOrderId(50, memberUser.CompanyUserId))
                {
                    DocumentCheck oldCheck = await _documentCheckRepository.GetByCandidateIdAndOrderId(candidateId, 50, memberUser.CompanyUserId);

                    if (oldCheck != null)
                        if (!string.IsNullOrEmpty(oldCheck.Text))
                        {
                            others.DocumentCheckId = oldCheck.DocumentCheckId;

                            others.Text = oldCheck.Text;
                        }
                }
            }

            /**/

            List<DocumentCheck> documentChecksOld = await _documentCheckRepository.GetByCandidateIdAndLimitGroups(candidateId, memberUser.CompanyUserId, 4, 10);

            bool isSaved = true;

            newDocumentChecks.Add(contract);
            newDocumentChecks.Add(position);
            newDocumentChecks.Add(si);
            newDocumentChecks.Add(sgsst);
            newDocumentChecks.Add(arl);
            newDocumentChecks.Add(eps);
            newDocumentChecks.Add(compensationBox);
            newDocumentChecks.Add(medicalExamination);
            newDocumentChecks.Add(letterSupport);
            newDocumentChecks.Add(afpCert);
            newDocumentChecks.Add(epsCert);
            newDocumentChecks.Add(bankAccount);

            newDocumentChecks.Add(permormanceEval);
            newDocumentChecks.Add(induction);
            newDocumentChecks.Add(selectionReport);

            newDocumentChecks.Add(workReferencesVerification);
            newDocumentChecks.Add(workCert);
            newDocumentChecks.Add(personalReferencesVerification);
            newDocumentChecks.Add(personalReferences);

            newDocumentChecks.Add(personalData);
            newDocumentChecks.Add(studiesVerification);
            newDocumentChecks.Add(copyProffesionalCard);
            newDocumentChecks.Add(formalEducationCert);
            newDocumentChecks.Add(nonFormalEducationCert);

            newDocumentChecks.Add(staffRequest);
            newDocumentChecks.Add(cv);
            newDocumentChecks.Add(idCardCopy);
            newDocumentChecks.Add(passportCopy);
            newDocumentChecks.Add(backgroundValidation);

            newDocumentChecks.Add(others);

            if (documentChecksOld != null && documentChecksOld.Count > 0)
            {
                try
                {
                    //foreach (DocumentCheck check in documentChecksOld)
                    //    await _documentCheckRepository.Remove(check.DocumentCheckId);

                    for (int i = 0; i < documentChecksOld.Count; i++)
                    {
                        foreach (DocumentCheck newDocumentCheck in newDocumentChecks)
                        {
                            if(newDocumentCheck.OrderId == 50)
                            {

                            }

                            if (newDocumentCheck.OrderId == documentChecksOld[i].OrderId)
                            //if (newDocumentCheck.DocumentCheckId == documentChecksOld[i].DocumentCheckId)
                            {
                                newDocumentCheck.DocumentCheckId = documentChecksOld[i].DocumentCheckId;

                                await _documentCheckRepository.Remove(documentChecksOld[i].DocumentCheckId);

                                await _documentCheckRepository.Add(newDocumentCheck);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    isSaved = false;
                }
            }
            else
            {
                isSaved = await _documentCheckRepository.AddRange(newDocumentChecks);
            }

            if (isSaved)
            {
                if (documentCheckStructureDTO.DocumentCheckGroups != null && documentCheckStructureDTO.DocumentCheckGroups.Count > 0)
                {
                    foreach (DocumentCheckGroupDTO group in documentCheckStructureDTO.DocumentCheckGroups)
                    {
                        List<DocumentCheckDTO> listItems = new List<DocumentCheckDTO>();

                        if (group.DocumentCheckGroupId == 4)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(contract));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(position));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(si));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(sgsst));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(arl));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(eps));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(compensationBox));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(medicalExamination));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(letterSupport));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(afpCert));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(epsCert));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(bankAccount));
                        }

                        if (group.DocumentCheckGroupId == 5)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(permormanceEval));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(induction));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(selectionReport));
                        }

                        if (group.DocumentCheckGroupId == 6)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(workReferencesVerification));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(workCert));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(personalReferencesVerification));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(personalReferences));
                        }

                        if (group.DocumentCheckGroupId == 7)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(personalData));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(studiesVerification));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(copyProffesionalCard));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(formalEducationCert));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(nonFormalEducationCert));
                        }

                        if (group.DocumentCheckGroupId == 8)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(staffRequest));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(cv));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(idCardCopy));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(passportCopy));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(backgroundValidation));
                        }

                        if (group.DocumentCheckGroupId == 9)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(others));
                        }

                        group.DocumentCheckItems = listItems;
                    }

                    documentCheckStructureDTO.DocumentCheckGroups.Sort((x, y) => x.DocumentCheckGroupId.CompareTo(y.DocumentCheckGroupId));
                    documentCheckStructureDTO.CandidateId = candidateId;
                }

                return Ok(new { message = "Checks cambiados exitosamente", obj = documentCheckStructureDTO });
            }
            else
                return StatusCode(500, new { message = "No se pudieron actualizar los checks", obj = documentCheckStructureDTO });
        }

        [HttpGet("download/{candidateId}")]
        public async Task<FileResult> GetDocumentCheckFileByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                Candidate candidate = await _candidateRepository.GetByCandidateId(candidateId);

                int companyUserId = 0;

                if (candidate == null)
                    return null;

                if (memberUser != null)
                    companyUserId = memberUser.CompanyUserId;

                MemoryStream ms = await _PDFGenerator.CreateCheckDocumentReportPDFByHTML(candidate, companyUserId);

                FileContentResult result = new FileContentResult(ms.ToArray(), "application/pdf");
                result.FileDownloadName = "Listado de Verificacion Documentos de Ingreso.pdf";

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("downloadExcel/{candidateId}")]
        public async Task<FileResult> GetDocumentCheckFileExcelByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                Candidate candidate = await _candidateRepository.GetByCandidateId(candidateId);

                int companyUserId = 0;

                if (candidate == null)
                    return null;

                if (memberUser != null)
                    companyUserId = memberUser.CompanyUserId;

                MemoryStream ms = await _excelGenerator.CreateCheckDocumentReportExcelByHTML(candidate, companyUserId);

                FileContentResult result = new FileContentResult(ms.ToArray(), "application/vnd.ms-excel");
                result.FileDownloadName = "Listado de Verificacion Documentos de Ingreso.xlsx";

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
