namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
public static partial class Datum {
    public static NoDatum NoDatum(string? meaning = default, long logicalTimestamp = 0) => new NoDatum(meaning, logicalTimestamp);

    public static ValueDatum<T> AsValueDatum<T>(this T value, string? meaning = default, long logicalTimestamp = 0)
        => new ValueDatum<T>(value, meaning, logicalTimestamp);

    public static ErrorDatum AsErrorDatum(this Exception that,
        ExceptionDispatchInfo? ExceptionDispatchInfo = default,
        string? Meaning = default,
        long LogicalTimestamp = 0,
        bool IsLogged = false
        )
        => new ErrorDatum(that, ExceptionDispatchInfo, Meaning, LogicalTimestamp, IsLogged);

    public static ValueErrorDatum<T> AsDatumError<T>(this T that)
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Success, new ValueDatum<T>(that), default);

    public static ValueErrorDatum<T> AsDatumError<T>(this ValueDatum<T> that, string? meaning = default, long logicalTimestamp = 0)
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Success, that.Value.AsValueDatum(meaning ?? that.Meaning, LogicalTimestampUtility.Next(that.LogicalTimestamp, logicalTimestamp)), default);

    public static ValueErrorDatum<T> AsDatumError<T>(this OptionalValueErrorDatum<T> that, string? meaning = default, long logicalTimestamp = 0) {
        if (that.TryGetValue(out var successValue)) {
            return new ValueErrorDatum<T>(successValue.AsValueDatum(meaning ?? that.Meaning, LogicalTimestampUtility.Next(that.LogicalTimestamp, logicalTimestamp)));
        } else if (that.TryGetError(out var errorValue)) {
            return new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default, errorValue);
        }
        return new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default, new UninitializedException());
    }

    public static ValueErrorDatum<T> AsDatumError<T>(this Exception that)
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default, new ErrorDatum(that));

    public static ValueErrorDatum<T> AsDatumError<T>(this ErrorDatum that)
        => new ValueErrorDatum<T>(ValueErrorDatumMode.Error, default, that);


#pragma warning disable IDE0060 // Remove unused parameter
    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this NoDatum that)
        => new OptionalValueErrorDatum<T>();
#pragma warning restore IDE0060 // Remove unused parameter

    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this T that)
        => new OptionalValueErrorDatum<T>(that);

    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this ValueDatum<T> that)
        => new OptionalValueErrorDatum<T>(that.Value);

    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this Exception that)
        => new OptionalValueErrorDatum<T>(that);

    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this ErrorDatum value)
        => new OptionalValueErrorDatum<T>(value);

    public static OptionalValueErrorDatum<T> AsOptionalDatumError<T>(this ValueErrorDatum<T> that) {
        if (that.TryGetValue(out var successValue)) {
            return new OptionalValueErrorDatum<T>(successValue);
        } else if (that.TryGetError(out var errorValue)) {
            return new OptionalValueErrorDatum<T>(errorValue);
        } else {
            return new OptionalValueErrorDatum<T>(new InvalidEnumArgumentException($"Invalid enum {that.Mode}."));
        }
    }


}

#if UnitTest
public partial class DatumTest {
    record A(string Name);
    record B(string Name) : A(Name);

    [Fact]
    public void NamingTest() {
        var noValue=Datum.NoDatum("a");
        Assert.Equal("a", noValue.Meaning);

        var valueDatum = Datum.AsValueDatum(42, "b");
        Assert.Equal(42, valueDatum.Value);
        Assert.Equal("b", valueDatum.Meaning);

        var errorDatum = Datum.AsErrorDatum(new Exception(), default, "c");
        Assert.IsType<Exception>(errorDatum.Exception);
        Assert.Equal("c", errorDatum.Meaning);
    }
}
#endif
