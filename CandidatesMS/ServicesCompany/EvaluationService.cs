using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.ServicesCompany
{
    public interface IEvaluationService
    {
        Task<List<EvaluationsResumeByJobOrTGId>> CalculatePercentEvaluationCriterias(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser);
        Task<List<EvaluationsResumeByJobOrTGId>> GroupEvaluationsByJobAndTalentGroup(List<Evaluation> evaluations, MemberUser memberUser);
        Task<List<EvaluationsResumeByJobOrTGId>> TotalEvaluationsByJobAndTalentGroupResume(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser);
        Task<List<EvaluationsResumeByJobOrTGId>> GetMemberUserEvaluations(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser);

        string GetEvaluationsAndInterviewersFormat(int evaluations, int interviewers);
        string GetEvaluationsAndInterviewersFormatEnglish(int evaluations, int interviewers);
    }

    public class EvaluationService
    (
        IEvaluationCriteriaRepository evaluationCriteriaRepository,
        IJobRepository jobRepository,
        ITalentGroupRepository talentGroupRepository,
        IEvaluationRepository evaluationRepository,
        IMemberUserRepository memberUserRepository,
        IPercentCriteriaRepository percentCriteriaRepository,

        IPublicationTimeService publicationTimeService,

        IMapper mapper
        )
        :
        IEvaluationService
    {
        private IEvaluationCriteriaRepository _evaluationCriteriaRepository = evaluationCriteriaRepository;
        private IJobRepository _jobRepository = jobRepository;
        private ITalentGroupRepository _talentGroupRepository = talentGroupRepository;
        private IEvaluationRepository _evaluationRepository = evaluationRepository;
        private IMemberUserRepository _memberUserRepository = memberUserRepository;
        private IPercentCriteriaRepository _percentCriteriaRepository = percentCriteriaRepository;

        private IPublicationTimeService _publicationTimeService = publicationTimeService;

        private IMapper _mapper = mapper;

        public async Task<List<EvaluationsResumeByJobOrTGId>> CalculatePercentEvaluationCriterias(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser)
        {
            PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(memberUser.CompanyUserId);

            int percentObjective = percentCriteria.PercentObjectiveValue;
            int percentSubjective = percentCriteria.PercentSubjectiveValue;

            if (evaluationsLists != null && evaluationsLists.Count > 0)
            {
                foreach (EvaluationsResumeByJobOrTGId evaluationsList in evaluationsLists)
                {
                    double totalValueObjective = 0;
                    double totalValueSubjective = 0;

                    evaluationsList.PercentObjecitve = percentObjective;
                    evaluationsList.PercentSubjective = percentSubjective;

                    if (evaluationsList != null && evaluationsList.ObjectiveCriterias != null && evaluationsList.ObjectiveCriterias.Count > 0)
                    {
                        foreach (EvaluationCriteriaDTO evaluationCriteria in evaluationsList.ObjectiveCriterias)
                        {
                            double valueAverage = (double)evaluationCriteria.Value / (double)evaluationCriteria.NumberTimes;

                            totalValueObjective += valueAverage * (double)evaluationCriteria.MaxPercent / 100;

                            double percent = valueAverage * (double)evaluationCriteria.MaxPercent / 100;

                            evaluationCriteria.Percent = Math.Round(percent, 2);

                            evaluationCriteria.PercentFormat = evaluationCriteria.Percent.ToString().Replace(",", ".") + "%";

                            if (valueAverage < 50)
                                evaluationCriteria.ColourFlag = 1;
                            if (valueAverage >= 50 && valueAverage < 75)
                                evaluationCriteria.ColourFlag = 2;
                            if (valueAverage >= 75)
                                evaluationCriteria.ColourFlag = 3;

                            evaluationsList.PercentObjecitveValue += evaluationCriteria.Percent;

                            evaluationCriteria.Value /= evaluationCriteria.NumberTimes;
                        }
                    }

                    if (evaluationsList != null && evaluationsList.SubjectiveCriterias != null && evaluationsList.SubjectiveCriterias.Count > 0)
                    {
                        foreach (EvaluationCriteriaDTO evaluationCriteria in evaluationsList.SubjectiveCriterias)
                        {
                            double valueAverage = evaluationCriteria.Value / (double)evaluationCriteria.NumberTimes;

                            totalValueSubjective += valueAverage * (double)evaluationCriteria.MaxPercent / 100;

                            double percent = valueAverage * (double)evaluationCriteria.MaxPercent / 100;

                            evaluationCriteria.Percent = Math.Round(percent, 2);

                            evaluationCriteria.PercentFormat = evaluationCriteria.Percent.ToString().Replace(",", ".") + "%";

                            if (valueAverage < 50)
                                evaluationCriteria.ColourFlag = 1;
                            if (valueAverage >= 50 && valueAverage < 75)
                                evaluationCriteria.ColourFlag = 2;
                            if (valueAverage >= 75)
                                evaluationCriteria.ColourFlag = 3;

                            evaluationsList.PercentSubjectiveValue += evaluationCriteria.Percent;

                            evaluationCriteria.Value /= evaluationCriteria.NumberTimes;
                        }
                    }

                    evaluationsList.PercentObjecitveAverage = Math.Round(evaluationsList.PercentObjecitveValue * percentCriteria.PercentObjectiveDecimal, 2);
                    evaluationsList.PercentSubjectiveAverage = Math.Round(evaluationsList.PercentSubjectiveValue * percentCriteria.PercentSubjectiveDecimal, 2);

                    evaluationsList.PercentObjecitveValue = Math.Round(evaluationsList.PercentObjecitveValue, 2);
                    evaluationsList.PercentSubjectiveValue = Math.Round(evaluationsList.PercentSubjectiveValue, 2);

                    evaluationsList.PercentObjecitveAverageFormat = evaluationsList.PercentObjecitveAverage.ToString().Replace(",", ".");
                    evaluationsList.PercentSubjectiveAverageFormat = evaluationsList.PercentSubjectiveAverage.ToString().Replace(",", ".");

                    evaluationsList.Percent = Math.Round(evaluationsList.PercentObjecitveAverage + evaluationsList.PercentSubjectiveAverage, 2);
                    evaluationsList.PercentFormat = evaluationsList.Percent.ToString().Replace(",", ".") + "%";

                    if (evaluationsList.Percent < 50)
                        evaluationsList.ColourFlag = 1;
                    if (evaluationsList.Percent >= 50 && evaluationsList.Percent < 75)
                        evaluationsList.ColourFlag = 2;
                    if (evaluationsList.Percent >= 75)
                        evaluationsList.ColourFlag = 3;
                }
            }

            return evaluationsLists;
        }

        public async Task<List<EvaluationsResumeByJobOrTGId>> GroupEvaluationsByJobAndTalentGroup(List<Evaluation> evaluations, MemberUser memberUser)
        {
            List<EvaluationsResumeByJobOrTGId> evaluationsLists = new List<EvaluationsResumeByJobOrTGId>();

            if (evaluations != null && evaluations.Count > 0)
            {
                foreach (Evaluation evaluation in evaluations)
                {
                    if (evaluation != null && evaluation.JobId != 0)
                    {
                        Job job = await _jobRepository.GetByJobId(evaluation.JobId);

                        if (evaluation.JobId != 0 && job != null && (job.JobPostingStatusId == 2 || job.JobPostingStatusId == 3) && !evaluationsLists.Any(x => x.JobId == evaluation.JobId))
                        {
                            EvaluationDTO evaluationDTO = _mapper.Map<Evaluation, EvaluationDTO>(evaluation);

                            bool memberDeleted = false;

                            MemberUser creatorMember = await _memberUserRepository.GetByEmail(evaluation.MemberUserEmail);

                            if (creatorMember == null)
                                memberDeleted = true;

                            evaluationDTO.MemberDeleted = memberDeleted;

                            EvaluationsResumeByJobOrTGId evaluationsResume = new EvaluationsResumeByJobOrTGId
                            {
                                JobId = evaluation.JobId,
                                CreationDateLastEvaluation = evaluation.CreationDate,
                                Name = job.Name,
                                Evaluations = 1,
                                Interviewers = 1,
                                EvaluationsJob = new List<EvaluationDTO>
                                    {
                                        evaluationDTO
                                    }
                            };

                            evaluationsLists.Add(evaluationsResume);
                        }
                        else if (evaluation.JobId != 0 && job != null && (job.JobPostingStatusId == 2 || job.JobPostingStatusId == 3) && evaluationsLists.Any(x => x.JobId == evaluation.JobId))
                        {
                            evaluationsLists.Where(x => x.JobId == evaluation.JobId).FirstOrDefault().Evaluations++;

                            if (evaluationsLists.Where(x => x.JobId == evaluation.JobId).FirstOrDefault().EvaluationsJob.All(x => x.MemberUserId != evaluation.MemberUserId))
                                evaluationsLists.Where(x => x.JobId == evaluation.JobId).FirstOrDefault().Interviewers++;

                            EvaluationDTO evaluationDTO = _mapper.Map<Evaluation, EvaluationDTO>(evaluation);

                            bool memberDeleted = false;

                            MemberUser creatorMember = await _memberUserRepository.GetByEmail(evaluation.MemberUserEmail);

                            if (creatorMember == null)
                                memberDeleted = true;

                            evaluationDTO.MemberDeleted = memberDeleted;

                            evaluationsLists.Where(x => x.JobId == evaluation.JobId).FirstOrDefault().EvaluationsJob.Add(evaluationDTO);

                            evaluationsLists.Where(x => x.JobId == evaluation.JobId).FirstOrDefault().EvaluationsJob.OrderByDescending(x => x.CreationDate);
                        }
                    }

                    if (evaluation != null && evaluation.TalentGroupId != 0)
                    {
                        TalentGroup talentGroup = await _talentGroupRepository.GetByTalentGroupId(evaluation.TalentGroupId);

                        if (evaluation.TalentGroupId != 0 && talentGroup != null && talentGroup.TalentGroupStatusId == 1 && !evaluationsLists.Any(x => x.TalentGroupId == evaluation.TalentGroupId))
                        {
                            EvaluationDTO evaluationDTO = _mapper.Map<Evaluation, EvaluationDTO>(evaluation);

                            bool memberDeleted = false;

                            MemberUser creatorMember = await _memberUserRepository.GetByEmail(evaluation.MemberUserEmail);

                            if (creatorMember == null)
                                memberDeleted = true;

                            evaluationDTO.MemberDeleted = memberDeleted;

                            EvaluationsResumeByJobOrTGId evaluationsResume = new EvaluationsResumeByJobOrTGId
                            {
                                TalentGroupId = evaluation.TalentGroupId,
                                CreationDateLastEvaluation = evaluation.CreationDate,
                                Name = talentGroup.Name,
                                Evaluations = 1,
                                Interviewers = 1,
                                EvaluationsTG = new List<EvaluationDTO>
                                    {
                                        evaluationDTO
                                    }
                            };

                            evaluationsLists.Add(evaluationsResume);
                        }
                        else if (evaluation.TalentGroupId != 0 && talentGroup != null && talentGroup.TalentGroupStatusId == 1 && evaluationsLists.Any(x => x.TalentGroupId == evaluation.TalentGroupId))
                        {
                            evaluationsLists.Where(x => x.TalentGroupId == evaluation.TalentGroupId).FirstOrDefault().Evaluations++;

                            if (evaluationsLists.Where(x => x.TalentGroupId == evaluation.TalentGroupId).FirstOrDefault().EvaluationsTG.All(x => x.MemberUserId != evaluation.MemberUserId))
                                evaluationsLists.Where(x => x.TalentGroupId == evaluation.TalentGroupId).FirstOrDefault().Interviewers++;

                            EvaluationDTO evaluationDTO = _mapper.Map<Evaluation, EvaluationDTO>(evaluation);

                            bool memberDeleted = false;

                            MemberUser creatorMember = await _memberUserRepository.GetByEmail(evaluation.MemberUserEmail);

                            if (creatorMember == null)
                                memberDeleted = true;

                            evaluationDTO.MemberDeleted = memberDeleted;

                            evaluationsLists.Where(x => x.TalentGroupId == evaluation.TalentGroupId).FirstOrDefault().EvaluationsTG.Add(evaluationDTO);

                            evaluationsLists.Where(x => x.TalentGroupId == evaluation.TalentGroupId).FirstOrDefault().EvaluationsTG.OrderByDescending(x => x.CreationDate);
                        }
                    }
                }
            }

            return evaluationsLists;
        }

        public async Task<List<EvaluationsResumeByJobOrTGId>> TotalEvaluationsByJobAndTalentGroupResume(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser)
        {
            PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(memberUser.CompanyUserId);

            int percentObjective = percentCriteria.PercentObjectiveValue;
            int percentSubjective = percentCriteria.PercentSubjectiveValue;

            if (evaluationsLists != null && evaluationsLists.Count > 0)
            {
                foreach (EvaluationsResumeByJobOrTGId evaluationList in evaluationsLists)
                {
                    int totalObjectiveCriteria = 0;
                    int totalSubjectiveCriteria = 0;

                    int totalEvaluations = 0;

                    double objectiveCriteriaPercent = 0;
                    double subjectiveCriteriaPercent = 0;

                    evaluationList.ObjectiveCriterias = new List<EvaluationCriteriaDTO>();
                    evaluationList.SubjectiveCriterias = new List<EvaluationCriteriaDTO>();

                    if (evaluationList != null && evaluationList.EvaluationsJob != null && evaluationList.EvaluationsJob.Count > 0)
                    {
                        foreach (EvaluationDTO evaluationDTO in evaluationList.EvaluationsJob)
                        {
                            Evaluation evaluation = await _evaluationRepository.GetEvaluationByIdWithCriterias(evaluationDTO.EvaluationId);

                            if (evaluation != null && evaluation.Evaluation_EvaluationCriteria != null && evaluation.Evaluation_EvaluationCriteria.Count > 0)
                            {
                                foreach (Evaluation_EvaluationCriteria evaluation_EvaluationCriteria in evaluation.Evaluation_EvaluationCriteria)
                                {
                                    EvaluationCriteria evaluationCriteria =
                                        await _evaluationCriteriaRepository.GetById(evaluation_EvaluationCriteria.EvaluationCriteriaId);

                                    if (evaluation_EvaluationCriteria != null && evaluationCriteria != null &&
                                        evaluationCriteria.EvaluationCriteriaTypeId == 1)
                                    {
                                        totalObjectiveCriteria += evaluation_EvaluationCriteria.Value;

                                        if (!evaluationList.ObjectiveCriterias.Any(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId))
                                        {
                                            EvaluationCriteriaDTO evaluationCriteriaDTO = _mapper.Map<EvaluationCriteria, EvaluationCriteriaDTO>
                                            (evaluationCriteria);

                                            evaluationCriteriaDTO.NumberTimes = 1;
                                            evaluationCriteriaDTO.Value = evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationCriteriaDTO.NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationCriteriaDTO.NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationCriteriaDTO.NumberTimesGreen++;

                                            evaluationList.ObjectiveCriterias.Add(evaluationCriteriaDTO);
                                        }
                                        else
                                        {
                                            evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                                .NumberTimes++;

                                            evaluationList.ObjectiveCriterias.
                                            FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                            .Value += evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesGreen++;
                                        }
                                    }

                                    if (evaluation_EvaluationCriteria != null && evaluationCriteria != null &&
                                        evaluation_EvaluationCriteria.EvaluationCriteriaTypeId == 2)
                                    {
                                        totalSubjectiveCriteria += evaluation_EvaluationCriteria.Value;

                                        if (!evaluationList.SubjectiveCriterias.Any(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId))
                                        {
                                            EvaluationCriteriaDTO evaluationCriteriaDTO = _mapper.Map<EvaluationCriteria, EvaluationCriteriaDTO>
                                            (evaluationCriteria);

                                            evaluationCriteriaDTO.NumberTimes = 1;
                                            evaluationCriteriaDTO.Value = evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationCriteriaDTO.NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationCriteriaDTO.NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationCriteriaDTO.NumberTimesGreen++;

                                            evaluationList.SubjectiveCriterias.Add(evaluationCriteriaDTO);
                                        }
                                        else
                                        {
                                            evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                                .NumberTimes++;

                                            evaluationList.SubjectiveCriterias.
                                            FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                            .Value += evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesGreen++;
                                        }
                                    }
                                }
                            }

                            totalEvaluations++;
                        }
                    }

                    if (evaluationList != null && evaluationList.EvaluationsTG != null && evaluationList.EvaluationsTG.Count > 0)
                    {
                        foreach (EvaluationDTO evaluationDTO in evaluationList.EvaluationsTG)
                        {
                            Evaluation evaluation = await _evaluationRepository.GetEvaluationByIdWithCriterias(evaluationDTO.EvaluationId);

                            if (evaluation != null && evaluation.Evaluation_EvaluationCriteria != null && evaluation.Evaluation_EvaluationCriteria.Count > 0)
                            {
                                foreach (Evaluation_EvaluationCriteria evaluation_EvaluationCriteria in evaluation.Evaluation_EvaluationCriteria)
                                {
                                    EvaluationCriteria evaluationCriteria =
                                        await _evaluationCriteriaRepository.GetById(evaluation_EvaluationCriteria.EvaluationCriteriaId);

                                    if (evaluation_EvaluationCriteria != null && evaluationCriteria != null &&
                                        evaluation_EvaluationCriteria.EvaluationCriteriaTypeId == 1)
                                    {
                                        totalObjectiveCriteria += evaluation_EvaluationCriteria.Value;

                                        if (!evaluationList.ObjectiveCriterias.Any(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId))
                                        {
                                            EvaluationCriteriaDTO evaluationCriteriaDTO = _mapper.Map<EvaluationCriteria, EvaluationCriteriaDTO>
                                            (evaluationCriteria);

                                            evaluationCriteriaDTO.NumberTimes = 1;
                                            evaluationCriteriaDTO.Value = evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationCriteriaDTO.NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationCriteriaDTO.NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationCriteriaDTO.NumberTimesGreen++;

                                            evaluationList.ObjectiveCriterias.Add(evaluationCriteriaDTO);
                                        }
                                        else
                                        {
                                            evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                                .NumberTimes++;

                                            evaluationList.ObjectiveCriterias.
                                            FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                            .Value += evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationList.ObjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesGreen++;
                                        }
                                    }

                                    if (evaluation_EvaluationCriteria != null && evaluationCriteria != null &&
                                        evaluationCriteria.EvaluationCriteriaTypeId == 2)
                                    {
                                        totalSubjectiveCriteria += evaluation_EvaluationCriteria.Value;

                                        if (!evaluationList.SubjectiveCriterias.Any(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId))
                                        {
                                            EvaluationCriteriaDTO evaluationCriteriaDTO = _mapper.Map<EvaluationCriteria, EvaluationCriteriaDTO>
                                            (evaluationCriteria);

                                            evaluationCriteriaDTO.NumberTimes = 1;
                                            evaluationCriteriaDTO.Value = evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationCriteriaDTO.NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationCriteriaDTO.NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationCriteriaDTO.NumberTimesGreen++;

                                            evaluationList.SubjectiveCriterias.Add(evaluationCriteriaDTO);
                                        }
                                        else
                                        {
                                            evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                                .NumberTimes++;

                                            evaluationList.SubjectiveCriterias.
                                            FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId)
                                            .Value += evaluation_EvaluationCriteria.Value;

                                            double percent = (double)evaluation_EvaluationCriteria.Value / (double)evaluationCriteria.MaxPercent * 100;

                                            if (percent < 50)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesRed++;
                                            if (percent >= 50 && percent < 75)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesYellow++;
                                            if (percent >= 75)
                                                evaluationList.SubjectiveCriterias.
                                                FirstOrDefault(x => x.EvaluationCriteriaId == evaluationCriteria.EvaluationCriteriaId).NumberTimesGreen++;
                                        }
                                    }
                                }
                            }

                            totalEvaluations++;
                        }
                    }

                    objectiveCriteriaPercent = totalObjectiveCriteria * percentCriteria.PercentObjectiveDecimal;
                    subjectiveCriteriaPercent = totalSubjectiveCriteria * percentCriteria.PercentSubjectiveDecimal;

                    evaluationList.Percent = (objectiveCriteriaPercent + subjectiveCriteriaPercent) / totalEvaluations;

                    double percentPerHundred = Math.Round(evaluationList.Percent, 1);

                    evaluationList.PercentFormat = percentPerHundred.ToString().Replace(",", ".") + "%";

                    if (evaluationList.Percent < 50)
                        evaluationList.ColourFlag = 1;
                    if (evaluationList.Percent >= 50 && evaluationList.Percent < 75)
                        evaluationList.ColourFlag = 2;
                    if (evaluationList.Percent >= 75)
                        evaluationList.ColourFlag = 3;

                    evaluationList.LastEvaluationFormat = _publicationTimeService.GetEvaluationsInfo(evaluationList.CreationDateLastEvaluation.ToString());
                    evaluationList.LastEvaluationFormatEnglish = _publicationTimeService.GetEvaluationsInfoEnglish(evaluationList.CreationDateLastEvaluation.ToString());

                    evaluationList.LastEvaluationToltip = _publicationTimeService.GetFileTypeCreationInfoPup(evaluationList.CreationDateLastEvaluation.ToString());
                    evaluationList.LastEvaluationToltipEnglish = _publicationTimeService.GetFileTypeCreationInfoPupEnglish(evaluationList.CreationDateLastEvaluation.ToString());

                    evaluationList.EvaluationsAndInterviewersFormat = GetEvaluationsAndInterviewersFormat(evaluationList.Evaluations, evaluationList.Interviewers);
                    evaluationList.EvaluationsAndInterviewersFormatEnglish = GetEvaluationsAndInterviewersFormatEnglish(evaluationList.Evaluations, evaluationList.Interviewers);
                }
            }

            return evaluationsLists;
        }

        public async Task<List<EvaluationsResumeByJobOrTGId>> GetMemberUserEvaluations(List<EvaluationsResumeByJobOrTGId> evaluationsLists, MemberUser memberUser)
        {
            if (evaluationsLists != null && evaluationsLists.Count > 0)
            {
                foreach (EvaluationsResumeByJobOrTGId evaluationsList in evaluationsLists)
                {

                    List<int> memberUsersIds = new List<int>();

                    evaluationsList.MemberUsers = new List<MemberUserDTO>();

                    if (evaluationsList != null && evaluationsList.EvaluationsJob != null && evaluationsList.EvaluationsJob.Count > 0)
                    {
                        foreach (EvaluationDTO evaluationDTO in evaluationsList.EvaluationsJob)
                        {
                            if (!memberUsersIds.Contains(evaluationDTO.MemberUserId))
                                memberUsersIds.Add(evaluationDTO.MemberUserId);
                        }
                    }

                    if (evaluationsList != null && evaluationsList.EvaluationsTG != null && evaluationsList.EvaluationsTG.Count > 0)
                    {
                        foreach (EvaluationDTO evaluationDTO in evaluationsList.EvaluationsTG)
                        {
                            if (!memberUsersIds.Contains(evaluationDTO.MemberUserId))
                                memberUsersIds.Add(evaluationDTO.MemberUserId);
                        }
                    }

                    if (memberUsersIds != null && memberUsersIds.Count > 0)
                    {
                        foreach (int memberUserId in memberUsersIds)
                        {
                            MemberUser memberUserFromId = await _memberUserRepository.GetById(memberUserId);

                            MemberUserDTO memberUserFromIdDTO = _mapper.Map<MemberUser, MemberUserDTO>(memberUserFromId);

                            EvaluationDTO evaluation = new EvaluationDTO
                            {
                                MemberDeleted = false
                            };

                            if (evaluationsList.EvaluationsJob != null && evaluationsList.EvaluationsJob.Count > 0)
                                evaluation = evaluationsList.EvaluationsJob.Where(x => x.MemberUserId == memberUserId).FirstOrDefault();

                            if (evaluation != null && evaluationsList.EvaluationsTG != null && evaluationsList.EvaluationsTG.Count > 0)
                                evaluation = evaluationsList.EvaluationsTG.Where(x => x.MemberUserId == memberUserId).FirstOrDefault();

                            string initials = "";
                            string fullName = "";

                            if (memberUserFromIdDTO != null && !string.IsNullOrEmpty(memberUserFromIdDTO.Name) && !string.IsNullOrEmpty(memberUserFromIdDTO.Surname))
                            {
                                char initialName = memberUserFromIdDTO.Name[0];
                                char initialSurnameName = memberUserFromIdDTO.Surname[0];

                                initials = (initialName + "" + initialSurnameName).ToUpper();

                                fullName = initialName.ToString().ToUpper() + memberUserFromIdDTO.Name.Substring(1).ToLower() +
                                    " " + initialSurnameName.ToString().ToUpper() + memberUserFromIdDTO.Surname.Substring(1).ToLower();
                            }
                            else if (memberUserFromIdDTO != null && !string.IsNullOrEmpty(memberUserFromIdDTO.Name) && string.IsNullOrEmpty(memberUserFromIdDTO.Surname))
                            {
                                char initialName = memberUserFromIdDTO.Name[0];
                                char secondName = memberUserFromIdDTO.Name[1];

                                initials = (initialName + "" + secondName).ToUpper();

                                fullName = initialName.ToString().ToUpper() + memberUserFromIdDTO.Name.Substring(1).ToLower();
                            }

                            if (memberUserFromIdDTO != null)
                            {
                                memberUserFromIdDTO.Initials = initials;
                                memberUserFromIdDTO.FullName = fullName;

                                memberUserFromIdDTO.MemberDeleted = evaluation.MemberDeleted;

                                evaluationsList.MemberUsers.Add(memberUserFromIdDTO);
                            }
                            else
                            {
                                MemberUserDTO memberUserEmpty = new MemberUserDTO
                                {
                                    MemberUserId = evaluation.MemberUserId,
                                    MemberDeleted = evaluation.MemberDeleted,
                                    FullName = evaluation.MemberUserName
                                };

                                evaluationsList.MemberUsers.Add(memberUserEmpty);
                            }
                        }
                    }
                }
            }

            return evaluationsLists;
        }       

        //

        public string GetEvaluationsAndInterviewersFormat(int evaluations, int interviewers)
        {
            return "Basado en " + evaluations + " evaluaciones de " + interviewers + " entrevistador(es)";
        }

        public string GetEvaluationsAndInterviewersFormatEnglish(int evaluations, int interviewers)
        {
            return "Based on " + evaluations + " evaluations from " + interviewers + " interviewer(s)";
        }
    }
}
