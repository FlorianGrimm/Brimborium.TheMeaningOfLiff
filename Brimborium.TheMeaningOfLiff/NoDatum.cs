namespace Brimborium.TheMeaningOfLiff;

[Orleans.Alias(nameof(NoDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer(IncludePrimaryConstructorParameters = false)]
[DebuggerNonUserCode]
[method: JsonConstructor]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct NoDatum(
    Meaning? Meaning = default,
    long LogicalTimestamp = 0) : IDatum {

    public override string ToString() => string.Empty;

    private string GetDebuggerDisplay() {
        return $";{this.Meaning};{this.LogicalTimestamp}";
    }

    //public OptionalValueDatum<T> ToOptionalDatum<T>() => new OptionalValueDatum<T>(OptionalValueDatumMode.NoValue, this, default);

    public ValueDatum<T> WithValue2<T>(T value, Meaning? meaning = default, long logicalTimestamp = 0)
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
