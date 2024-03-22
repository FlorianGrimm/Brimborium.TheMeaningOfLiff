namespace Brimborium.TheMeaningOfLiff;

[Orleans.Alias(nameof(NoDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer(IncludePrimaryConstructorParameters = false)]
[DebuggerNonUserCode]
[method: JsonConstructor]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly partial record struct ValueDatum<V>(
    V Value,
    Meaning? Meaning = default,
    long LogicalTimestamp = 0)
    : IDatum<V>
    , ISuccessDatum<V>
    , IWithMeaning
    , ILogicalTimestamp {

    private string GetDebuggerDisplay() {
        return $"{this.Value};{this.Meaning};{this.LogicalTimestamp}";
    }

    //public readonly ValueDatum<T> WithValue(T value, Meaning? meaning = default, long logicalTimestamp = 0)
    //    => new ValueDatum<T>(value, meaning, logicalTimestamp > 0 ? logicalTimestamp : this.LogicalTimestamp);

    //public readonly ValueErrorDatum<T> WithError(Exception that, Meaning? meaning = default, long logicalTimestamp = 0)
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

        var sut = init.WithValue(new (42));

        Assert.Equal(42, sut.Value);
        Assert.Equal(meaning, meaning);
        Assert.Equal(1, sut.LogicalTimestamp);
    }
}

#endif