using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateCompanyController : ControllerBase
    {
        private ICandidateRepository _candidateRepository;

        private ICVRepository _CVRepository;
        private IDocumentCheckRepository _documentCheckRepository;
        private INoteRepository _noteRepository;
        private IEmailRepository _emailRepository;
        private IPhoneRepository _phoneRepository;
        private ISocialNetworkRepository _socialNetworkRepository;
        private IUserLinkRepository _userLinkRepository;
        private ICompanyDescriptionRepository _companyDescriptionRepository;
        private ICandidateSoftSkillRepository _candidateSoftSkillRepository;
        private ICandidateTechnicalAbilityRepository _candidateTechnicalAbilityRepository;
        private ICandidateLanguageRepository _candidateLanguageRepository;
        private ICandidateLanguageOtherRepository _candidateLanguageOtherRepository;
        private IStudyRepository _studyRepository;
        private IWorkExperienceRepository _workExperienceRepository;
        private IPersonalReferenceRepository _personalReferenceRepository;
        private ICandidateLifePreferenceRepository _candidateLifePreferenceRepository;
        private ICompanyCandidateJobPreferenceRepository _companyCandidateJobPreferenceRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IBasicInformationRepository _basicInformationRepository;

        private ICandidateCompanyRepository _candidateCompanyRepository;

        private IMemberUserRepository _memberUserRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CandidateCompanyController(ICandidateRepository candidateRepository, ICandidateCompanyRepository candidateCompanyRepository, ICVRepository CVRepository,
            IDocumentCheckRepository documentCheckRepository, INoteRepository noteRepository, IEmailRepository emailRepository, IPhoneRepository phoneRepository,
            ISocialNetworkRepository socialNetworkRepository, IUserLinkRepository userLinkRepository, ICompanyDescriptionRepository companyDescriptionRepository,
            ICandidateSoftSkillRepository candidateSoftSkillRepository, ICandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository,
            ICandidateLanguageRepository candidateLanguageRepository, ICandidateLanguageOtherRepository candidateLanguageOtherRepository, IStudyRepository studyRepository,
            IWorkExperienceRepository workExperienceRepository, IPersonalReferenceRepository personalReferenceRepository,
            ICandidateLifePreferenceRepository candidateLifePreferenceRepository, ICompanyCandidateJobPreferenceRepository companyCandidateJobPreferenceRepository,
            ICompanyRemoteRepository companyRemoteRepository, IAuthorizationHelper authorizationHelper, IMemberUserRepository memberUserRepository,
            IBasicInformationRepository basicInformationRepository,
            Services.IValidateMethodsService validateMethodsService, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _candidateCompanyRepository = candidateCompanyRepository;

            _CVRepository = CVRepository;
            _documentCheckRepository = documentCheckRepository;
            _noteRepository = noteRepository;
            _emailRepository = emailRepository;
            _phoneRepository = phoneRepository;
            _socialNetworkRepository = socialNetworkRepository;
            _userLinkRepository = userLinkRepository;
            _companyDescriptionRepository = companyDescriptionRepository;
            _candidateSoftSkillRepository = candidateSoftSkillRepository;
            _candidateTechnicalAbilityRepository = candidateTechnicalAbilityRepository;
            _candidateLanguageRepository = candidateLanguageRepository;
            _candidateLanguageOtherRepository = candidateLanguageOtherRepository;
            _studyRepository = studyRepository;
            _workExperienceRepository = workExperienceRepository;
            _personalReferenceRepository = personalReferenceRepository;
            _candidateLifePreferenceRepository = candidateLifePreferenceRepository;
            _companyCandidateJobPreferenceRepository = companyCandidateJobPreferenceRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _basicInformationRepository = basicInformationRepository;

            _memberUserRepository = memberUserRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> MigrateAllCandidateData()
        {
            try
            {
                List<Candidate> candidates = await _candidateRepository.GetAll();

                foreach (Candidate candidateAux in candidates)
                {
                    bool candidateExists = _candidateRepository.CandidateExistById(candidateAux.CandidateId);

                    if (!candidateExists)
                        return NotFound(new { message = "El candidato no existe" });

                    CandidateCompany candidateCompany = new CandidateCompany
                    {
                        CandidateId = candidateAux.CandidateId,
                        CompanyUserId = 4 // 3
                    };

                    Candidate candidate = await _candidateRepository.GetCandidateFullDataByCandidateId(candidateAux.CandidateId);

                    if (candidate.IsMigrated == 0)
                        continue;

                    candidateCompany.Document =
                        candidate.BasicInformation != null && candidate.BasicInformation.DocumentAdmin != null ? candidate.BasicInformation.DocumentAdmin : "";
                    candidateCompany.DocumentTypeId =
                        candidate.BasicInformation != null && candidate.BasicInformation.DocumentAdmin != null ? candidate.BasicInformation.DocumentTypeIdAdmin : 0;
                    candidateCompany.Address =
                        candidate.BasicInformation != null && candidate.BasicInformation.AddressAdmin != null ? candidate.BasicInformation.AddressAdmin : "";
                    candidateCompany.BirthDate =
                        candidate.BasicInformation != null && candidate.BasicInformation.BirthDateCompany != null ? candidate.BasicInformation.BirthDateCompany : "";
                    candidateCompany.HaveWorkExperience =
                        candidate.BasicInformation != null ? candidate.BasicInformation.HaveWorkExperienceFromCompany : 2;
                    candidateCompany.SalaryAspiration =
                        candidate.BasicInformation != null && candidate.BasicInformation.SalaryAspirationFromCompany != null ? candidate.BasicInformation.SalaryAspirationFromCompany : "";
                    candidateCompany.MaritalStatusId =
                        candidate.BasicInformation != null && candidate.BasicInformation.MaritalStatusCompanyId != null ? candidate.BasicInformation.MaritalStatusCompanyId : 0;
                    candidateCompany.GenderId =
                        candidate.BasicInformation != null && candidate.BasicInformation.GenderCompanyId != null ? candidate.BasicInformation.GenderCompanyId : 0;
                    candidateCompany.CurrencyId =
                        candidate.BasicInformation != null && candidate.BasicInformation.CurrencyIdFromCompany != null ? candidate.BasicInformation.CurrencyIdFromCompany : 0;
                    candidateCompany.Photo =
                        candidate.BasicInformation != null && candidate.BasicInformation.PhotoByAdmin != null ? candidate.BasicInformation.PhotoByAdmin : "";

                    bool isCreated = await _candidateCompanyRepository.Add(candidateCompany);

                    if (!isCreated)
                        return StatusCode(500, new { message = "No se pudo crear la información" });

                    /**/

                    candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateAux.CandidateId, candidateCompany.CompanyUserId);

                    List<CV> CVs = await _CVRepository.GetByCandidateAndFileTypeId(candidateAux.CandidateId, 8); // FileTypeId = 8
                    foreach (CV cv in CVs)
                    {
                        CV newCV = await _CVRepository.GetById(cv.CVId);

                        newCV.CompanyUserId = candidateCompany.CompanyUserId;

                        await _CVRepository.Update(newCV);
                    }

                    List<DocumentCheck> documentChecks = await _documentCheckRepository.GetAllByCandidateId(candidateAux.CandidateId, candidateCompany.CompanyUserId);
                    foreach (DocumentCheck documentCheck in documentChecks)
                    {
                        DocumentCheck newdocumentCheck = await _documentCheckRepository.GetById(documentCheck.DocumentCheckId);

                        newdocumentCheck.CompanyUserId = candidateCompany.CompanyUserId;

                        await _documentCheckRepository.Update(newdocumentCheck);
                    }

                    List<Note> notes = await _noteRepository.GetByCandidateId(candidateAux.CandidateId);
                    foreach (Note note in notes)
                    {
                        Note newNote = await _noteRepository.GetById(note.NoteId);

                        newNote.CompanyUserId = candidateCompany.CompanyUserId;

                        await _noteRepository.Update(newNote);
                    }

                    if (candidate.BasicInformation != null)
                    {
                        List<Email> emails = await _emailRepository.GetByBasicInfoIdAsync(candidate.BasicInformation.BasicInformationId);
                        foreach (Email email in emails)
                        {
                            Email newEmail = await _emailRepository.GetById(email.EmailId);

                            newEmail.CompanyUserId = candidateCompany.CompanyUserId;

                            await _emailRepository.Update(newEmail);
                        }

                        List<Phone> phones = await _phoneRepository.GetByBasicInformationId(candidate.BasicInformation.BasicInformationId);
                        foreach (Phone phone in phones)
                        {
                            Phone newPhone = await _phoneRepository.GetById(phone.PhoneId);

                            newPhone.CompanyUserId = candidateCompany.CompanyUserId;

                            await _phoneRepository.Update(newPhone);
                        }

                        List<SocialNetwork> socialNetworks = await _socialNetworkRepository.GetByBasicInfoIdAsync(candidate.BasicInformation.BasicInformationId);
                        foreach (SocialNetwork socialNetwork in socialNetworks)
                        {
                            SocialNetwork newSocialNetwork = await _socialNetworkRepository.GetById(socialNetwork.SocialNetworkId);

                            newSocialNetwork.CompanyUserId = candidateCompany.CompanyUserId;

                            await _socialNetworkRepository.Update(newSocialNetwork);
                        }

                        List<UserLink> userLinks = await _userLinkRepository.GetByBasicInfoIdAsync(candidate.BasicInformation.BasicInformationId);
                        foreach (UserLink userLink in userLinks)
                        {
                            UserLink newuserLink = await _userLinkRepository.GetById(userLink.UserLinkId);

                            newuserLink.CompanyUserId = candidateCompany.CompanyUserId;

                            await _userLinkRepository.Update(newuserLink);
                        }
                    }

                    CompanyDescription candidate_Language = await _companyDescriptionRepository.GetByCandidateId(candidate.CandidateId);
                    if (candidate_Language != null)
                    {
                        CompanyDescription newdescription = await _companyDescriptionRepository.GetById(candidate_Language.CompanyDescriptionId);

                        newdescription.CompanyUserId = candidateCompany.CompanyUserId;

                        await _companyDescriptionRepository.Update(newdescription);
                    }

                    List<Candidate_SoftSkill> candidate_SoftSkills = await _candidateSoftSkillRepository.GetByCandidateId(candidate.CandidateId);
                    foreach (Candidate_SoftSkill candidate_SoftSkill in candidate_SoftSkills)
                    {
                        if (candidate_SoftSkill.IsFromEmpresaAdded == true)
                        {
                            Candidate_SoftSkill newCandidate_SoftSkill = await _candidateSoftSkillRepository.GetById(candidate_SoftSkill.Candidate_SoftSkillId);

                            newCandidate_SoftSkill.CompanyUserId = candidateCompany.CompanyUserId;

                            await _candidateSoftSkillRepository.Update(newCandidate_SoftSkill);
                        }
                    }

                    List<Candidate_TechnicalAbility> candidate_TechnicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateId(candidate.CandidateId);
                    foreach (Candidate_TechnicalAbility candidate_TechnicalAbility in candidate_TechnicalAbilities)
                    {
                        if (candidate_TechnicalAbility.IsFromEmpresaAdded == true)
                        {
                            Candidate_TechnicalAbility newCandidate_TechnicalAbility = await _candidateTechnicalAbilityRepository.GetById(candidate_TechnicalAbility.Candidate_TechnicalAbilityId);

                            newCandidate_TechnicalAbility.CompanyUserId = candidateCompany.CompanyUserId;

                            await _candidateTechnicalAbilityRepository.Update(newCandidate_TechnicalAbility);
                        }
                    }

                    List<Candidate_LanguageOther> candidate_LanguagesOther = await _candidateLanguageOtherRepository.GetByCandidateEmail(candidate.Email);
                    foreach (Candidate_LanguageOther candidate_LanguageOther in candidate_LanguagesOther)
                    {
                        if (candidate_LanguageOther.AdminView)
                        {
                            Candidate_LanguageOther newCandidate_LanguageOther = await _candidateLanguageOtherRepository.GetById(candidate_Language.CompanyDescriptionId);

                            newCandidate_LanguageOther.CompanyUserId = candidateCompany.CompanyUserId;

                            await _candidateLanguageOtherRepository.Update(newCandidate_LanguageOther);
                        }
                    }

                    List<Study> studies = await _studyRepository.GetByCandidateId(candidate.CandidateId);
                    foreach (Study study in studies)
                    {
                        if (!study.IsFromCandidate)
                        {
                            Study newCStudy = await _studyRepository.GetById(study.StudyId);

                            newCStudy.CompanyUserId = candidateCompany.CompanyUserId;

                            await _studyRepository.Update(newCStudy);
                        }
                    }

                    List<WorkExperience> workExperiences = await _workExperienceRepository.GetByCandidateId(candidate.CandidateId);
                    foreach (WorkExperience workExperience in workExperiences)
                    {
                        if (workExperience.AdminView)
                        {
                            WorkExperience newWorkExperience = await _workExperienceRepository.GetById((int)workExperience.WorkExperienceId);

                            newWorkExperience.CompanyUserId = candidateCompany.CompanyUserId;

                            await _workExperienceRepository.Update(newWorkExperience);
                        }
                    }

                    List<PersonalReference> personalReferences = await _personalReferenceRepository.GetByCandidateId(candidate.CandidateId);
                    foreach (PersonalReference personalReference in personalReferences)
                    {
                        if (personalReference.IsAddefromCompany == true)
                        {
                            PersonalReference newPersonalReference = await _personalReferenceRepository.GetById((int)personalReference.PersonalReferenceId);

                            personalReference.CompanyUserId = candidateCompany.CompanyUserId;

                            await _personalReferenceRepository.Update(personalReference);
                        }
                    }

                    List<Candidate_LifePreference> candidate_LifePreferences = await _candidateLifePreferenceRepository.GetByCandidateId(candidate.CandidateId, false);
                    foreach (Candidate_LifePreference candidate_LifePreference in candidate_LifePreferences)
                    {
                        if (!candidate_LifePreference.IsFromCandidate)
                        {
                            Candidate_LifePreference newLifePreference = await _candidateLifePreferenceRepository.GetById((int)candidate_LifePreference.Candidate_LifePreferenceId);

                            newLifePreference.CompanyUserId = candidateCompany.CompanyUserId;

                            await _candidateLifePreferenceRepository.Update(newLifePreference);
                        }
                    }

                    //List<Company_Candidate_TimeAvailability> company_Candidate_TimeAvailabilities =
                    //    await _companyCandidateJobPreferenceRepository.GetCompanyCandidateTimeAvailabilityByCandidateId(candidate.CandidateId);
                    //foreach (Company_Candidate_TimeAvailability company_Candidate_TimeAvailability in company_Candidate_TimeAvailabilities)
                    //{
                    //    Company_Candidate_TimeAvailability newCompany_Candidate_Time = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateTimeAvailabilityByIds(candidateAux.CandidateId, company_Candidate_TimeAvailability.Company_Candidate_TimeAvailabilityId);

                    //    newCompany_Candidate_Time.CompanyUserId = candidateCompany.CompanyUserId;

                    //    _companyCandidateJobPreferenceRepository.UpdateCompanyCandidateTimeByIds(newCompany_Candidate_Time);

                    //    await Task.Delay(200);
                    //}

                    //List<Company_Candidate_Wellness> company_Candidate_Wellnesses =
                    //    await _companyCandidateJobPreferenceRepository.GetCompanyCandidateWellnessByCandidateId(candidate.CandidateId);
                    //foreach (Company_Candidate_Wellness company_Candidate_Wellness in company_Candidate_Wellnesses)
                    //{
                    //    Company_Candidate_Wellness newCompany_Candidate_Wellness = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateWellnessByIds(candidateAux.CandidateId, company_Candidate_Wellness.Company_Candidate_WellnessId);

                    //    newCompany_Candidate_Wellness.CompanyUserId = candidateCompany.CompanyUserId;

                    //    _companyCandidateJobPreferenceRepository.UpdateCompanyCandidateWellnessByIds(newCompany_Candidate_Wellness);

                    //    await Task.Delay(200);
                    //}
                }

                return Ok(new { message = "Candidato consultado exitosamente", obj = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getByIds/{candidateId}/{companyUserId}")]
        public async Task<IActionResult> GetCandidateCompanyDataByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            try
            {
                StringValues values = "";

                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "OpenCV";

                var isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

                if (!candidateExists)
                    return NotFound(new { message = "El candidato no existe" });

                Candidate candidate = await _candidateRepository.GetCandidateFullDataByCandidateId(candidateId);

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, companyUserId );

                return Ok(new { message = "Información consultada exitosamente", obj = candidateCompany });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("createNationalityFromCandidateAndCompany/{candidateId}")]
        public async Task<IActionResult> CreateNationalityFromCandidateAndCompany(int candidateId, [FromBody] CandidateCompany candidateCompany)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompanyFromDB = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                int oldCOuntry = 0;

                int.TryParse(candidateCompanyFromDB.Country, out oldCOuntry);

                candidateCompanyFromDB.Country = candidateCompany.Country;
                candidateCompanyFromDB.State = candidateCompany.State;
                candidateCompanyFromDB.City = candidateCompany.City;

                bool isUpdated = await _candidateCompanyRepository.Update(candidateCompanyFromDB);

                if(isUpdated)
                {
                    if(string.IsNullOrEmpty(candidateCompany.Country) || candidateCompany.Country == "0")
                        return StatusCode(200, new { message = "Nacionalidad eliminada correctamente" });

                    if (oldCOuntry != 0)
                        return StatusCode(200, new { message = "Nacionalidad creada correctamente" });

                    return StatusCode(200, new { message = "Nacionalidad editada correctamente" });
                }

                if(oldCOuntry != 0)
                    return StatusCode(400, new { message = "No se pudo crear la nacionalidad" });

                return StatusCode(400, new { message = "No se pudo editar la nacionalidad" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migrateLocationFromAnalysis")]
        public async Task<bool> MigrateLocationFromAnalysis()
        {
            try
            {
                List<Candidate> candidates = await _candidateRepository.GetAll();

                if (candidates != null && candidates.Count > 0)
                {
                    foreach (Candidate candidate in candidates)
                    {
                        if (candidate.IsMigrated == 4)
                        {
                            BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidate.CandidateId);

                            List<CandidateCompany> candidateCompanies = await _candidateCompanyRepository.GetByCandidateId(candidate.CandidateId);

                            try
                            {
                                if (candidateCompanies != null && candidateCompanies.Count > 0)
                                {
                                    int i = 0;

                                    foreach (CandidateCompany candidateCompany in candidateCompanies)
                                    {
                                        if(!string.IsNullOrEmpty(basicInformation.Country) &&
                                           !string.IsNullOrEmpty(basicInformation.State) &&
                                           !string.IsNullOrEmpty(basicInformation.City) &&
                                           string.IsNullOrEmpty(candidateCompany.Country) || candidateCompany.Country == "0")
                                        {
                                            try
                                            {
                                                candidateCompany.Country = basicInformation.Country;
                                                candidateCompany.State = basicInformation.State;
                                                candidateCompany.City = basicInformation.City;

                                                bool isUpdateCandidateCompany = await _candidateCompanyRepository.Update(candidateCompany);

                                                if (i == candidateCompanies.Count - 1)
                                                {
                                                    basicInformation.Country = string.Empty;
                                                    basicInformation.State = string.Empty;
                                                    basicInformation.City = string.Empty;

                                                    bool isUpdateBasicInformation = await _basicInformationRepository.Update(basicInformation);
                                                }
                                            }
                                            catch(Exception)
                                            {
                                                i++;

                                                continue;
                                            }

                                            i++;
                                        }
                                    }
                                }
                            }
                            catch(Exception)
                            {
                                continue;
                            }
                        }
                    }
                }

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        [HttpPatch("isPotential")]
        public async Task<IActionResult> ChangeIsPotentialState(CandidateCompanyIsPotential candidateCompanyIsPotential)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "ViewPotentialCandidates";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());

                if (!isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(404, new { message = "No existe el usuario empresa." });

                int companyUserId = memberUser.CompanyUserId;

                Candidate candidate = await _candidateRepository.GetByCandidateId(candidateCompanyIsPotential.CandidateId);

                if (candidate == null)
                    return StatusCode(404, new { message = "No existe candidato." });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidate.CandidateId, companyUserId);

                if (candidateCompany == null)
                    return StatusCode(404, new { message = "No existe información asociada al candidato y la empresa." });

                candidateCompany.IsPotential = candidateCompanyIsPotential.IsPotential;

                bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                if (isUpdated)
                    return StatusCode(200, new { message = "Candidato editado correctamente" });
                else
                    return StatusCode(400, new { message = "No se pudo editar la información." });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
