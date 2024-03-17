namespace Brimborium.TheMeaningOfLiff;

public partial record struct OptionalValueErrorDatum<V> {
    public static explicit operator V(OptionalValueErrorDatum<V> that)
        => (that.Mode == OptionalValueErrorDatumMode.Success)
        ? that.ValueDatum .Value
        : throw new InvalidCastException();

    public static explicit operator ErrorDatum(OptionalValueErrorDatum<V> that)
        => (that.Mode == OptionalValueErrorDatumMode.Error) ? that.ErrorDatum : throw new InvalidCastException();

    public static implicit operator OptionalValueErrorDatum<V>(NoDatum noDatum)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.NoValue, noDatum, default, default);

    public static implicit operator OptionalValueErrorDatum<V>(ValueDatum<V> value)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Success, default, value, default);

    public static implicit operator OptionalValueErrorDatum<V>(ErrorDatum error)
        => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Error, default, default, error);

    public static implicit operator OptionalValueErrorDatum<V>(V value)
        => new OptionalValueErrorDatum<V>(value);

    public static implicit operator OptionalValueErrorDatum<V>(OptionalValueDatum<V> value)
        => ((value.Mode) switch {
            OptionalValueDatumMode.Success => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Success, default, value.ValueDatum, default),
            OptionalValueDatumMode.NoValue => new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.NoValue, value.NoValue, default, default),
            _=> throw new InvalidCastException()
        });

    public static implicit operator OptionalValueErrorDatum<V>(ValueErrorDatum<V> value) {
        if (value.TryGetValue(out var valueDatum, out var errorDatum)) {
            return new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Success, default, valueDatum, default);
        } else {
            return new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Error, default, default, errorDatum);
        }
    }

    public static implicit operator OptionalValueErrorDatum<V>(OptionalErrorDatum value) {
        if (value.TryGetNoDatum(out var noDatum, out var errorDatum)) {
            return new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.NoValue, noDatum, default, default);
        } else {
            return new OptionalValueErrorDatum<V>(OptionalValueErrorDatumMode.Error, default, default, errorDatum);
        }
    }

    public static implicit operator LogDatum(OptionalValueErrorDatum<V> datum)
    => datum.Mode switch {
        OptionalValueErrorDatumMode.Success => new LogDatum(DatumMode.Success, datum.ValueDatum.Meaning),
        OptionalValueErrorDatumMode.Error => new LogDatum(DatumMode.Error, datum.ErrorDatum.Meaning),
        _ => new LogDatum(DatumMode.NoValue, datum.NoValue.Meaning),
    };

}
