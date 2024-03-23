namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueErrorDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalValueErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out ValueErrorDatum<V> valueErrorDatum){
        if (this.Mode == OptionalValueErrorMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueErrorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueErrorDatum = new ValueErrorDatum<V>(
                ((this.Mode) switch {
                    OptionalValueErrorMode.Value => ValueErrorMode.Value,
                    OptionalValueErrorMode.Error => ValueErrorMode.Error,
                    OptionalValueErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> value){
        if (this.Mode == OptionalValueErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum([MaybeNullWhen(false)] out ValueDatum<V> valueDatum, [MaybeNullWhen(true)] out OptionalErrorDatum optionalErrorDatum){
        if (this.Mode == OptionalValueErrorMode.Value) {
            valueDatum = this.ValueDatum;
            optionalErrorDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalErrorDatum = new OptionalErrorDatum(
                ((this.Mode) switch {
                    OptionalValueErrorMode.NoValue => OptionalErrorMode.NoValue,
                    OptionalValueErrorMode.Error => OptionalErrorMode.Error,
                    OptionalValueErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == OptionalValueErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == OptionalValueErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out OptionalValueDatum<V> optionalValueDatum){
        if (this.Mode == OptionalValueErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalValueDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalValueDatum = new OptionalValueDatum<V>(
                ((this.Mode) switch {
                    OptionalValueErrorMode.NoValue => OptionalValueMode.NoValue,
                    OptionalValueErrorMode.Value => OptionalValueMode.Value,
                    OptionalValueErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

    public bool TryGetValue([MaybeNullWhen(false)] out V value, [MaybeNullWhen(true)] out OptionalErrorDatum elseDatum) {
        if (this.Mode == OptionalValueErrorMode.Value) {
            value = this.ValueDatum.Value;
            elseDatum = default;
            return true;
        } else if (this.Mode == OptionalValueErrorMode.NoValue) {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorMode.NoValue, this.OptionalDatum, default);
            return false;
        } else if (this.Mode == OptionalValueErrorMode.Error) {
            value = default;
            elseDatum = new OptionalErrorDatum(OptionalErrorMode.Error, default, this.ErrorDatum);
            return false;
        } else if (this.Mode == OptionalValueErrorMode.Uninitialized) {
            throw new UninitializedException();
        } else {
            throw new UninitializedException($"Mode:{this.Mode}");
        }
    }
}
// generated 2 Downgrade
