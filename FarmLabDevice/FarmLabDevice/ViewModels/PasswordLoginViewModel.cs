using System;
using System.Collections.ObjectModel;
using System.Linq;
using FarmLabDevice.Model;
using FarmLabDevice.Services;
using Prism.Commands;
using Prism.Navigation;

namespace FarmLabDevice.ViewModels
{
    public class PasswordLoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly FarmProxy _farmProxy;
        private readonly AccountProxy _accountProxy;
        private readonly AuthProxy _authProxy;
        private readonly DeviceInfo _deviceInfo;
        private string _errorMessage;

        public PasswordLoginViewModel(INavigationService navigationService, FarmProxy farmProxy, AccountProxy accountProxy, AuthProxy authProxy, DeviceInfo deviceInfo)
        {
            _navigationService = navigationService;
            _farmProxy = farmProxy;
            _accountProxy = accountProxy;
            _authProxy = authProxy;
            _deviceInfo = deviceInfo;

            MailAddress = "jompa67@gmail.com";
            Password = "Bondegatan 16b";
            ErrorMessage = "";

            LoginUser = new DelegateCommand(Execute_LoginUser, Can_LoginUser);
        }

        private async void Execute_LoginUser()
        {
            try
            {
                IsBusy = true;

                var jwt = _authProxy.RegisterOrLogin(MailAddress, Password);

                if (jwt == null)
                {
                    throw new ArgumentNullException("jwt");
                }

                var userInfo = _accountProxy.GetUserInfo();

                if (userInfo == null)
                {
                    throw new ArgumentNullException("userInfo");
                }

                var navigationParams = new NavigationParameters();

                if (userInfo.EmailConfirmed == false)
                {
                    navigationParams.Add("UserInfo", userInfo);
                    await _navigationService.NavigateAsync("UserVerifyEMailView", navigationParams);
                }
                else
                {
                    var farmItems = _farmProxy.Farms().ToList();

                    if (!farmItems.Any())
                    {
                        await _navigationService.NavigateAsync("FarmSetupFirstView");
                    }
                    else if (farmItems.Count == 1)
                    {
                        navigationParams.Add("farm", farmItems.ElementAt(0));
                        await _navigationService.GoBackAsync();
                        await _deviceInfo.NavigateAsync("FarmHomeView", navigationParams);
                    }
                    else
                    {
                        navigationParams.Add("farms", farmItems);
                        await _navigationService.GoBackAsync();
                        await _deviceInfo.NavigateAsync("FarmSelectOneOfManyView", navigationParams);
                    }
                }

                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }

            ErrorMessage = "Incorrect User or Password";
        }

        private bool Can_LoginUser()
        {
            return true;
        }

        public bool IsBusy { get; set; }
        public ObservableCollection<UserInfo> UserInfos { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }

        public DelegateCommand LoginUser { set; get; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                RaisePropertyChanged();
            }
        }
    }
}
