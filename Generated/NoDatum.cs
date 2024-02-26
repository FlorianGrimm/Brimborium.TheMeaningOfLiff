namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
public readonly partial record struct NoDatum(
    string? Meaning = default,
    long LogicalTimestamp = 0) {

    public override string ToString() => string.Empty;

    //public OptionalValueDatum<T> ToOptionalDatum<T>() => new OptionalValueDatum<T>(OptionalValueDatumMode.NoValue, this, default);

    public ValueDatum<T> WithValue<T>(T value, string? meaning = default, long logicalTimestamp = 0)
        => new ValueDatum<T>(
            value,
            meaning ?? this.Meaning,
            logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp);
}

#if UnitTest
#pragma warning disable xUnit2003 // Do not use equality check to test for null value

public class NoDatumTest {
    [Fact]
    public void Test1() {
        var sut = new NoDatum();
        Assert.Equal(string.Empty, sut.ToString());
        Assert.Equal(0, sut.LogicalTimestamp);
        Assert.Equal(null, sut.Meaning);
        Assert.Equal(new NoDatum(), sut);
    }

    [Fact]
    public void TestDefault() {
        var sut = returnDefault();
        Assert.Equal(string.Empty, sut.ToString());
        Assert.Equal(null, sut.Meaning);
        Assert.Equal(0, sut.LogicalTimestamp);
        Assert.Equal(new NoDatum(), sut);

        NoDatum returnDefault(NoDatum elseDatum = default) {
            return elseDatum;
        }
    }
}
#endif
