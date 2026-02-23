using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure.Services
{
    public interface IDataRegisterCountService
    {
        Task<int> GetDataPercentage(int candidateId);
    }
    public class DataRegisterCountService : IDataRegisterCountService
    {
        private readonly IBasicInformationRepository _basicInformationRepository;
        private readonly ICandidateLanguageRepository _candidateLanguageRepository;
        private readonly ILanguageOtherRepository _languageOtherRepository;
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IStudyRepository _studyRepository;
        private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IPersonalReferenceRepository _personalReferenceRepository;
        private readonly ICandidateTechnicalAbilityRepository _candidateTechnicalAbilityRepository;
        private readonly ICandidateSoftSkillRepository _candidateSoftSkillRepository;
        private readonly ICandidateLifePreferenceRepository _candidateLifePreferenceRepository;
        private readonly ICandidateJobPreferenceRepository _candidateJobPreferenceRepository;

        public DataRegisterCountService(IBasicInformationRepository basicInformationRepository,
            ICandidateLanguageRepository candidateLanguageRepository,
            ILanguageOtherRepository languageOtherRepository,
            IDescriptionRepository descriptionRepository,
            IStudyRepository studyRepository,
            IWorkExperienceRepository workExperienceRepository,
            IPersonalReferenceRepository personalReferenceRepository,
            ICandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository,
            ICandidateSoftSkillRepository candidateSoftSkillRepository,
            ICandidateLifePreferenceRepository candidateLifePreferenceRepository,
            ICandidateJobPreferenceRepository candidateJobPreferenceRepository)
        {
            _basicInformationRepository = basicInformationRepository;
            _candidateLanguageRepository = candidateLanguageRepository;
            _languageOtherRepository = languageOtherRepository;
            _descriptionRepository = descriptionRepository;
            _studyRepository = studyRepository;
            _workExperienceRepository = workExperienceRepository;
            _personalReferenceRepository = personalReferenceRepository;
            _candidateTechnicalAbilityRepository = candidateTechnicalAbilityRepository;
            _candidateSoftSkillRepository = candidateSoftSkillRepository;
            _candidateLifePreferenceRepository = candidateLifePreferenceRepository;
            _candidateJobPreferenceRepository = candidateJobPreferenceRepository;
        }

        public async Task<int> GetDataPercentage(int candidateId)
        {
            try
            {
                int percentage = 0;

                // Looks for Candidate Basic information - Value -> 30%
                BasicInformation basicInfo = await _basicInformationRepository.GetByCandidateId(candidateId);
                if (basicInfo != null)                
                    percentage += 30; // total -> 30

                // Looks for Candidate Studies - Value -> 20%
                List<Study> studies = await _studyRepository.GetByCandidateId(candidateId);
                if (studies.Count > 0)
                    percentage += 20; // total -> 50

                // Looks for Candidate Work Experience - Value -> 20%
                List<WorkExperience> experience = await _workExperienceRepository.GetByCandidateId(candidateId);
                if (experience.Count > 0)
                    percentage += 20; // total -> 70

                // Looks for Candidate Description - Value -> 6%
                Description description = await _descriptionRepository.GetByCandidateId(candidateId);
                if (description != null)
                    percentage += 6; // Total -> 76

                // Looks for Candidate Languages - Value -> 4%
                List<Candidate_Language> languages = await _candidateLanguageRepository.GetByCandidateId(candidateId);
                List<LanguageOther> candidatesLanguageOther = await _languageOtherRepository.GetByCandidateId(candidateId);
                if (languages.Count > 0 || candidatesLanguageOther.Count > 0)
                    percentage += 4; // Total -> 80

                // Looks for Candidate Personal References - Value -> 4%
                List<PersonalReference> references = await _personalReferenceRepository.GetByCandidateId(candidateId);
                if (references.Count > 0)
                    percentage += 4; // Total -> 84

                // Looks for Candidate Technical Abilities - Value -> 4%
                List<Candidate_TechnicalAbility> techAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateId(candidateId);
                if (techAbilities.Count > 0)
                    percentage += 4; // Total -> 88

                // Looks for Candidate Soft Skills - Value -> 4%
                List<Candidate_SoftSkill> softSkills = await _candidateSoftSkillRepository.GetByCandidateId(candidateId);
                if (softSkills.Count > 0)
                    percentage += 4; // Total -> 92

                // Looks for Candidate Life Preferences - Value -> 4%
                List<Candidate_LifePreference> lifePreferences = await _candidateLifePreferenceRepository.GetByCandidateId(candidateId, true);
                if (lifePreferences.Count > 0)
                    percentage += 4; // Total -> 96

                // Looks for Candidate Life Preferences - Value -> 4%
                List<Candidate_Wellness> wellness = await _candidateJobPreferenceRepository.GetWellnessByCandidateId(candidateId);
                List<Candidate_TimeAvailability> timeAvailabilities = await _candidateJobPreferenceRepository.GetTimeAvailabilityByCandidateId(candidateId);
                if (wellness.Count > 0 || timeAvailabilities.Count > 0)
                    percentage += 4; // Total -> 100

                return percentage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
