using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        var builder = new HostBuilder();

        //builder.ConfigureWebJobs(bldr =>
        //{
        //    bldr.AddServiceBus(sb =>
        //    { 
        //        sb.ClientRetryOptions = 
        //    });
        //});

        //builder.ConfigureLogging(logCfg =>
        //{
        //    logCfg.AddConsole();
        //});

        var host = builder.Build();

        using (host)
        {
            host.Run();
        }
    }
}