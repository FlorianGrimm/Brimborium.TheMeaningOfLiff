namespace Brimborium.TheMeaningOfLiff;
public readonly partial record struct OptionalValueDatum<T>{
#pragma warning disable IDE0060 // Remove unused parameter
    public static implicit operator OptionalValueDatum<T>(NoDatum value) => new OptionalValueDatum<T>();
#pragma warning restore IDE0060 // Remove unused parameter

    public static explicit operator OptionalValueDatum<T>(T value)
        => new OptionalValueDatum<T>(OptionalValueDatumMode.Success, default, new ValueDatum<T>(value, default, 0));

    public static implicit operator OptionalValueDatum<T>(ValueDatum<T> value) 
        => new OptionalValueDatum<T>(OptionalValueDatumMode.Success, default, value);

    //public static implicit operator Optional<T>((T Value, Meaning Meaning) args) => new Optional<T>(OptionalMode.Success, args.Value, args.Meaning, 0);

    //public static implicit operator bool(OptionalValueDatum<T> that) 
    //    => that.Mode == OptionalValueDatumMode.Success;
    public static bool operator true(OptionalValueDatum<T> that)
        => that.Mode == OptionalValueDatumMode.Success;
    public static bool operator false(OptionalValueDatum<T> that)
        => that.Mode != OptionalValueDatumMode.Success;

    public static explicit operator T(OptionalValueDatum<T> that)
        => (that.Mode == OptionalValueDatumMode.Success) 
        ? that.ValueDatum.Value
        : throw new InvalidCastException();

    public static implicit operator LogDatum(OptionalValueDatum<T> datum)
        => datum.Mode switch {
            OptionalValueDatumMode.Success => new LogDatum(DatumMode.Success, datum.ValueDatum.Meaning),
            _ => new LogDatum(DatumMode.NoValue, datum.NoValue.Meaning),
        };
}
