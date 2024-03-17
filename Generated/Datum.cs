namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
public static partial class Datum {
    public static NoDatum NoDatum(string? meaning = default, long logicalTimestamp = 0) => new NoDatum(meaning, logicalTimestamp);

    public static ValueDatum<V> AsValueDatum<V>(
        this V value, 
        string? meaning = default, 
        long logicalTimestamp = 0)
        => new ValueDatum<V>(value, meaning, logicalTimestamp);

    public static ErrorDatum AsErrorDatum(
        this Exception that,
        ExceptionDispatchInfo? ExceptionDispatchInfo = default,
        string? Meaning = default,
        long LogicalTimestamp = 0,
        bool IsLogged = false
        )
        => new ErrorDatum(that, ExceptionDispatchInfo, Meaning, LogicalTimestamp, IsLogged);

    public static FailureDatum<F> AsFailureDatum<F>(
        this F value, 
        string? meaning = default, 
        long logicalTimestamp = 0)
        => new FailureDatum<F>(value, meaning, logicalTimestamp);
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