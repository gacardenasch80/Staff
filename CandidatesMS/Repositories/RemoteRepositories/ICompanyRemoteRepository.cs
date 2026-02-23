using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories.RemoteRepositories
{
    public interface ICompanyRemoteRepository
    {
        Task<TechnicalAbilityRemoteDTO> GetTechnicalAbilityById(int technicalAbilityId, string token);
        Task<JobProfessionRemoteDTO> GetJobProfessionById(int jobProfessionId, string token);
        Task<bool> DeletePostulationsByCandidateId(int candidateId, string token);
        Task<bool> DeletePostulationsById(int postulationId, string token);
        Task<bool> DeleteCandidate_TalentGroupsById(int candidate_talentGroupId, string token);
        Task<bool> DeleteFiledAndDeletedPostulationsByCandidateId(int candidateId, string token);
        Task<bool> AddAndAttachTagToCandidate(int candidateId, TagInDTO tagDTO, string token);
        Task<bool> AddAndAttachSourceToCandidate(int candidateId, SourceInDTO sourceDTO, string token);
        Task<bool> AddAndAttachEmailToMemberUser(DataMentionEmailDTO dataMentionEmailDTO, string token);
        Task<bool> AddSendEmailToCandidateFromCompany(MailSendOutDTO mailSendOutDTO, string token);
        Task<MemberByToken> GetResponseValidateActionByPermission(string validationString, string token);
        Task<bool> GetResponseValidateActionByPermissionNew(string validationString, string token);
        Task<List<TagListInDTO>> GetTagsByCompanyUser(int companyUserId, string token);
        Task<List<SourceListInDTO>> GetSourcesByCompanyUser(int companyUserId, string token);
        Task<MemberUserRemoteDTO> GetMemberUserById(int memberUserId, string token);
        Task<MemberUserRemoteDTO> GetMemberUserByEmail(string email, string token);
        Task<MemberByToken> GetMemberUserFromCandidate(string token);
        Task<MemberByToken> SendCodeEmailCandidate(CandidateDTO candidateDTO, int language);
        Task<List<Postulation>> GetPostulationsFromCandidate(string token, int id);
        Task<List<MemberByToken>> GetAllMemberUserByToken(string token);
        Task<bool> isMaster(string token);
        Task<List<PostulationJobNameInDTO>> GetAllPostulationsWithName(string token);
        Task<List<PostulationJobNameInDTO>> GetAllPostulationsWithNameAndColourFlag(string token);
        Task<List<Postulation>> GetPostulations(string token);
        Task<List<Candidate_TG>> GetCandidate_TalentGroups(string token);
        Task<List<CandidateTalentGroupNameInDTO>> GetAllCandidateTalentWithName(string token);
        Task<List<CandidateTalentGroupNameInDTO>> GetAllCandidateTalentWithNameAndColourFlag(string token);
        Task<bool> AddPostulationFromAnalyze(PostulationAnalyzeOutDTO postulationAnalyzeOutDTO, string token);
        Task<bool> AddTalentGroupFromAnalyze(TalentGroupAnalyzeOutDTO talentGroupAnalyzeOutDTO, string token);
        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetCandidateIdsFromJobId(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetCandidateIdsFromTalentGroupId(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromJobId(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromTalentGroupId(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<bool> ExsistCandidate_TagsByTagAndCandidateId(int tagId, int candidateId, string token);
        Task<bool> ExsistCandidate_SourcesBySourceAndCandidateId(int sourceId, int candidateId, string token);
        Task<CandidateIdAndTagResponseDTO> GetCandidateIdsFromTags(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<CandidateIdAndSourceResponseDTO> GetCandidateIdsFromSource(string token, SearchByIdAndTextWithPaginationDTO search);

        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromJobSearch(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<CandidateIdAndPostulationAndTGNumbersResponseDTO> GetAllCandidateIdsFromTalentGroupSearch(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<JobProffesionIdSearchResponseDTO> GetAllJobProfessionsIdFromSearch(string token, SearchByIdAndTextWithPaginationDTO search);
        Task<bool> AddNotificationFromRequest(NotificationDTO notificationOutDTO, int language);
        Task<bool> AddNotificationFromDeleteMember(NotificationDTO notificationOutDTO, int language, string token);
        Task<bool> AddNotificationFromDeleteMemberFromMaster(NotificationDTO notificationOutDTO, int language, string token);
        Task<bool> AddNotificationFromDeleteCandidateFromCandidate(NotificationDTO notificationOutDTO, int language, string token);
        Task<bool> AddNotificationFromDeleteHiringFileFromCandidate(NotificationAttachedFileDTO notificationOutDTO, string token);
        Task<bool> AddNotificationFromDeleteHiringFileByHASHFromCandidate(NotificationAttachedFileDTO notificationOutDTO, string token);
        Task<bool> AddNotificationEditCandidateEmailFromMaster(NotificationAttachedFileDTO notificationOutDTO, string token);
        Task<bool> AddNotificationEditCandidateDocumentFromMaster(NotificationAttachedFileDTO notificationOutDTO, string token);
        Task<JobIdNameDTO> GetJobMiniById(int jobid);
        Task<TalentGroupNameDTO> GetTalentGroupMiniById(int talentGroupId);

        Task<List<PostulationInDTO>> GetAllPostulationsByCompanyWithoutFiledJobs(string token, int candidateId);
        Task<List<PostulationQuestionsAnswersInDTO>> GetAnswersByCandidateIdOrderByPostulation(string token, int candidateId);
        Task<List<PostulationInDTO>> GetAllPostulationsByCompany(string token, int candidateId);
        Task<List<TalentGroupsInDTO>> GetAllTalentGroupsByCompany(string token, int candidateId);

        Task<List<CandidateTagInDTO>> GetAllCandidateTags();
        Task<List<CandidateTagInDTO>> GetAllCandidateTagsByCandidateId(string token, int candidateId);
        Task<List<CandidateSourceInDTO>> GetAllCandidateSources();
        Task<List<CandidateSourceInDTO>> GetAllCandidateSourcesByCandidateId(string token, int candidateId);
        Task<List<EventInDTO>> GetAllEventByCandidateId(string token, int candidateId);

        Task<bool> AddToDevDeployed(string candidateJSON, string token);
    }
}
