using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Entities;
using AutoMapper;
using CandidatesMS.RepositoriesCompany;

namespace CandidatesMS.ServicesCompany
{
    public interface IAnswerService
    {
        Task<List<PostulationQuestionsAnswersDTO>> GetAnswersByCandidateIdOrderByPostulation(Candidate candidate, int candidateId, int companyUserId);
    }

    public class AnswerService
    (
        IAnswerRepository answerRepository,
        IQuestionRepository questionRepository,

        IPostulationService postulationService,
        IPublicationTimeService publicationTimeService,

        IMapper mapper
    )
    : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository = answerRepository;
        private readonly IQuestionRepository _questionRepository = questionRepository;

        private readonly IPostulationService _postulationService = postulationService;
        private readonly IPublicationTimeService _publicationTimeService = publicationTimeService;

        private readonly IMapper _mapper = mapper;

        public async Task<List<PostulationQuestionsAnswersDTO>> GetAnswersByCandidateIdOrderByPostulation(Candidate candidate, int candidateId, int companyUserId)
        {
            int isMigrated = 0;
            bool isFromCompanyAndLogin = true;

            if (candidate != null)
            {
                isMigrated = candidate.IsMigrated;
                isFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
            }

            List<PostulationDTO> postulations = await _postulationService.GetAllByCandidateAndCompanyUserIdByCV(candidateId, companyUserId, isMigrated, isFromCompanyAndLogin);

            List<PostulationQuestionsAnswersDTO> postulationsWithQuestions = new List<PostulationQuestionsAnswersDTO>();

            if (postulations != null && postulations.Count > 0)
            {
                foreach (PostulationDTO postulation in postulations)
                {
                    List<Question> questions = await _questionRepository.GetAllQuestionsByJobIdWithAnswersByPostulationId(postulation.JobId, postulation.PostulationId);

                    if (questions != null && questions.Count > 0)
                    {
                        PostulationQuestionsAnswersDTO postulationWithQuestions = _mapper.Map<PostulationDTO, PostulationQuestionsAnswersDTO>(postulation);

                        postulationWithQuestions.Questions = _mapper.Map<List<Question>, List<QuestionDTO>>(questions);

                        foreach (QuestionDTO question in postulationWithQuestions.Questions)
                        {
                            List<Answer> answers = await _answerRepository.GetAllAnswersByQuestonIdIdAndPostulationId(question.QuestionId, postulation.PostulationId);

                            if (answers != null && answers.Count > 0)
                                question.Answers = _mapper.Map<List<Answer>, List<AnswerDTO>>(answers);

                        }

                        string postulationDateAux = postulation.PostulationDate.ToString("dd MMMM yyyy hh:mm:ss", new CultureInfo("es-CO"));
                        string postulationDateAuxEnglish = postulation.PostulationDate.ToString("dd MMMM yyyy hh:mm:ss", new CultureInfo("en-US"));

                        postulationWithQuestions.PostulationInfo = postulation.PostulationDate.ToString("dd MMMM yyyy", new CultureInfo("es-CO"));
                        postulationWithQuestions.PostulationInfoEnglish = postulation.PostulationDate.ToString("dd MMMM yyyy", new CultureInfo("en-US"));

                        postulationWithQuestions.PostulationToltip = postulationDateAux == "01/01/0001 12:00:00 a. m." || postulationDateAux == "01 enero 0001" ? "No existe fecha." : _publicationTimeService.GetCreationInfoPupEnglish(postulationDateAux);
                        postulationWithQuestions.PostulationToltipEnglish = postulationDateAuxEnglish = postulationDateAuxEnglish == "1/01/0001 12:00:00 a. m." || postulationDateAuxEnglish == "01 enero 0001" ? "No existe fecha." : _publicationTimeService.GetCreationInfoPupEnglish(postulationDateAuxEnglish);

                        postulationWithQuestions.JobName = postulation.Job.Name;

                        postulationsWithQuestions.Add(postulationWithQuestions);
                    }
                }
            }

            return postulationsWithQuestions;
        }
    }
}
