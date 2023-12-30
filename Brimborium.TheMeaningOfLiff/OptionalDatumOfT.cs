namespace Brimborium.TheMeaningOfLiff;

public enum OptionalDatumMode { NoValue, Success }

#if false
public readonly struct Optional<T>
    : IOptionalValue<T> {
    [JsonInclude]
    public readonly OptionalMode Mode;

    [EditorBrowsable(EditorBrowsableState.Never)]
    [JsonInclude]
    [AllowNull]
    public readonly T Value;

    public readonly Meaning Meaning;

    public Optional() {
        this.Mode = OptionalMode.NoValue;
        this.Value = default;
        this.Meaning = MeaningPool.Get(string.Empty, string.Empty);
    }

    public Optional(Meaning? meaning) {
        this.Mode = OptionalMode.NoValue;
        this.Value = default;
        this.Meaning = meaning ?? MeaningPool.Get(string.Empty, string.Empty);
    }

    public Optional(
        T value,
        Meaning? meaning = default
    ) {
        this.Mode = OptionalMode.Success;
        this.Value = value;
        this.Meaning = meaning ?? MeaningPool.Get(string.Empty, string.Empty);
    }

    [JsonConstructor]
    public Optional(
        OptionalMode Mode,
        [AllowNull]
        T Value,
        Meaning? meaning = default
    ) {
        if (Mode == OptionalMode.Success) {
            this.Mode = OptionalMode.Success;
            this.Value = Value;
        } else {
            this.Mode = OptionalMode.NoValue;
            this.Value = Value;
        }
        this.Meaning = meaning ?? MeaningPool.Get(string.Empty, string.Empty);
    }

    public void Deconstruct(out OptionalMode mode, [AllowNull] out T value) {
        mode = this.Mode;
        value = this.Value;
    }

    public bool TryGetNoValue() {
        return (this.Mode == OptionalMode.NoValue);
    }

    public bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == OptionalMode.NoValue) {
            value = default;
            return false;
        } else {
            value = this.Value!;
            return true;
        }
    }

    public T GetValueOrDefault(T defaultValue)
        => (this.Mode == OptionalMode.NoValue)
        ? defaultValue
        : this.Value!;


#pragma warning disable IDE0060 // Remove unused parameter
    public static implicit operator Optional<T>(NoValue value) => new Optional<T>();
#pragma warning restore IDE0060 // Remove unused parameter

    public static implicit operator Optional<T>(T value) => new Optional<T>(value);
    public static implicit operator Optional<T>((T Value, Meaning Meaning) args) => new Optional<T>(args.Value, args.Meaning);

    public static implicit operator bool(Optional<T> that) => that.Mode == OptionalMode.Success;
    public static bool operator true(Optional<T> that) => that.Mode == OptionalMode.Success;
    public static bool operator false(Optional<T> that) => that.Mode != OptionalMode.Success;

    public static explicit operator T(Optional<T> that) => (that.Mode == OptionalMode.Success) ? that.Value : throw new InvalidCastException();

}

#else

[method: JsonConstructor]
public readonly record struct OptionalDatum<T>(
        OptionalDatumMode Mode,
        [property: AllowNull][AllowNull] NoDatum NoValue,
        [property: AllowNull][AllowNull] Datum<T> Value
    )
    : IOptionalDatum<T>
    , IWithMeaning {

    public OptionalDatum(
        ) : this(OptionalDatumMode.NoValue, new NoDatum(), default) {
    }
    public OptionalDatum(
        Meaning? Meaning,
        long LogicalTimestamp
        ) : this(OptionalDatumMode.NoValue, new NoDatum(Meaning, LogicalTimestamp), default) {
    }

    public OptionalDatum(
        T value,
        Meaning? meaning = default,
        long logicalTimestamp = 0
        ) : this(OptionalDatumMode.Success, default, new Datum<T>(value, meaning, logicalTimestamp)) {
    }


    public Meaning? Meaning => (this.Mode) switch {
        OptionalDatumMode.NoValue => this.NoValue.Meaning,
        OptionalDatumMode.Success => this.Value.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalDatumMode.NoValue => this.Value.LogicalTimestamp,
        OptionalDatumMode.Success => this.Value.LogicalTimestamp,
        _ => 0
    };

    public bool TryGetNoValue() {
        return (this.Mode == OptionalDatumMode.NoValue);
    }

    public bool TryGetSuccessValue([MaybeNullWhen(false)] out Datum<T> value) {
        if (this.Mode == OptionalDatumMode.NoValue) {
            value = default;
            return false;
        } else {
            value = new Datum<T>(this.Value, this.Meaning, this.LogicalTimestamp);
            return true;
        }
    }


    public bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == OptionalDatumMode.NoValue) {
            value = default;
            return false;
        } else {
            value = this.Value!;
            return true;
        }
    }

    public T GetValueOrDefault(T defaultValue)
        => this.Mode switch {
            OptionalDatumMode.NoValue => defaultValue,
            OptionalDatumMode.Success => this.Value.Value,
            _ => defaultValue
        };


#pragma warning disable IDE0060 // Remove unused parameter
    public static implicit operator OptionalDatum<T>(NoDatum value) => new OptionalDatum<T>();
#pragma warning restore IDE0060 // Remove unused parameter

    public static implicit operator OptionalDatum<T>(T value) => new OptionalDatum<T>(OptionalDatumMode.Success, default, new Datum<T>(value, default, 0));

    //public static implicit operator Optional<T>((T Value, Meaning Meaning) args) => new Optional<T>(OptionalMode.Success, args.Value, args.Meaning, 0);

    public static implicit operator bool(OptionalDatum<T> that) => that.Mode == OptionalDatumMode.Success;
    public static bool operator true(OptionalDatum<T> that) => that.Mode == OptionalDatumMode.Success;
    public static bool operator false(OptionalDatum<T> that) => that.Mode != OptionalDatumMode.Success;

    public static explicit operator T(OptionalDatum<T> that) => (that.Mode == OptionalDatumMode.Success) ? that.Value : throw new InvalidCastException();
}
#endif