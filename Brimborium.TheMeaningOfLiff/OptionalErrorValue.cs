#pragma warning disable IDE0031 // Use null propagation

namespace Brimborium.TheMeaningOfLiff;

public enum OptionalErrorValueMode {
    NoValue,
    Error
}

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public record struct OptionalErrorValue(
    OptionalErrorValueMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] ErrorValue ErrorValue
    )
    : IWithMeaning{

    public Meaning? Meaning => (this.Mode) switch {
        OptionalErrorValueMode.NoValue => this.NoValue.Meaning,
        OptionalErrorValueMode.Error => this.ErrorValue.Meaning,
        _ => default
    };


    public readonly void Throw() {
        if (this.Mode == OptionalErrorValueMode.Error) {
            this.ErrorValue.Throw();
        }
    }

    public readonly OptionalErrorValue WithIsLogged(bool isLogged = true) {
        if (this.Mode == OptionalErrorValueMode.Error) {
            return new OptionalErrorValue(OptionalErrorValueMode.Error, default, this.ErrorValue.WithIsLogged(isLogged));
        } else {
            return this;
        }
    }

    private string GetDebuggerDisplay() {
        if (this.Mode == OptionalErrorValueMode.Error && this.ErrorValue.Exception is Exception error) {
            return $"{error.GetType().Name} {error.Message}";
        } else {
            return $"NoException";
        }
    }

    public static OptionalErrorValue Uninitialized => OptionalErrorValueInstance.GetUninitialized();

    public static OptionalErrorValue CreateFromCatchedException(Exception exception, Meaning? meaning = default, long logicalTimestamp = 0) {
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        return new OptionalErrorValue(OptionalErrorValueMode.Error, default, new ErrorValue(exception, exceptionDispatchInfo, meaning, logicalTimestamp, false));
    }

    public static Exception? GetAndSetIsLogged(ref OptionalErrorValue that) {
        if (that.Mode == OptionalErrorValueMode.Error) {
            that = that.WithIsLogged(true);
            return that.ErrorValue.Exception;
        }
        return default;
    }

    public static implicit operator bool(OptionalErrorValue that)
        => that.Mode == OptionalErrorValueMode.Error;

    public static implicit operator OptionalErrorValue(Exception exception)
        => new OptionalErrorValue(OptionalErrorValueMode.Error, default, new ErrorValue(exception, default, default, 0, false));

    public static implicit operator OptionalErrorValue(ErrorValue error)
        => new OptionalErrorValue(OptionalErrorValueMode.Error, default, error);

}

internal static class OptionalErrorValueInstance {
    internal static class Singleton {
        internal static OptionalErrorValue _Uninitialized = CreateUninitialized();
    }
    public static OptionalErrorValue GetUninitialized() => Singleton._Uninitialized;

    public static OptionalErrorValue CreateUninitialized() {
        var error = UninitializedException.Instance;
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(error);
        return new OptionalErrorValue(OptionalErrorValueMode.Error, default, new ErrorValue(error, exceptionDispatchInfo));
    }

}