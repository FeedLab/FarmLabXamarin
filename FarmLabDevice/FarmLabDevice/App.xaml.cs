using Unity;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Prism.Logging;
using Xamarin.Forms.Xaml;
using System;
using FarmLabDevice.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FarmLabDevice
{
	public partial class App : PrismApplication
    {
        public static IAuthenticate Authenticator { get; private set; }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("NavigationPage/MainPage");

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoggerFacade, Services.DebugLogger>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<InitialFarmPage>();
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