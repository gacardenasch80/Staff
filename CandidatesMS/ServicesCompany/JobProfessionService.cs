using AutoMapper;
using CandidatesMS.ModelsCompany;
using System.Threading.Tasks;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;

namespace CandidatesMS.ServicesCompany
{
    public interface IJobProfessionService
    {
        Task<JobProfessionDTO> GetJobProfessionById(int jobProfessionId);
    }

    public class JobProfessionService
    (
        IJobProfessionRepository jobProfessionRepository,

        IMapper mapper
    )
    :
    IJobProfessionService
    {
        private readonly IJobProfessionRepository _jobProfessionRepository = jobProfessionRepository;

        private readonly IMapper _mapper = mapper;

        public async Task<JobProfessionDTO> GetJobProfessionById(int jobProfessionId)
        {
            JobProfession jobProfession = await _jobProfessionRepository.GetById(jobProfessionId);

            JobProfessionDTO jobProfessionDTO = _mapper.Map<JobProfession, JobProfessionDTO>(jobProfession);

            if (jobProfessionDTO != null)
                return jobProfessionDTO;

            return new JobProfessionDTO();
        }
    }
}
