using Brimborium.FileSystem.Internal;
using Brimborium.TheMeaningOfLiff;

using Microsoft.Extensions.Logging;

using System.Text.Json.Serialization;

namespace Brimborium.FileSystem;

public record struct FileSystemAbsolutePath(
    string Value,
    Meaning? Meaning = default,
    long LogicalTimestamp = 0
    ) : IDatum<string>;

public interface IFileSystemService {
}

public partial class FileSystemService : IFileSystemService {
    private readonly ILogger<FileSystemService> _Logger;

    public FileSystemService(
        ILogger<FileSystemService> logger
        ) {
        this._Logger = logger;
    }


    private readonly static Meaning _FileContent = MeaningPool.Get("FileSystem", "FileContent");
    public async ValueTask<DatumError<string>> ReadAllTextAsync(
        FileSystemAbsolutePath fileSystemPath,
        CancellationToken cancellationToken) {
        DatumError<string> result;
        FlowCondition doesExists = new();
        try {
            var optFileExists = this.FileExists(fileSystemPath);
            if (!optFileExists.TryGet(out var fileExists, out var errorValue)) { return errorValue; }
            doesExists = new FlowCondition(fileExists.Value, "Exists");
            if (doesExists) {
                var content = await System.IO.File.ReadAllTextAsync(fileSystemPath.Value, System.Text.Encoding.UTF8, cancellationToken);
                result = new Datum<string>(content, _FileContent, DateTimeOffset.UtcNow.Ticks);
                return result;
            } else {
                result = new ErrorValue(new FileNotFoundException("", fileSystemPath.Value), default, _FileContent, DateTimeOffset.UtcNow.Ticks);
                return result;
            }
        } catch (Exception error) {
            result = ErrorValue.CreateFromCatchedException(error);
            return result;
        }
    }

    public async ValueTask<OptionalDatumError<bool>> WriteAllTextAsync(
        FileSystemAbsolutePath fileSystemPath,
        Datum<string> content,
        IFlowDecision<Datum<string>>? flowDecisionFileContent,
        CancellationToken cancellationToken) {
        OptionalDatumError<bool> result;
        FlowCondition doesExists = new();
        FlowCondition isEqual = new();
        try {
            var optFileExists = this.FileExists(fileSystemPath);
            if (!optFileExists.TryGet(out var fileExists, out var errorValue)) { return errorValue; }
            doesExists = new FlowCondition(fileExists.Value, "Exists");

            if (doesExists) {
                var optOldContent = await this.ReadAllTextAsync(fileSystemPath, cancellationToken);
                if (optOldContent.TryGetError(out errorValue, out var oldContent)) { return errorValue; }
                isEqual = (flowDecisionFileContent ?? FlowDecisionStringComparision.Ordinal).Decision(
                    content, oldContent, "shortcut if equal");
                if (isEqual) {
                    result = new Datum<bool>(false, content.Meaning, content.LogicalTimestamp);
                    this._Logger.TraceWriteAllTextAsyncResult(result, [doesExists, isEqual]);
                    return result;
                }
            } else {
                // no check needed
            }
            {
                await System.IO.File.WriteAllTextAsync(fileSystemPath.Value, content.Value, cancellationToken);
                result = new Datum<bool>(true, content.Meaning, content.LogicalTimestamp);
                this._Logger.TraceWriteAllTextAsyncResult(result, [doesExists, isEqual]);
                return result;
            }
        } catch (Exception error) {
            result = ErrorValue.CreateFromCatchedException(error);
            this._Logger.WarningWriteAllTextAsyncResult(result, [doesExists, isEqual]);
            return result;
        }
    }

    private readonly static Meaning _Existence = MeaningPool.Get("FileSystem", "Existence");
    public DatumError<bool> FileExists(FileSystemAbsolutePath fileSystemPath) {
        try {
            var fi = new System.IO.FileInfo(fileSystemPath.Value);
            return new Datum<bool>(fi.Exists, _Existence, fileSystemPath.LogicalTimestamp);
        } catch (Exception error) {
            return ErrorValue.CreateFromCatchedException(error, _Existence, fileSystemPath.LogicalTimestamp);
        }
    }
}


public class FlowDecisionStringComparision : IFlowDecision<Datum<string>> {
    private static FlowDecisionStringComparision? _Ordinal;
    public static FlowDecisionStringComparision Ordinal => _Ordinal ??= new FlowDecisionStringComparision(StringComparison.Ordinal);

    private readonly StringComparison _StringComparison;

    public FlowDecisionStringComparision(StringComparison stringComparison) {
        this._StringComparison = stringComparison;
    }

    private readonly static Meaning _Meaning = MeaningPool.Get("FileContentComparison", "Equality");

    public FlowCondition Decision(Datum<string> value, Datum<string> comparative, string description) {
        return new FlowCondition(
            new Datum<bool>(
                string.Equals(value.Value, comparative.Value, this._StringComparison),
                _Meaning,
                value.LogicalTimestamp
            ),
            description);
    }
}

