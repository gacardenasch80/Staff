using AutoMapper;
using CandidatesMS.Mapping;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CandidatesMS.Repositories;
using CandidatesMS.Persistence.Infraestructure;

namespace CandidatesMS.Infraestructure
{
    public class CandidateJobPreferenceRepository : Repository<Candidate_Wellness>, ICandidateJobPreferenceRepository
    {
        public CandidateJobPreferenceRepository(CandidateContext context) : base(context)
        {
        }

        #region Candidate Wellness

        /// <summary>
        /// Get Candidate Wellness List by Candidate ID
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public async Task<List<Candidate_Wellness>> GetWellnessByCandidateId(int candidateId)
        {
            //List<Candidate_Wellness> candidateWellness = await _context.Candidate_Wellness
            List<Candidate_Wellness> candidateWellness = await _entities
            .Where(x => x.CandidateId == candidateId)
            .Include(x => x.Wellness)
            .AsNoTracking()
            .ToListAsync();

            return candidateWellness;
        }

        /// <summary>
        /// Get All Wellness
        /// </summary>
        /// <returns></returns>
        public async Task<List<Wellness>> GetAllWellness()
        {
            List<Wellness> wellness = await _context.Wellness.ToListAsync();
            return wellness; 
        }

        /// <summary>
        /// Get Candidate Wellness by Candidate Id and Wellness Id
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="wellnessId"></param>
        /// <returns></returns>
        public async Task<Candidate_Wellness> GetCandidateWellnessByIds(int candidateId, int wellnessId)
        {
            Candidate_Wellness candidateWellness = await _context.Candidate_Wellness
                .Where(x => x.CandidateId == candidateId && x.WellnessId == wellnessId).FirstOrDefaultAsync();

            return candidateWellness;
        }

        /// <summary>
        /// Add Candidate New Wellness and remove Old ones
        /// </summary>
        /// <param name="wellness"></param>
        /// <returns></returns>
        public async Task<bool> AddWellness(int candidateId, List<Candidate_Wellness> wellness)
        {
            // Get old records from DataBase
            List<Candidate_Wellness> oldWellness = await _context.Candidate_Wellness.Where(x => x.CandidateId == candidateId).ToListAsync();

            // Delete old records from Database
            if (oldWellness.Count > 0)
                _context.RemoveRange(oldWellness);

            // Add new records to Database
            await _context.Candidate_Wellness.AddRangeAsync(wellness);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        /// <summary>
        /// Remove Candidate Wellness by entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Candidate_Wellness> RemoveWellness(Candidate_Wellness candidateWellness)
        {
            _entities.Remove(candidateWellness);
            var states = await _context.SaveChangesAsync();
            if (states != 0)
                return candidateWellness;

            return null;
        }

        #endregion


        #region Candidate Time Availability

        /// <summary>
        /// Get Candidate Time Availability List by Candidate ID
        /// </summary>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public async Task<List<Candidate_TimeAvailability>> GetTimeAvailabilityByCandidateId(int candidateId)
        {
            List<Candidate_TimeAvailability> candidateTimeAvailabilities = await _context.Candidate_TimeAvailability
            //List<Candidate_TimeAvailability> candidateTimeAvailabilities = await _entities
            .Where(x => x.CandidateId == candidateId)
            .Include(x => x.TimeAvailability)
            .AsNoTracking()
            .ToListAsync();

            return candidateTimeAvailabilities;
        }

        /// <summary>
        /// Get All Time Availabilities
        /// </summary>
        /// <returns></returns>
        public async Task<List<TimeAvailability>> GetAllTimeAvailabilities()
        {
            List<TimeAvailability> timeAvailabilities = await _context.TimeAvailability.ToListAsync();
            return timeAvailabilities;
        }

        /// <summary>
        /// Get Candidate Time Availability by Candidate Id and Wellness Id
        /// </summary>
        /// <param name="candidateId"></param>
        /// <param name="wellnessId"></param>
        /// <returns></returns>
        public async Task<Candidate_TimeAvailability> GetCandidateTimeAvailabilityByIds(int candidateId, int timeAvailabilityId)
        {
            Candidate_TimeAvailability candidateTimeAvailability = await _context.Candidate_TimeAvailability
                .Where(x => x.CandidateId == candidateId && x.TimeAvailabilityId == timeAvailabilityId).FirstOrDefaultAsync();

            return candidateTimeAvailability;
        }

        // <summary>
        /// Add Candidate Time Availabilities
        /// </summary>
        /// <param name="wellness"></param>
        /// <returns></returns>
        public async Task<bool> AddTimeAvailabilities(int candidateId, List<Candidate_TimeAvailability> timeAvailabilities)
        {
            // Get old records from DataBase
            List<Candidate_TimeAvailability> oldTimeAvailabilities = await _context.Candidate_TimeAvailability.Where(x => x.CandidateId == candidateId).ToListAsync();

            // Delete old records from Database
            if (oldTimeAvailabilities.Count > 0)
                _context.RemoveRange(oldTimeAvailabilities);

            // Add new records to Database
            await _context.Candidate_TimeAvailability.AddRangeAsync(timeAvailabilities);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        /// <summary>
        /// Remove Candidate Time Availability by entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Candidate_TimeAvailability> RemoveTimeAvailability(Candidate_TimeAvailability candidateTimeAvailability)
        {
            _context.Candidate_TimeAvailability.Remove(candidateTimeAvailability);
            var states = await _context.SaveChangesAsync();
            if (states != 0)
                return candidateTimeAvailability;

            return null;
        }

        #endregion

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
