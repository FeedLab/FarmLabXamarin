using System;
using System.Collections.Generic;
using FarmLabDevice.Model;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace FarmLabDevice.ViewModels
{
    public class FarmSelectOneOfManyViewModel : ViewModelBase
    {
        private List<FarmItem> _farms;
        private readonly INavigationService _navigationService;
        private readonly UserInfo _userInfo;
        private readonly DeviceInfo _deviceInfo;

        public FarmSelectOneOfManyViewModel(INavigationService navigationService, UserInfo userInfo, DeviceInfo deviceInfo)
        {
            _navigationService = navigationService;
            _userInfo = userInfo;
            _deviceInfo = deviceInfo;

            CmdFarmTapped = new DelegateCommand<object>(Execute_CmdFarmTapped);

        }

        public DelegateCommand<object> CmdFarmTapped { get; }

        public List<FarmItem> Farms
        {
            get => _farms;
            set
            {
                _farms = value;
                RaisePropertyChanged();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Farms = (List<FarmItem>)parameters["farms"];

        }

        private async void Execute_CmdFarmTapped(object obj)
        {
            if (obj is ItemTappedEventArgs farmRow)
            {
                var farm = farmRow.ItemData;

                var navigationParams = new NavigationParameters {{"farm", farm } };

                await _deviceInfo.NavigateAsync("FarmHomeView", navigationParams);
            }
        }

        public void InitialLoad()
        {
        }
    }
}
