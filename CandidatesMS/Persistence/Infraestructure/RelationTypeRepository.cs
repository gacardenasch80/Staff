using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class RelationTypeRepository : Repository<RelationType>, IRelationTypeRepository
    {
        public RelationTypeRepository(CandidateContext context) : base(context)
        {

        }
    }
}
