namespace Brimborium.TheMeaningOfLiff;

public enum OptionalResultMode { NoValue, Success, Error }

[method: JsonConstructor]
public record struct OptionalDatumError<T>(
    OptionalResultMode Mode,
    [property: AllowNull][AllowNull] NoDatum NoValue,
    [property: AllowNull][AllowNull] Datum<T> Value,
    [property: AllowNull][AllowNull] ErrorValue ErrorValue
    )
    : IDatum<T>
    , IOptionalValueWithError<T, OptionalDatum<T>>
    , ILogicalTimestamp {
    //[JsonInclude]
    //public readonly OptionalResultMode Mode;
    //[JsonInclude]
    //[AllowNull] public readonly T Value;
    //[JsonInclude]
    //[AllowNull] public readonly ErrorValue Error;

    //public long LogicalTimestamp;


    //public long LogicalTimestamp => ((this.Mode) switch => {
    //    OptionalResultMode.=> this.LogicalTimestamp,
    //    _=>0
    //});

    public OptionalDatumError()
        : this(OptionalResultMode.NoValue, new NoDatum(), default, default) { }

    public OptionalDatumError(T value, Meaning? meaning = default, long logicalTimestamp = 0)
        : this(OptionalResultMode.Success, default, new Datum<T>(value, meaning, logicalTimestamp), default) {
    }

    public OptionalDatumError(NoDatum value) : this(OptionalResultMode.NoValue, value, default, default) { }

    public OptionalDatumError(Datum<T> value) : this(OptionalResultMode.Success, default, value, default) { }

    public OptionalDatumError(ErrorValue errorValue) : this(OptionalResultMode.Error, default, default, errorValue) { }

    //T IValue<T>.Value => this.Value;
    readonly T IDatum<T>.Value => this.Mode switch {
        OptionalResultMode.NoValue => throw new NoValueAccessingException(),
        OptionalResultMode.Success => this.Value.Value,
        OptionalResultMode.Error => this.ErrorValue.ThrowNotReturn<T>(),
        _ => default!
    };

    public readonly Meaning? Meaning => (this.Mode) switch {
        OptionalResultMode.NoValue => this.NoValue.Meaning,
        OptionalResultMode.Success => this.Value.Meaning,
        OptionalResultMode.Error => this.ErrorValue.Meaning,
        _ => default
    };

    public readonly long LogicalTimestamp => (this.Mode) switch {
        OptionalResultMode.NoValue => this.NoValue.LogicalTimestamp,
        OptionalResultMode.Success => this.Value.LogicalTimestamp,
        OptionalResultMode.Error => this.ErrorValue.LogicalTimestamp,
        _ => 0
    };

    // TODO: better?    OptionalErrorValue
    public readonly void Deconstruct(out OptionalResultMode mode, out T? value, out OptionalErrorValue error, out long logicalTimestamp) {
        switch (this.Mode) {
            case OptionalResultMode.Success:
                mode = OptionalResultMode.Success;
                value = this.Value;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
            case OptionalResultMode.Error:
                mode = OptionalResultMode.Error;
                value = default;
                error = this.ErrorValue;
                logicalTimestamp = this.ErrorValue.LogicalTimestamp;
                return;
            default:
                mode = OptionalResultMode.NoValue;
                value = default;
                error = default;
                logicalTimestamp = this.LogicalTimestamp;
                return;
        }
    }

    public readonly bool TryGetNoValue() {
        if (this.Mode == OptionalResultMode.NoValue) {
            return true;
        } else if (this.Mode == OptionalResultMode.Success) {
            return false;
        } else if (this.Mode == OptionalResultMode.Error) {
            return false;
        } else {
            return true;
        }
    }

    public readonly bool TryGetNoValue([MaybeNullWhen(true)] out T value) {
        if (this.Mode == OptionalResultMode.Success) {
            value = this.Value!;
            return false;
        } else {
            value = default;
            return true;
        }
    }

    public readonly bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == OptionalResultMode.Success) {
            value = this.Value!;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public readonly bool TryGetError([MaybeNullWhen(false)] out ErrorValue error) {
        if (this.Mode == OptionalResultMode.Error) {
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
        if (this.Mode == OptionalResultMode.Error) {
            errorValue = this.ErrorValue!;
            value = default;
            return true;
        } else if (this.Mode == OptionalResultMode.Success) {
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


    public static implicit operator bool(OptionalDatumError<T> that) => that.Mode == OptionalResultMode.Success;

    public static bool operator true(OptionalDatumError<T> that) => that.Mode == OptionalResultMode.Success;

    public static bool operator false(OptionalDatumError<T> that) => that.Mode != OptionalResultMode.Success;

    public static explicit operator T(OptionalDatumError<T> that) => (that.Mode == OptionalResultMode.Success) ? that.Value : throw new InvalidCastException();

    public static explicit operator ErrorValue(OptionalDatumError<T> that) => (that.Mode == OptionalResultMode.Error) ? that.ErrorValue : throw new InvalidCastException();

    public static implicit operator OptionalDatumError<T>(NoDatum noValue) => new OptionalDatumError<T>();

    public static implicit operator OptionalDatumError<T>(T value) => new OptionalDatumError<T>(value);

    public static implicit operator OptionalDatumError<T>(Exception error) => new OptionalDatumError<T>(new ErrorValue(error, default, default, 0, false));

    public static implicit operator OptionalDatumError<T>(ErrorValue error) => new OptionalDatumError<T>(error);

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
