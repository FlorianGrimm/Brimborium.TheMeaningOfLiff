using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using OpenTelemetry.Logs;

using System.Collections.Generic;
using Cocona;

namespace SampleCopyFolder;

public static class Program {
    public static int Main(string[] args) {
        var builder = CoconaApp.CreateBuilder();
        ICollection<LogRecord> exportedItems = new List<LogRecord>();
        builder.Logging.AddOpenTelemetry(openTelemetry => {
            openTelemetry.AddInMemoryExporter(exportedItems);
        });
        var app = builder.Build();

        app.AddCommands<CopyFile>();
        app.AddCommands<CopyFolder>();

        app.Run();
        return 0;
    }
}

public class CopyFile {
    private readonly ILogger _Logger;

    public CopyFile(
        ILogger<CopyFile> logger
        ) {
        this._Logger = logger;
    }
        
    [Cocona.Command("CopyFile")]
    public void Execute(
        [Cocona.Argument("source", Description = "source file", Name = "s", Order = 0)]
        string source,
        [Cocona.Argument("target", Description = "target file", Name = "t", Order = 1)]
        string target,
        [Cocona.Argument("watch", Description = "watch", Name = "w", Order = 2)]
        bool watch
        ) {
    }
}

public class CopyFolder {
    private readonly ILogger _Logger;

    public CopyFolder(
        ILogger<CopyFolder> logger
        ) {
        this._Logger = logger;
    }
        
    [Cocona.Command("CopyFolder")]
    public void Execute(
        [Cocona.Argument("source", Description = "source file", Name = "s", Order = 0)]
        string source,
        [Cocona.Argument("target", Description = "target file", Name = "t", Order = 1)]
        string target,
        [Cocona.Argument("watch", Description = "watch", Name = "w", Order = 2)]
        bool watch
        ) {
    }
}