using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Infraestructure;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IDocumentCheckService
    {
        Task<DocumentCheck> AutomaticCheckValue(int companyUserId, int candidateId, int fileTypeId, int orderId, int documentGroupId,
            string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure);

        Task<DocumentCheck> ManualCheckValue(int companyUserId, int candidateId, int orderId, int documentGroupId,
            string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure);

        Task<DocumentCheck> AutomaticCheckHiringValue(int companyUserId, int candidateId, int fileTypeId, int orderId, int documentGroupId,
            string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure, int minDocs = 1);
    }

    public class DocumentCheckService : IDocumentCheckService
    {

        private IAttachedFileRepository _attachedFileRepository;
        private IAttachedFileHiringRepository _attachedFileHiringRepository;
        private IDocumentCheckRepository _documentCheckRepository;

        public DocumentCheckService(IAttachedFileRepository attachedFileRepository, IAttachedFileHiringRepository attachedFileHiringRepository, IDocumentCheckRepository documentCheckRepository)
        {
            _attachedFileRepository = attachedFileRepository;
            _attachedFileHiringRepository = attachedFileHiringRepository;
            _documentCheckRepository = documentCheckRepository;
        }

        public async Task<DocumentCheck> AutomaticCheckValue(int companyUserId, int candidateId, int fileTypeId, int orderId, int documentGroupId,
            string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure)
        {
            List<AttachedFile> documentTypeFiles =
                await _attachedFileRepository.GetByFileTypeAndCompanyIdOrOwnAndCandidateId(candidateId, companyUserId, fileTypeId);

            DocumentCheck documentType = new DocumentCheck
            {
                OrderId = orderId,
                CandidateId = candidateId,
                DocumentCheckGroupId = documentGroupId,
                DocumentCheckStateId = 1,
                IsCheck = false,
                IsEnabled = false,
                CompanyUserId = companyUserId,
                Name = name,
                NameEnglish = nameEnglish
            };

            if (documentTypeFiles != null && documentTypeFiles.Count > 0)
                documentType.IsCheck = true;

            //if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
            //{
            //    foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
            //        if (group.DocumentCheckGroupId == documentGroupId && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
            //            foreach (DocumentCheckDTO item in group.DocumentCheckItems)
            //                if (item.OrderId == orderId)
            //                    documentType.DocumentCheckId = item.DocumentCheckId;
            //}
            //else
            //{
            //    if (await _documentCheckRepository.ExistByOrderId(orderId, companyUserId))
            //    {
            //        DocumentCheck oldCheck = await _documentCheckRepository.GetByCandidateIdAndOrderId(candidateId, orderId, companyUserId);

            //        if (oldCheck != null)
            //            documentType.DocumentCheckId = oldCheck.DocumentCheckId;
            //    }
            //}

            return documentType;
        }

        public async Task<DocumentCheck> ManualCheckValue(int companyUserId, int candidateId, int orderId, int documentGroupId, string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure)
        {
            DocumentCheck documentType = new DocumentCheck
            {
                OrderId = orderId,
                CandidateId = candidateId,
                DocumentCheckGroupId = documentGroupId,
                DocumentCheckStateId = 1,
                IsCheck = false,
                IsEnabled = true,
                CompanyUserId = companyUserId,
                Name = name,
                NameEnglish = nameEnglish
            };

            if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
            {
                foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                    if (group.DocumentCheckGroupId == documentGroupId && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                        foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                            if (item.OrderId == orderId)
                            {
                                documentType.DocumentCheckId = item.DocumentCheckId;
                                documentType.IsCheck = item.IsCheck;
                            }
            }
            else
            {
                if (await _documentCheckRepository.ExistByOrderId(orderId, companyUserId))
                {
                    DocumentCheck oldCheck = await _documentCheckRepository.GetByCandidateIdAndOrderId(candidateId, orderId, companyUserId);

                    if (oldCheck != null)
                    {
                        documentType.DocumentCheckId = oldCheck.DocumentCheckId;
                        documentType.IsCheck = oldCheck.IsCheck;
                    }
                }
            }

            return documentType;
        }

        public async Task<DocumentCheck> AutomaticCheckHiringValue(int companyUserId, int candidateId, int fileTypeId, int orderId, int documentGroupId,
            string name, string nameEnglish, DocumentCheckStructureDTO currentCheckStructure, int minDocs = 1)
        {
            List<AttachedFileHiring> documentTypeFiles =
                await _attachedFileHiringRepository.GetByFileTypeAndCompanyIdOrOwnAndCandidateId(candidateId, companyUserId, fileTypeId);

            DocumentCheck documentType = new DocumentCheck
            {
                OrderId = orderId,
                CandidateId = candidateId,
                DocumentCheckGroupId = documentGroupId,
                DocumentCheckStateId = 1,
                IsCheck = false,
                IsEnabled = false,
                CompanyUserId = companyUserId,
                Name = name,
                NameEnglish = nameEnglish
            };

            if (documentTypeFiles != null && documentTypeFiles.Count >= minDocs)
                documentType.IsCheck = true;

            //if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
            //{
            //    foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
            //        if (group.DocumentCheckGroupId == documentGroupId && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
            //            foreach (DocumentCheckDTO item in group.DocumentCheckItems)
            //                if (item.OrderId == orderId)
            //                    if (item.OrderId == orderId)
            //                    {
            //                        documentType.DocumentCheckId = item.DocumentCheckId;
            //                        documentType.IsCheck = item.IsCheck;
            //                    }
            //}
            //else
            //{
            //    if (await _documentCheckRepository.ExistByOrderId(orderId, companyUserId))
            //    {
            //        DocumentCheck oldCheck = await _documentCheckRepository.GetByCandidateIdAndOrderId(candidateId, orderId, companyUserId);

            //        if (oldCheck != null)
            //        {
            //            documentType.DocumentCheckId = oldCheck.DocumentCheckId;
            //            documentType.IsCheck = oldCheck.IsCheck;
            //        }
            //    }
            //}

            return documentType;
        }
    }
}
