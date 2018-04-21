using Xamarin.Forms;

namespace FarmLabDevice
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new FarmLabDevice.MainPage();
		}
        
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	    public static IAuthenticate Authenticator { get; private set; }

	    public static void Init(IAuthenticate authenticator)
	    {
	        Authenticator = authenticator;
	    }
    }
}
