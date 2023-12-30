using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using OpenTelemetry.Logs;

namespace SampleCopyFolder;

public static class Program {
    public static int Main(string[] args) {
        //var builder =  Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args);
        var builder =  Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);
        //builder.Services.Add
        builder.Logging.AddOpenTelemetry(openTelemetry=>{
            openTelemetry.AddInMemoryExporter(here);
        })
        //builder.Logging.
        var app = builder.Build();
        app.Run();
        return 0;
    }
}
