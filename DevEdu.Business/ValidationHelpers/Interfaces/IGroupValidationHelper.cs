﻿using DevEdu.Business.IdentityInfo;
using DevEdu.DAL.Models;
using System.Threading.Tasks;

namespace DevEdu.Business.ValidationHelpers
{
    public interface IGroupValidationHelper
    {
        Task<GroupDto> CheckGroupExistenceAsync(int groupId);
        Task CheckUserInGroupExistenceAsync(int groupId, int userId);
        bool CheckAccessGetGroupMembers(int groupId, UserIdentityInfo userInfo);
    }
}