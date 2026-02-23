using AutoMapper;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IValidateMethodsService
    {
        public Task<bool> IsValidated(string JWTString, string validationString);
        public Task<bool> IsValidatedAction(MemberUser memberUser, string validationString);
        public Task<Dictionary<string, bool>> IsValidatedActionMultiple(MemberUser memberUser, bool isExsis, List<string> validationStrings);
        public Task<MemberUser> IsValidatedFromCandidate(string JWTString, string validationString);
        public string EncodeJWT(string JWTString);
        public string EncodeSHA256(string name, string type, double weight, string uploadDate, string memberUserName);
        public string GetEmailMemberUserByToken(string JWTString);
        public Task<List<ActionUser>> ValidateView(string JWTString);
        public Task<MemberUser> GetMemberUserByToken(string JWTString);
        Task<MemberUserDTO> GetResponseValidateActionByPermission(string validationString, StringValues values);
        public Task<bool> GetResponseValidateActionByPermissionNew(string validationString, StringValues values);
    }


    public class ValidateMethodsService : IValidateMethodsService
    {
        private IMemberUserRepository _memberUserRepository;
        private IPermissionRoleRepository _permissionRoleRepository;
        private IPermissionActionUserRepository _permissionActionUserRepository;
        private IActionUserRepository _actionUserRepository;

        private IMapper _mapper;

        public ValidateMethodsService(IMemberUserRepository memberUserRepository, IPermissionRoleRepository permissionRoleRepository, IPermissionActionUserRepository permissionActionUserRepository,
            IActionUserRepository actionUserRepository, IMapper mapper)
        {
            _memberUserRepository = memberUserRepository;
            _permissionRoleRepository = permissionRoleRepository;
            _permissionActionUserRepository = permissionActionUserRepository;
            _actionUserRepository = actionUserRepository;

            _mapper = mapper;
        }

        public async Task<bool> IsValidated(string JWTString, string validationString)
        {
            string email = EncodeJWT(JWTString);

            MemberUser memberUser = await _memberUserRepository.GetByEmail(email);

            List<Permission_Role> permissionsRole = await _permissionRoleRepository.GetByRoleIdOnlyChecked(memberUser.RoleId);

            List<Permission_ActionUser> permissions_actionUser = new List<Permission_ActionUser>();

            foreach (Permission_Role permission_Role in permissionsRole)
            {
                permissions_actionUser.AddRange(await _permissionActionUserRepository.GetAllByPermissionId(permission_Role.PermissionId));
            }

            List<ActionUser> actionsUser = new List<ActionUser>();

            foreach (Permission_ActionUser permission_actionUser in permissions_actionUser)
            {
                actionsUser.Add(await _actionUserRepository.GetById(permission_actionUser.ActionUserId));
            }

            foreach (ActionUser actionUser in actionsUser)
            {
                if (actionUser.StringId == validationString)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> IsValidatedAction(MemberUser memberUser, string validationString)
        {
            ActionUserDTO actionUser = await _actionUserRepository.GetByValidationString(validationString);

            List<Permission_Role> permissionsRole = await _permissionRoleRepository.GetByRoleIdOnlyCheckedGeneralMethod(memberUser.RoleId);

            if (actionUser != null && actionUser.Permission_ActionUser != null && actionUser.Permission_ActionUser.Count > 0)
            {
                foreach (Permission_ActionUserDTO permission_ActionUser in actionUser.Permission_ActionUser)
                {
                    if (permissionsRole.Count > 0)
                    {
                        foreach (Permission_Role permission_Role in permissionsRole)
                        {
                            if (permission_ActionUser.PermissionId == permission_Role.PermissionId)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public async Task<Dictionary<string, bool>> IsValidatedActionMultiple(MemberUser memberUser, bool isExsis, List<string> validationStrings)
        {
            Dictionary<string, bool> dictionaryValidations = new Dictionary<string, bool>();

            if (validationStrings != null && validationStrings.Count > 0)
            {
                foreach (string validationString in validationStrings)
                {
                    bool isAuth = false;

                    ActionUserDTO actionUser = await _actionUserRepository.GetByValidationString(validationString);

                    List<Permission_Role> permissionsRole = await _permissionRoleRepository.GetByRoleIdOnlyCheckedGeneralMethod(memberUser.RoleId);

                    if (actionUser != null && actionUser.Permission_ActionUser != null && actionUser.Permission_ActionUser.Count > 0)
                    {
                        foreach (Permission_ActionUserDTO permission_ActionUser in actionUser.Permission_ActionUser)
                        {
                            if (permissionsRole.Count > 0)
                            {
                                foreach (Permission_Role permission_Role in permissionsRole)
                                {
                                    if (permission_ActionUser.PermissionId == permission_Role.PermissionId)
                                    {
                                        isAuth = true;

                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (!dictionaryValidations.ContainsKey(validationString))
                        dictionaryValidations.Add(validationString, isAuth);
                }
            }

            return dictionaryValidations;
        }

        public async Task<MemberUser> IsValidatedFromCandidate(string JWTString, string validationString)
        {
            string email = EncodeJWT(JWTString);

            MemberUser memberUser = await _memberUserRepository.GetByEmail(email);

            List<Permission_Role> permissionsRole = await _permissionRoleRepository.GetByRoleIdOnlyChecked(memberUser.RoleId);

            List<Permission_ActionUser> permissions_actionUser = new List<Permission_ActionUser>();

            foreach (Permission_Role permission_Role in permissionsRole)
            {
                permissions_actionUser.AddRange(await _permissionActionUserRepository.GetAllByPermissionId(permission_Role.PermissionId));
            }

            List<ActionUser> actionsUser = new List<ActionUser>();

            foreach (Permission_ActionUser permission_actionUser in permissions_actionUser)
            {
                actionsUser.Add(await _actionUserRepository.GetById(permission_actionUser.ActionUserId));
            }

            foreach (ActionUser actionUser in actionsUser)
            {
                if (actionUser.StringId == validationString)
                {
                    return memberUser;
                }
            }

            return null;
        }

        public async Task<List<ActionUser>> ValidateView(string JWTString)
        {
            string email = EncodeJWT(JWTString);

            MemberUser memberUser = await _memberUserRepository.GetByEmail(email);

            List<Permission_Role> permissionsRole = await _permissionRoleRepository.GetByRoleIdOnlyChecked(memberUser.RoleId);

            List<Permission_ActionUser> permissions_actionUser = new List<Permission_ActionUser>();

            foreach (Permission_Role permission_Role in permissionsRole)
            {
                permissions_actionUser.AddRange(await _permissionActionUserRepository.GetAllByPermissionId(permission_Role.PermissionId));
            }

            List<ActionUser> actionsUser = new List<ActionUser>();

            foreach (Permission_ActionUser permission_actionUser in permissions_actionUser)
            {
                actionsUser.Add(await _actionUserRepository.GetById(permission_actionUser.ActionUserId));
            }

            return actionsUser;
        }

        public async Task<MemberUser> GetMemberUserByToken(string JWTString)
        {
            string email = EncodeJWT(JWTString);

            MemberUser memberUser = await _memberUserRepository.GetByEmail(email);

            return memberUser;
        }

        public string GetEmailMemberUserByToken(string JWTString)
        {
            string email = EncodeJWT(JWTString);

            return email;
        }

        public string EncodeJWT(string JWTString)
        {
            JWTString = JWTString.Split(" ")[1];

            JwtSecurityToken jwtToken = new JwtSecurityToken(JWTString);
            JwtPayload payLoad = jwtToken.Payload;

            if (payLoad.ContainsKey("username"))
                return payLoad["username"].ToString();

            if (payLoad.ContainsKey("cognito:username"))
                return payLoad["cognito:username"].ToString();

            return "";
        }

        public string EncodeSHA256(string name, string type, double weight, string uploadDate, string memberUserName)
        {
            string stringBase = name + type + weight.ToString() + uploadDate + memberUserName;

            // convert to bytes using UTF-8 encoding
            byte[] tokenBytes = Encoding.UTF8.GetBytes(stringBase);

            // convert those bytes to a hexadecimal string
            string tokenBytesHex = BitConverter.ToString(tokenBytes).Replace("-", "");

            // convert that string back to bytes (UTF-8 used here since that is the default on PHP, but ASCII will work too)
            byte[] tokenBytesHexBytes = Encoding.UTF8.GetBytes(stringBase);

            // hash those bytes
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(tokenBytesHexBytes);

                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public async Task<MemberUserDTO> GetResponseValidateActionByPermission(string validationString, StringValues values)
        {
            try
            {
                MemberUser memberUser = await IsValidatedFromCandidate(values.ToString(), validationString);

                if (memberUser == null)
                    memberUser = new MemberUser();

                MemberUserDTO memberUserDTO = _mapper.Map<MemberUser, MemberUserDTO>(memberUser);

                return memberUserDTO;
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }

        public async Task<bool> GetResponseValidateActionByPermissionNew(string validationString, StringValues values)
        {
            try
            {
                string email = "";
                MemberUser memberUser = await GetMemberUserByToken(values.ToString());

                bool isMaster = false;

                if (memberUser == null)
                    return false;

                email = memberUser.Email;

                if (!string.IsNullOrEmpty(email) && (email == "recruitment_owner@exsis.com.co" || email == "recruitmentmaster@exsis.com.co"))
                    isMaster = true;

                bool isAuthorized = await IsValidatedAction(memberUser, validationString);

                if (!isMaster && !isAuthorized)
                    return false;

                return true;

            }
            catch (ArgumentException e)
            {
                return false;
            }
        }
    }
}
