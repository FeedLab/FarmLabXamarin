namespace FarmLabDevice.Helpers
{
    public static class Constants
    {
#if DEBUG
        public const string Host = "http://82.183.31.17:5000";
#else
        public const string Host = "https://farmlab.azurewebsites.net";
#endif
    }
}
