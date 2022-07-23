using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;

namespace FarmLabDevice.Model
{
    public class DeviceInfo
    {
        private readonly INavigationService _navigationService;

        public DeviceInfo(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DeviceType = Device.Idiom;
        }

        public TargetIdiom DeviceType { get; }

        public string DeviceTypeText => DeviceType.ToString();

        public Task<INavigationResult> NavigateAsync(string view)
        {
          //  var path = view.Replace("/", DeviceTypeText + "/");
            var path = string.Format(view, DeviceTypeText);
            return _navigationService.NavigateAsync(view);
        }

        public Task<INavigationResult> NavigateAsync(string view, INavigationParameters parameters)
        {
            var path = view.Replace("/", DeviceTypeText + "/");
        //    var path = string.Format(view, DeviceTypeText);
            return _navigationService.NavigateAsync(view, parameters);
        }
    }
}
