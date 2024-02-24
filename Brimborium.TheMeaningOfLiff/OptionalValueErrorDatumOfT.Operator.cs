namespace Brimborium.TheMeaningOfLiff;

public partial record struct OptionalValueErrorDatum<T> {
    public static explicit operator T(OptionalValueErrorDatum<T> that)
        => (that.Mode == OptionalValueErrorDatumMode.Success)
        ? that.ValueDatum .Value
        : throw new InvalidCastException();

    public static explicit operator ErrorDatum(OptionalValueErrorDatum<T> that)
        => (that.Mode == OptionalValueErrorDatumMode.Error) ? that.ErrorDatum : throw new InvalidCastException();

    public static implicit operator OptionalValueErrorDatum<T>(NoDatum noDatum)
        => new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.NoValue, noDatum, default, default);

    public static implicit operator OptionalValueErrorDatum<T>(ValueDatum<T> value)
        => new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Success, default, value, default);

    public static implicit operator OptionalValueErrorDatum<T>(ErrorDatum error)
        => new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Error, default, default, error);

    public static implicit operator OptionalValueErrorDatum<T>(T value)
        => new OptionalValueErrorDatum<T>(value);

    public static implicit operator OptionalValueErrorDatum<T>(OptionalValueDatum<T> value)
        => ((value.Mode) switch {
            OptionalValueDatumMode.Success => new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Success, default, value.ValueDatum, default),
            OptionalValueDatumMode.NoValue => new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.NoValue, value.NoValue, default, default),
            _=> throw new InvalidCastException()
        });

    public static implicit operator OptionalValueErrorDatum<T>(ValueErrorDatum<T> value) {
        if (value.TryGetValue(out var valueDatum, out var errorDatum)) {
            return new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Success, default, valueDatum, default);
        } else {
            return new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Error, default, default, errorDatum);
        }
    }

    public static implicit operator OptionalValueErrorDatum<T>(OptionalErrorDatum value) {
        if (value.TryGetNoDatum(out var noDatum, out var errorDatum)) {
            return new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.NoValue, noDatum, default, default);
        } else {
            return new OptionalValueErrorDatum<T>(OptionalValueErrorDatumMode.Error, default, default, errorDatum);
        }
    }

    public static implicit operator LogDatum(OptionalValueErrorDatum<T> datum)
    => datum.Mode switch {
        OptionalValueErrorDatumMode.Success => new LogDatum(DatumMode.Success, datum.ValueDatum.Meaning),
        OptionalValueErrorDatumMode.Error => new LogDatum(DatumMode.Error, datum.ErrorDatum.Meaning),
        _ => new LogDatum(DatumMode.NoValue, datum.NoValue.Meaning),
    };

}
