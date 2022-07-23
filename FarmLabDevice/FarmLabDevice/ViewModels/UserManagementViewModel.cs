using System;
using System.Collections.Generic;
using FarmLabDevice.Model;
using FarmLabDevice.Services;

namespace FarmLabDevice.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        private readonly AccountProxy _accountProxy;
        private IEnumerable<UserInfo> _userInfosForFarm;

        public UserManagementViewModel(AccountProxy accountProxy)
        {
            _accountProxy = accountProxy ?? throw new ArgumentNullException(nameof(accountProxy));
        }

        public IEnumerable<UserInfo> UserInfos
        {
            get
            {
                if(_userInfosForFarm == null)
                {
                    InitialLoad();
                }

                return _userInfosForFarm;
            }
            set
            {
                _userInfosForFarm = value;
                RaisePropertyChanged();
            }
        }

        public void InitialLoad()
        {
            UserInfos = _accountProxy.GetUserInfosForFarm();
        }
    }
}
