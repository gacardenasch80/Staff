using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.ServicesCompany
{
    public interface IEventService
    {
        Task<List<EventOutDTO>> GetEventsByCandidateAndCompanyd(int candidateId, int companyUserId);
        Task<List<Event>> GetElementsByCandidateAndCompanyId(int candidateId, int companyUserId);
    }

    public class EventService
    (
        IEventRepository eventRepository,

        IPublicationTimeService publicationTimeService,

        IMapper mapper
    )
    :
    IEventService
    {
        private readonly IEventRepository _eventRepository = eventRepository;

        private readonly IPublicationTimeService _publicationTimeService = publicationTimeService;

        private readonly IMapper _mapper = mapper;

        public async Task<List<EventOutDTO>> GetEventsByCandidateAndCompanyd(int candidateId, int companyUserId)
        {
            List<Event> events = await GetElementsByCandidateAndCompanyId(candidateId, companyUserId);
            List<EventOutDTO> eventsDTO = _mapper.Map<List<Event>, List<EventOutDTO>>(events);

            if (eventsDTO != null && eventsDTO.Count > 0)
            {
                foreach (EventOutDTO eve in eventsDTO)
                {
                    eve.summary = eve.EventType.EventName + " el " + eve.StartDate.ToString("dd MMM yyyy").Replace(".", "") + " desde las " + eve.StartTime + " hasta las " + eve.EndingTime +
                    " (" + eve.TimeZoneEvent.GMT + ") " + eve.TimeZoneEvent.Name;

                    if(eve.Event_MemberUser != null && eve.Event_MemberUser.Count > 0)
                    {
                        foreach(Event_MemberUserDTO event_MemberUserDTO in eve.Event_MemberUser)
                        {
                            if (event_MemberUserDTO.MemberUser != null && string.IsNullOrEmpty(event_MemberUserDTO.MemberUser.Photo))
                                event_MemberUserDTO.MemberUser.Photo = null;
                        }
                    }
                }

                return eventsDTO;
            }

            return null;
        }

        public async Task<List<Event>> GetElementsByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            DateTime actualDate = _publicationTimeService.CreateServerDate();

            List<Event> events = await _eventRepository.GetEventsByCandidateAndCompanyId(candidateId, companyUserId, actualDate);

            return events;
        }
    }
}
