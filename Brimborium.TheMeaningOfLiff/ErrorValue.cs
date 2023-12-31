namespace Brimborium.TheMeaningOfLiff;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly record struct ErrorValue(
    Exception Exception,
    ExceptionDispatchInfo? ExceptionDispatchInfo = default,
    Meaning? Meaning = default,
    long LogicalTimestamp = 0,
    bool IsLogged = false
    )
    : IWithMeaning
    , ILogicalTimestamp {

    [DoesNotReturn]
    public void Throw() {
        if (this.ExceptionDispatchInfo is not null) {
            this.ExceptionDispatchInfo.Throw();
        }

        if (this.Exception is not null) {
            throw this.Exception;
        }

        // TODO: better error
        throw new UninitializedException();
    }

    [DoesNotReturn]
    public T ThrowNotReturn<T>() {
        if (this.ExceptionDispatchInfo is not null) {
            this.ExceptionDispatchInfo.Throw();
        }

        if (this.Exception is not null) {
            throw this.Exception;
        }

        // TODO: better error
        throw new UninitializedException();
    }

    private string GetDebuggerDisplay() {
        if (this.Exception is not null) {
            return $"{this.Exception.GetType().Name} {this.Exception.Message}";
        }
        return this.ToString();
    }

    public readonly ErrorValue WithIsLogged(bool isLogged = true)
        => new ErrorValue(this.Exception, this.ExceptionDispatchInfo, this.Meaning, this.LogicalTimestamp, isLogged);

    public readonly ErrorValue With(Meaning? meaning, long logicalTimestamp = 0, bool? isLogged = default)
        => new ErrorValue(
            this.Exception,
            this.ExceptionDispatchInfo,
            meaning ?? this.Meaning,
            (logicalTimestamp > 0) ? logicalTimestamp : this.LogicalTimestamp,
            isLogged.GetValueOrDefault(this.IsLogged));

    public static ErrorValue Uninitialized => ErrorValueInstance.GetUninitialized();

    public static ErrorValue CreateFromCatchedException(Exception exception, Meaning? meaning = default, long logicalTimestamp = 0) {
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        return new ErrorValue(exception, exceptionDispatchInfo, meaning, logicalTimestamp, false);
    }

    public static Exception GetAndSetIsLogged(ref ErrorValue that) {
        that = that.WithIsLogged();
        return that.Exception;
    }

    public static implicit operator ErrorValue(Exception error) {
        return new ErrorValue(error, default, default, 0, false);
    }
}

internal static class ErrorValueInstance {
    internal static class Singleton {
        internal static ErrorValue _Uninitialized = CreateUninitialized();
    }
    public static ErrorValue GetUninitialized() => Singleton._Uninitialized;

    public static ErrorValue CreateUninitialized() {
        var error = UninitializedException.Instance;
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(error);
        return new ErrorValue(error, exceptionDispatchInfo, default, 0, false);
    }

}
