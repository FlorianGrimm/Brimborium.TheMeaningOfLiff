namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
public readonly partial record struct ValueDatum<V>(
    T Value,
    string? Meaning = default,
    long LogicalTimestamp = 0)
    : IDatum<T>
    , ISuccessDatum<T>
    , IWithMeaning
    , ILogicalTimestamp {

    //public readonly ValueDatum<T> WithValue(T value, string? meaning = default, long logicalTimestamp = 0)
    //    => new ValueDatum<T>(value, meaning, logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp);

    //public readonly ValueErrorDatum<T> WithError(Exception that, string? meaning = default, long logicalTimestamp = 0)
    //    => new ValueErrorDatum<T>(new ErrorDatum(that, default, meaning, logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp));

    //public readonly bool TryGetValue([MaybeNullWhen(false)] out T value) {
    //    value = this.Value;
    //    return true;
    //}

}

#if UnitTest
public partial class DatumOfTTest {
    [Fact]
    public void Ctor() {
        var meaning = "TheMeaningOfLiff";
        var sut = new ValueDatum<int>(42, meaning, 1);

        Assert.Equal(42, sut.Value);
        Assert.Equal(meaning, meaning);
        Assert.Equal(1, sut.LogicalTimestamp);
    }

    [Fact]
    public void WithValue() {
        var meaning = "TheMeaningOfLiff";
        var init = new ValueDatum<int>(21, meaning, 1);

        var sut = init.WithValue(42);

        Assert.Equal(42, sut.Value);
        Assert.Equal(meaning, meaning);
        Assert.Equal(1, sut.LogicalTimestamp);
    }
}

#endif