using Brimborium.FileSystem.Internal;
using Brimborium.TheMeaningOfLiff;

using Microsoft.Extensions.Logging;

using System.Text.Json.Serialization;

namespace Brimborium.FileSystem;

public record struct FileSystemAbsolutePath(
    ValueDatum<string> Value
    //string Value,
    //Meaning? Meaning = default,
    //long LogicalTimestamp = 0
    )
    //: IDatum<string>
    ;

public interface IFileSystemService {
}

public partial class FileSystemService : IFileSystemService {
    private readonly ILogger<FileSystemService> _Logger;

    public FileSystemService(
        ILogger<FileSystemService> logger
        ) {
        this._Logger = logger;
    }


    private readonly static Meaning _FileContent = new("FileSystem:FileContent", 1, "FileSystem:FileContent");
    public async ValueTask<ValueErrorDatum<string>> ReadAllTextAsync(
        FileSystemAbsolutePath fileSystemPath,
        CancellationToken cancellationToken) {
        ValueErrorDatum<string> result;
        FlowCondition doesExists = new();
        try {
            var optFileExists = this.FileExists(fileSystemPath);
            if (!optFileExists.TryGetValueDatum(out var fileExists, out var errorValue)) { return errorValue; }
            doesExists = new FlowCondition(fileExists, "Exists");
            if (doesExists) {
                var content = await System.IO.File.ReadAllTextAsync(fileSystemPath.Value.Value, System.Text.Encoding.UTF8, cancellationToken);
                result = new ValueDatum<string>(content, _FileContent, DateTimeOffset.UtcNow.Ticks);
                return result;
            } else {
                result = new ErrorDatum(new FileNotFoundException("", fileSystemPath.Value.Value), default, _FileContent, DateTimeOffset.UtcNow.Ticks);
                return result;
            }
        } catch (Exception error) {
            result = ErrorDatum.CreateFromCatchedException(error);
            return result;
        }
    }

    public async ValueTask<ValueErrorDatum<string>> ReadAllTextAsync2(
        FileSystemAbsolutePath fileSystemPath,
        CancellationToken cancellationToken) {
        ValueErrorDatum<string> result;
        FlowCondition doesExists = new();
        try {
            throw new Exception();
            //dynamic x = fileSystemPath;
            //x.Then(this.FileExists).Then(this.ReadAllTextAsync)

            //var optFileExists = this.FileExists(fileSystemPath);
            //optFileExists.Then()
            //if (!optFileExists.TryGetValueDatum(out var fileExists, out var errorValue)) { return errorValue; }
            //doesExists = new FlowCondition(fileExists, "Exists");
            //if (doesExists) {
            //    var content = await System.IO.File.ReadAllTextAsync(fileSystemPath.Value, System.Text.Encoding.UTF8, cancellationToken);
            //    result = new ValueDatum<string>(content, _FileContent, DateTimeOffset.UtcNow.Ticks);
            //    return result;
            //} else {
            //    result = new ErrorDatum(new FileNotFoundException("", fileSystemPath.Value), default, _FileContent, DateTimeOffset.UtcNow.Ticks);
            //    return result;
            //}
        } catch (Exception error) {
            result = ErrorDatum.CreateFromCatchedException(error);
            return result;
        }
    }

    public async ValueTask<OptionalValueErrorDatum<bool>> WriteAllTextAsync(
        FileSystemAbsolutePath fileSystemPath,
        ValueDatum<string> content,
        IFlowDecision<ValueDatum<string>>? flowDecisionFileContent,
        CancellationToken cancellationToken) {
        OptionalValueErrorDatum<bool> result = new NoDatum();
        FlowCondition doesExists = new();
        FlowCondition isEqual = new();
        try {
            var optFileExists = this.FileExists(fileSystemPath);
            if (!optFileExists.TryGetValueDatum(out var fileExists, out var errorValue)) { return errorValue; }
            doesExists = new FlowCondition(fileExists, "Exists");

            if (doesExists) {
                var optOldContent = await this.ReadAllTextAsync(fileSystemPath, cancellationToken);
                if (optOldContent.TryGetErrorDatum(out errorValue, out var oldContent)) { return errorValue; }
                isEqual = (flowDecisionFileContent ?? FlowDecisionStringComparision.Ordinal).Decision(
                    content, oldContent, "shortcut if equal");
                if (isEqual) {
                    result = result.WithValue(false, content.Meaning, content.LogicalTimestamp);
                    this._Logger.TraceWriteAllTextAsyncResult(result, [doesExists, isEqual]);
                    return result;
                }
            } else {
                // no check needed
            }
            {
                await System.IO.File.WriteAllTextAsync(fileSystemPath.Value, content.Value, cancellationToken);
                result = new ValueDatum<bool>(true, content.Meaning, content.LogicalTimestamp);
                this._Logger.TraceWriteAllTextAsyncResult(result, [doesExists, isEqual]);
                return result;
            }
        } catch (Exception error) {
            result = ErrorDatum.CreateFromCatchedException(error);
            this._Logger.WarningWriteAllTextAsyncResult(result, [doesExists, isEqual]);
            return result;
        }
    }

    private readonly static Meaning _Existence = new("FileSystem:Existence", 2, "FileSystem:Existence");
    public ValueErrorDatum<bool> FileExists(FileSystemAbsolutePath fileSystemPath) {
        try {            
            var fi = new System.IO.FileInfo(fileSystemPath.Value.Value);
            return new ValueDatum<bool>(fi.Exists, _Existence, fileSystemPath.Value.LogicalTimestamp);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error, _Existence, fileSystemPath.Value.LogicalTimestamp);
        }
    }
}
public interface IXX<O, I>{
    // OptionalValueErrorDatum<O> Execute(OptionalValueErrorDatum<I> arg);
    O ExecuteNoDatum(I arg);
    O ExecuteValueDatum(I arg);
    O ExecuteE(I arg);
}
public partial class FileSystemServiceFileExists {
    private readonly static Meaning _Existence = new("FileSystem:Existence", 2, "FileSystem:Existence");
    public ValueErrorDatum<bool> Execute(FileSystemAbsolutePath fileSystemPath) {
        try {
            var fi = new System.IO.FileInfo(fileSystemPath.Value.Value);
            return new ValueDatum<bool>(fi.Exists, _Existence, fileSystemPath.Value.LogicalTimestamp);
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error, _Existence, fileSystemPath.Value.LogicalTimestamp);
        }
    }
}


public class FlowDecisionStringComparision : IFlowDecision<ValueDatum<string>> {
    private static FlowDecisionStringComparision? _Ordinal;
    public static FlowDecisionStringComparision Ordinal => _Ordinal ??= new FlowDecisionStringComparision(StringComparison.Ordinal);

    private readonly StringComparison _StringComparison;

    public FlowDecisionStringComparision(StringComparison stringComparison) {
        this._StringComparison = stringComparison;
    }

    private readonly static Meaning _Meaning = new("FileContentComparison:Equality");

    public FlowCondition Decision(ValueDatum<string> value, ValueDatum<string> comparative, string description) {
        return new FlowCondition(
            new ValueDatum<bool>(
                string.Equals(value.Value, comparative.Value, this._StringComparison),
                _Meaning,
                value.LogicalTimestamp
            ),
            description);
    }
}

