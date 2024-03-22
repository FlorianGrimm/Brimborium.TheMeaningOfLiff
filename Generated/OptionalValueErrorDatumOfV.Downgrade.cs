namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueErrorDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalValueErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueErrorDatum<V> valueErrorDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalValueErrorMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalErrorDatum optionalErrorDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalValueErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalValueDatum<V> optionalValueDatum){
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
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
