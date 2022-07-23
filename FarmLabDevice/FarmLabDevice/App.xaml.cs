using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Prism.Logging;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;
using FarmLabDevice.Model;
using FarmLabDevice.Services;
using FarmLabDevice.ViewModels;
using FarmLabDevice.Views;
using Prism.Navigation;
using Prism.Plugin.Popups;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FarmLabDevice
{
	public partial class App : PrismApplication
    {
        private DeviceInfo _deviceInfo;
        public static IAuthenticate Authenticator { get; private set; }

        public App() : base(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Container.Resolve<ILoggerFacade>().Log($"{e.Exception}", Category.Exception, Priority.None);
            };


            InitializeComponent();

            _deviceInfo = new DeviceInfo(NavigationService);
            ((IContainerRegistry)Container).RegisterInstance(_deviceInfo);

            var result = await _deviceInfo.NavigateAsync("MainView");

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // This updates INavigationService and registers PopupNavigation.Instance
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.Register<AccountProxy>();
            containerRegistry.Register<AuthProxy>();
            containerRegistry.Register<FarmProxy>();
            containerRegistry.Register<ILoggerFacade, Services.DebugLogger>();
            containerRegistry.RegisterSingleton<Jwt>();
            containerRegistry.RegisterSingleton<UserInfo>();
            containerRegistry.RegisterSingleton<PasswordLoginViewModel>();
            
            containerRegistry.Register<INavigationService, PopupPageNavigationService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<FarmSetupFirstView>();
            containerRegistry.RegisterForNavigation<UserVerifyEMailView>();

            //containerRegistry.RegisterForNavigation<FarmSelectOneOfManyViewTablet>();
            //containerRegistry.RegisterForNavigation<PigManagementHomeViewTablet>();
            //containerRegistry.RegisterForNavigation<RegistrationHomeViewTablet>();
            //containerRegistry.RegisterForNavigation<UserManagementViewTablet>();
            //containerRegistry.RegisterForNavigation<PasswordLoginViewTablet>();
            //containerRegistry.RegisterForNavigation<FarmHomeViewTablet>();
     //       containerRegistry.RegisterForNavigation<MainViewTablet>();
            containerRegistry.RegisterForNavigationOnIdiom<MainViewTablet, MainViewModel>( "MainView", null, typeof(MainViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<FarmHomeViewTablet, FarmHomeViewModel>("FarmHomeView", null, typeof(FarmHomeViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<PasswordLoginViewTablet, PasswordLoginViewModel>("PasswordLoginView", null, typeof(PasswordLoginViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<UserManagementViewTablet, UserManagementViewModel>("UserManagementView", null, typeof(UserManagementViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<RegistrationHomeViewTablet, RegistrationHomeViewModel>("RegistrationHomeView", null, typeof(RegistrationHomeViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<PigManagementHomeViewTablet, PigManagementHomeViewModel>("PigManagementHomeView", null, typeof(PigManagementHomeViewTablet), null);
            containerRegistry.RegisterForNavigationOnIdiom<FarmSelectOneOfManyViewTablet, FarmSelectOneOfManyViewModel>("FarmSelectOneOfManyView", null, typeof(FarmSelectOneOfManyViewTablet), null);

        }
        

        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
    }
}