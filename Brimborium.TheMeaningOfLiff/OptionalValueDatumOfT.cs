namespace Brimborium.TheMeaningOfLiff;

public enum OptionalValueDatumMode { NoValue, Success }

[DebuggerNonUserCode]
[method: JsonConstructor]
public readonly partial record struct OptionalValueDatum<T>(
        OptionalValueDatumMode Mode,
        [property: AllowNull][AllowNull] NoDatum NoValue,
        [property: AllowNull][AllowNull] ValueDatum<T> ValueDatum
    )
    : IOptionalDatum<T>
    , IWithMeaning {

    public OptionalValueDatum(
        ) : this(OptionalValueDatumMode.NoValue, new NoDatum(), default) {
    }
    public OptionalValueDatum(
        string? Meaning,
        long LogicalTimestamp
        ) : this(OptionalValueDatumMode.NoValue, new NoDatum(Meaning, LogicalTimestamp), default) {
    }

    public OptionalValueDatum(
        T value,
        string? meaning = default,
        long logicalTimestamp = 0
        ) : this(OptionalValueDatumMode.Success, default, new ValueDatum<T>(value, meaning, logicalTimestamp)) {
    }


    public string? Meaning => (this.Mode) switch {
        OptionalValueDatumMode.NoValue => this.NoValue.Meaning,
        OptionalValueDatumMode.Success => this.ValueDatum.Meaning,
        _ => default
    };

    public long LogicalTimestamp => (this.Mode) switch {
        OptionalValueDatumMode.NoValue => this.ValueDatum.LogicalTimestamp,
        OptionalValueDatumMode.Success => this.ValueDatum.LogicalTimestamp,
        _ => 0
    };

    public bool TryGetNoDatum() {
        return (this.Mode == OptionalValueDatumMode.NoValue);
    }

    public bool TryGetNoDatum([MaybeNullWhen(false)] out NoDatum noDatum) {
        if (this.Mode == OptionalValueDatumMode.NoValue) {
            noDatum = this.NoValue!;
            return true;
        } else {
            noDatum = this.NoValue;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<T> value) {
        if (this.Mode == OptionalValueDatumMode.NoValue) {
            value = default;
            return false;
        } else {
            value = this.ValueDatum;
            return true;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue([MaybeNullWhen(false)] out T value) {
        if (this.Mode == OptionalValueDatumMode.NoValue) {
            value = default;
            return false;
        } else {
            value = this.ValueDatum.Value;
            return true;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue([MaybeNullWhen(false)] out T value, [MaybeNullWhen(true)] out NoDatum noDatum) {
        if (this.Mode == OptionalValueDatumMode.NoValue) {
            value = default;
            noDatum = this.NoValue;
            return false;
        } else {
            value = this.ValueDatum.Value;
            noDatum = default;
            return true;
        }
    }

    public T GetValueOrDefaultValue(T defaultValue)
        => this.Mode switch {
            OptionalValueDatumMode.Success => this.ValueDatum.Value,
            _ => defaultValue
        };

    public OptionalValueDatum<T> OrDefaultDatum(
        T defaultValue, 
        string? meaning = default,
        long logicalTimestamp = 0)
      => this.Mode switch {
          OptionalValueDatumMode.Success => this,
          _ => new OptionalValueDatum<T>(defaultValue, meaning, logicalTimestamp),
      };

    public OptionalValueDatum<R> AsOptionalOfType<R>(
        string? meaning = default,
        long logicalTimestamp = 0) {
        if (this.TryGetValue(out var value, out var noValue)) {
            if (value is R valueR) {
                return new OptionalValueDatum<R>(OptionalValueDatumMode.Success, default, new ValueDatum<R>(valueR, meaning, logicalTimestamp));
            } else {
                return new NoDatum(meaning, logicalTimestamp);
            }
        } else {
            return noValue;
        }
    }
}
