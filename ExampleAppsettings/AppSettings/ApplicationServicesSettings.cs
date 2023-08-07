namespace ExampleAppsettings.AppSettings
{
    public static class ApplicationServicesSettings
    {
        public const string MySettings = "MySettings";
        public static MyClassValue MyClassValue { get; set; } = new MyClassValue();
    }

    public class MyClassValue
    {
        public string SomeValue { get; set; }
    }
}
