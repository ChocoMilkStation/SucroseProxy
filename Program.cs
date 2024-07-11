using SucroseProxy;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "SucroseProxy - HSR Only & No .NET runtime needed!";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Starting proxy...\nJust say yes when it asks to install a certificate. It's needed to redirect HTTPS.\n\nBy the way, if you close this proxy and you go \"offline\", open proxy settings in windows and disable it.\nSometimes this thing doesn't automatically disable it when closed.");
        Console.ResetColor();

        string[] address = { "127.0.0.1:21000" };

        ProxyService service = new ProxyService(address);

        AppDomain.CurrentDomain.ProcessExit += (_, _) =>
        {
            Console.WriteLine("Shutting down...");
            service.Shutdown();
        };

        service.Start();
    }
}
