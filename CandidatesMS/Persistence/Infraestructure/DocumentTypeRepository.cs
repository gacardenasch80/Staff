using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Infraestructure
{
    public class DocumentTypeRepository : Repository<DocumentType>, IDocumentTypeRepository
    {
        //private readonly CandidateContext _context;
        //private readonly IMapper _mapper;

        //public DocumentTypeRepository(CandidateContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        public DocumentTypeRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<DocumentType> GetByGuid(string Guid)
        {
            DocumentType documentType = await _context.DocumentType.Where(x => x.DocumentTypeGuid == Guid).FirstOrDefaultAsync();
            
            return documentType;
        }

        public async Task<DocumentType> GetByDocumentTypeId(int documentTypeId)
        {
            var documentType = await _entities.Where(x => x.DocumentTypeId == documentTypeId).FirstOrDefaultAsync();

            return documentType;
        }

        public async Task<List<DocumentType>> GetAllWithOtherInEnd()
        {
            List<DocumentType> documentTypes = await _context.DocumentType.Where(x => x.DocumentTypeId != 4).ToListAsync();

            DocumentType otherDocumentType = await _context.DocumentType.Where(x => x.DocumentTypeId == 4).FirstOrDefaultAsync();

            documentTypes.Add(otherDocumentType);

            return documentTypes;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
