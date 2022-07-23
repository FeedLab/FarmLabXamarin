using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace FarmLabDevice.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoleTypes
    {
        Admin,
        FarmAdmin,
        FarmUser,
        FarmReader
    }

    public class UserInfo
    {
        public UserInfo()
        {
        }

        //public UserInfo(UserInfo userInfo)
        //{
        //    CopyFrom(userInfo);
        //}

        public void CopyFrom(UserInfo userInfo)
        {
            ExternalUserReference = userInfo.ExternalUserReference;
            DisplayName = userInfo.DisplayName;
            FarmCreated = userInfo.FarmCreated;
            LastVisiting = userInfo.LastVisiting;
            EmailAddress = userInfo.EmailAddress;
            EmailConfirmed = userInfo.EmailConfirmed;
        }

        public string ExternalUserReference { get; set; }

        public RoleTypes Role { get; set; }

        public string EmailAddress { get; set; }

        public string DisplayName { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime FarmCreated { get; set; }

        public DateTime LastVisiting { get; set; }
    }
}
