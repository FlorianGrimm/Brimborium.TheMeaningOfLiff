namespace Brimborium.TheMeaningOfLiff;
public readonly partial record struct OptionalValueDatum<V>{
#pragma warning disable IDE0060 // Remove unused parameter
    public static implicit operator OptionalValueDatum<V>(NoDatum value) => new OptionalValueDatum<V>();
#pragma warning restore IDE0060 // Remove unused parameter

    public static explicit operator OptionalValueDatum<V>(V value)
        => new OptionalValueDatum<V>(OptionalValueDatumMode.Success, default, new ValueDatum<V>(value, default, 0));

    public static implicit operator OptionalValueDatum<V>(ValueDatum<V> value) 
        => new OptionalValueDatum<V>(OptionalValueDatumMode.Success, default, value);

    //public static implicit operator Optional<T>((T Value, Meaning Meaning) args) => new Optional<T>(OptionalMode.Success, args.Value, args.Meaning, 0);

    //public static implicit operator bool(OptionalValueDatum<T> that) 
    //    => that.Mode == OptionalValueDatumMode.Success;
    public static bool operator true(OptionalValueDatum<V> that)
        => that.Mode == OptionalValueDatumMode.Success;
    public static bool operator false(OptionalValueDatum<V> that)
        => that.Mode != OptionalValueDatumMode.Success;

    public static explicit operator V(OptionalValueDatum<V> that)
        => (that.Mode == OptionalValueDatumMode.Success) 
        ? that.ValueDatum.Value
        : throw new InvalidCastException();

    public static implicit operator LogDatum(OptionalValueDatum<V> datum)
        => datum.Mode switch {
            OptionalValueDatumMode.Success => new LogDatum(DatumMode.Success, datum.ValueDatum.Meaning),
            _ => new LogDatum(DatumMode.NoValue, datum.NoValue.Meaning),
        };
}
