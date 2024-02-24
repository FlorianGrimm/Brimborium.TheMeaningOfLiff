#pragma warning disable IDE0031 // Use null propagation

namespace Brimborium.TheMeaningOfLiff;

public enum OptionalErrorDatumMode { NoValue, Error }

[DebuggerNonUserCode]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct OptionalErrorDatum(
    OptionalErrorDatumMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] ErrorDatum ErrorDatum
    )
    : IWithMeaning {

    public string? Meaning => (this.Mode) switch {
        OptionalErrorDatumMode.NoValue => this.NoValue.Meaning,
        OptionalErrorDatumMode.Error => this.ErrorDatum.Meaning,
        _ => default
    };


    public readonly void Throw() {
        if (this.Mode == OptionalErrorDatumMode.Error) {
            this.ErrorDatum.Throw();
        }
    }

    public readonly OptionalErrorDatum WithIsLogged(bool isLogged = true) {
        if (this.Mode == OptionalErrorDatumMode.Error) {
            return new OptionalErrorDatum(OptionalErrorDatumMode.Error, default, this.ErrorDatum.WithIsLogged(isLogged));
        } else {
            return this;
        }
    }

    private string GetDebuggerDisplay() {
        if (this.Mode == OptionalErrorDatumMode.Error && this.ErrorDatum.Exception is Exception error) {
            return $"{error.GetType().Name} {error.Message}";
        } else {
            return $"NoException";
        }
    }

    public static OptionalErrorDatum Uninitialized => OptionalErrorValueInstance.GetUninitialized();

    public static OptionalErrorDatum CreateFromCatchedException(Exception exception, string? meaning = default, long logicalTimestamp = 0) {
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        return new OptionalErrorDatum(OptionalErrorDatumMode.Error, default, new ErrorDatum(exception, exceptionDispatchInfo, meaning, logicalTimestamp, false));
    }

    public static Exception? GetAndSetIsLogged(ref OptionalErrorDatum that) {
        if (that.Mode == OptionalErrorDatumMode.Error) {
            that = that.WithIsLogged(true);
            return that.ErrorDatum.Exception;
        }
        return default;
    }

    public bool TryGetNoDatum(
        [MaybeNullWhen(false)] out NoDatum noDatum,
        [MaybeNullWhen(true)] out ErrorDatum elseDatum) {
        if (this.Mode == OptionalErrorDatumMode.Error) {
            noDatum = default;
            elseDatum = this.ErrorDatum;
            return false;
        } else {
            noDatum = this.NoValue;
            elseDatum = default;
            return true;
        }
    }


}

internal static class OptionalErrorValueInstance {
    internal static class Singleton {
        internal static OptionalErrorDatum _Uninitialized = CreateUninitialized();
    }
    public static OptionalErrorDatum GetUninitialized() => Singleton._Uninitialized;

    public static OptionalErrorDatum CreateUninitialized() {
        var error = UninitializedException.Instance;
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(error);
        return new OptionalErrorDatum(OptionalErrorDatumMode.Error, default, new ErrorDatum(error, exceptionDispatchInfo));
    }

}

#if UnitTest
public class OptionalErrorValueInstanceTests {
    [Fact]
    public void SingletonTest() {
        var a = OptionalErrorValueInstance.GetUninitialized();
        var b = OptionalErrorValueInstance.GetUninitialized();
        Assert.NotNull(a.ErrorDatum.Exception);
        Assert.True(ReferenceEquals(a.ErrorDatum.Exception, b.ErrorDatum.Exception));
    }
}
#endif