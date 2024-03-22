namespace Brimborium.TheMeaningOfLiff;

[Orleans.Alias(nameof(ErrorDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer(IncludePrimaryConstructorParameters = false)]
[DebuggerNonUserCode]
//[method: JsonConstructor] not this ctor
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ErrorDatum(
    [property: Orleans.Id(0)] Exception Exception,
    ExceptionDispatchInfo? ExceptionDispatchInfo = default,
    [property: Orleans.Id(1)] Meaning? Meaning = default,
    [property: Orleans.Id(2)] long LogicalTimestamp = 0,
    [property: Orleans.Id(3)] bool IsLogged = false
    )
    : IWithMeaning
    , ILogicalTimestamp {

#if Orleans
    [Orleans.OrleansConstructor]
#endif
    public ErrorDatum(
        Exception Exception,
        Meaning? Meaning,
        long LogicalTimestamp,
        bool IsLogged
        ) :this(Exception, default, Meaning, LogicalTimestamp, IsLogged){
    }

    [DoesNotReturn]
    public Exception Throw() {
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
            return $"{this.Exception.GetType().Name};{this.Exception.Message};{this.Meaning};{this.LogicalTimestamp}";
        } else {
            return $";;{this.Meaning};{this.LogicalTimestamp}";
        }
    }

    public readonly ErrorDatum WithIsLogged(bool isLogged = true)
        => new ErrorDatum(this.Exception, this.ExceptionDispatchInfo, this.Meaning, this.LogicalTimestamp, isLogged);

    public readonly ErrorDatum With(Meaning? meaning, long logicalTimestamp = 0, bool? isLogged = default)
        => new ErrorDatum(
            this.Exception,
            this.ExceptionDispatchInfo,
            meaning ?? this.Meaning,
            (logicalTimestamp > 0) ? logicalTimestamp : this.LogicalTimestamp,
            isLogged.GetValueOrDefault(this.IsLogged));

    public static ErrorDatum Uninitialized => UninitializedExceptionInstance.GetUninitialized();

    public static ErrorDatum CreateFromCatchedException(Exception exception, Meaning? meaning = default, long logicalTimestamp = 0) {
        var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        return new ErrorDatum(exception, exceptionDispatchInfo, meaning, logicalTimestamp, false);
    }

    public static Exception GetAndSetIsLogged(ref ErrorDatum that) {
        that = that.WithIsLogged();
        return that.Exception;
    }

    public static implicit operator ErrorDatum(Exception error) {
        return new ErrorDatum(error, default, default, 0, false);
    }
}

#if UnitTest
#pragma warning disable xUnit2004 // Do not use equality check to test for boolean conditions

public class ErrorValueTest {
    [Fact]
    public void ErrorValueTest01() {
        var meaning = "TheMeaningOfLiff";
        ErrorDatum sut;
        try {
            throw new InvalidOperationException("Hugo");
        } catch (Exception error) {
            sut = ErrorDatum.CreateFromCatchedException(error, meaning, 1);
        }
        Assert.NotNull(sut.Exception);
        Assert.Equal("Hugo", sut.Exception.Message);
        Assert.NotNull(sut.ExceptionDispatchInfo);
        Assert.NotNull(sut.Meaning);
        Assert.Equal(meaning, sut.Meaning);
        Assert.Equal(false, sut.IsLogged);
        Assert.Throws<InvalidOperationException>(()=>sut.Throw());
        Assert.Throws<InvalidOperationException>(()=>sut.ThrowNotReturn<int>());
    }
}

#endif
