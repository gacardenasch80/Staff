using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class EventRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Event>(context), IEventRepository
    {
        public async Task<List<Event>> GetEventsByCandidateAndCompanyId(int candidateId, int companyUserId, DateTime date)
        {
            List<Event> events = await _entities
                .Where
                (
                    evnt
                    =>
                    evnt.CandidateId == candidateId
                    &&
                    evnt.CompanyUserId == companyUserId
                    &&
                    (
                        evnt.StartDate.Date >= date.Date
                        &&
                        date <= evnt.EndDate
                    )
                )
                .Include(evnt => evnt.EventType)
                .Include(evnt => evnt.TimeZoneEvent)
                .Include(evnt => evnt.Event_MemberUser).ThenInclude(event_memberUser => event_memberUser.MemberUser)
                .Include(evnt => evnt.Duration)
                .OrderBy(evnt => evnt.StartDate.Date).ThenBy(evnt => evnt.EndDate)
                .ToListAsync();

            return events;
        }
    }
}
