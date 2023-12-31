namespace Brimborium.TheMeaningOfLiff;

public enum OptionalDatumErrorMode { NoValue, Success, Error }

[method: JsonConstructor]
public record struct OptionalDatumError<T>(
    OptionalDatumErrorMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] Datum<T> Value,
    [property: AllowNull][AllowNull] ErrorValue ErrorValue
    )
    : IDatum<T>
    , IOptionalValueWithError<T, OptionalDatum<T>>
    , ILogicalTimestamp {

    public OptionalDatumError()
        : this(OptionalDatumErrorMode.NoValue, new NoDatum(), default, default) { }

    public OptionalDatumError(T value, Meaning? meaning = default, long logicalTimestamp = 0)
        : this(OptionalDatumErrorMode.Success, default, new Datum<T>(value, meaning, logicalTimestamp), default) {
    }

    public OptionalDatumError(NoDatum value) : this(OptionalDatumErrorMode.NoValue, value, default, default) { }

    public OptionalDatumError(Datum<T> value) : this(OptionalDatumErrorMode.Success, default, value, default) { }

    public OptionalDatumError(ErrorValue errorValue) : this(OptionalDatumErrorMode.Error, default, default, errorValue) { }

    //T IValue<T>.Value => this.Value;
    readonly T IDatum<T>.Value => this.Mode switch {
        OptionalDatumErrorMode.NoValue => throw new NoValueAccessingException(),
        OptionalDatumErrorMode.Success => this.Value.Value,
        OptionalDatumErrorMode.Error => this.ErrorValue.ThrowNotReturn<T>(),
        _ => default!
    };

    public readonly Meaning? Meaning => (this.Mode) switch {
        OptionalDatumErrorMode.NoValue => this.NoValue.Meaning,
        OptionalDatumErrorMode.Success => this.Value.Meaning,
        OptionalDatumErrorMode.Error => this.ErrorValue.Meaning,
        _ => default
    };

    public readonly long LogicalTimestamp => (this.Mode) switch {
        OptionalDatumErrorMode.NoValue => this.NoValue.LogicalTimestamp,
        OptionalDatumErrorMode.Success => this.Value.LogicalTimestamp,
        OptionalDatumErrorMode.Error => this.ErrorValue.LogicalTimestamp,
        _ => 0
    };

    // TODO: better?    OptionalErrorValue
    public readonly void Deconstruct(out OptionalDatumErrorMode mode, out T? value, out OptionalErrorValue error, out long logicalTimestamp) {
        switch (this.Mode) {
            case OptionalDatumErrorMode.Success:
                mode = OptionalDatumErrorMode.Success;
                value = this.Value;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
            case OptionalDatumErrorMode.Error:
                mode = OptionalDatumErrorMode.Error;
                value = default;
                error = this.ErrorValue;
                logicalTimestamp = this.ErrorValue.LogicalTimestamp;
                return;
            default:
                mode = OptionalDatumErrorMode.NoValue;
                value = default;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
        }
    }

    public readonly bool TryGetNoValue() {
        if (this.Mode == OptionalDatumErrorMode.NoValue) {
            return true;
        } else if (this.Mode == OptionalDatumErrorMode.Success) {
            return false;
        } else if (this.Mode == OptionalDatumErrorMode.Error) {
            return false;
        } else {
            return true;
        }
    }

    public readonly bool TryGetNoValue([MaybeNullWhen(true)] out T value) {
        if (this.Mode == OptionalDatumErrorMode.Success) {
            value = this.Value!;
            return false;
        } else {
            value = default;
            return true;
        }
    }

    public readonly bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == OptionalDatumErrorMode.Success) {
            value = this.Value!;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public readonly bool TryGetError([MaybeNullWhen(false)] out ErrorValue error) {
        if (this.Mode == OptionalDatumErrorMode.Error) {
            System.Diagnostics.Debug.Assert(this.ErrorValue.Exception is not null);
            error = this.ErrorValue!;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public readonly bool TryGetError(
        [MaybeNullWhen(false)] out ErrorValue errorValue,
        [MaybeNullWhen(true)] out OptionalDatum<T> value) {
        if (this.Mode == OptionalDatumErrorMode.Error) {
            errorValue = this.ErrorValue!;
            value = default;
            return true;
        } else if (this.Mode == OptionalDatumErrorMode.Success) {
            errorValue = default;
            value = new OptionalDatum<T>(OptionalDatumMode.Success, default, this.Value);
            return false;
        } else {
            errorValue = default;
            value = new OptionalDatum<T>(OptionalDatumMode.NoValue, this.NoValue, default);
            return false;
        }
    }

    public readonly OptionalDatumError<T> WithNoValue() => new OptionalDatumError<T>();

    public readonly OptionalDatumError<T> WithValue(T value) => new OptionalDatumError<T>(value);

    public readonly OptionalDatumError<T> WithError(ErrorValue error) => new OptionalDatumError<T>(error);


    public static implicit operator bool(OptionalDatumError<T> that) => that.Mode == OptionalDatumErrorMode.Success;

    public static bool operator true(OptionalDatumError<T> that) => that.Mode == OptionalDatumErrorMode.Success;

    public static bool operator false(OptionalDatumError<T> that) => that.Mode != OptionalDatumErrorMode.Success;

    public static explicit operator T(OptionalDatumError<T> that) => (that.Mode == OptionalDatumErrorMode.Success) ? that.Value : throw new InvalidCastException();

    public static explicit operator ErrorValue(OptionalDatumError<T> that) => (that.Mode == OptionalDatumErrorMode.Error) ? that.ErrorValue : throw new InvalidCastException();

    public static implicit operator OptionalDatumError<T>(NoDatum noValue) => new OptionalDatumError<T>();
    public static implicit operator OptionalDatumError<T>(Datum<T> value) => new OptionalDatumError<T>(OptionalDatumErrorMode.Success, default, value, default);
    public static implicit operator OptionalDatumError<T>(ErrorValue error) => new OptionalDatumError<T>(OptionalDatumErrorMode.Error, default, default, error);

    public static implicit operator OptionalDatumError<T>(T value) => new OptionalDatumError<T>(value);

    public static implicit operator OptionalDatumError<T>(Exception error) => new OptionalDatumError<T>(new ErrorValue(error, default, default, 0, false));


    public static implicit operator OptionalDatumError<T>(DatumError<T> value) {
        if (value.TryGetValue(out var successValue)) {
            return new OptionalDatumError<T>(successValue);
        } else if (value.TryGetError(out var errorValue)) {
            return new OptionalDatumError<T>(errorValue);
        } else {
            return new OptionalDatumError<T>(new InvalidEnumArgumentException($"Invalid enum {value.Mode}."));
        }
    }
}
