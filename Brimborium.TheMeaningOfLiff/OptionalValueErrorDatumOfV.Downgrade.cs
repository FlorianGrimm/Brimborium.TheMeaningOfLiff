namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalValueErrorDatum<V>{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalValueErrorMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out ValueErrorDatum<V> valueErrorDatum){
        if (this.Mode == OptionalValueErrorMode.NoValue) {
            optionalDatum = this.Optional;
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
                this.Value,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> value){
        if (this.Mode == OptionalValueErrorMode.Value) {
            value = this.Value;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValue(out ValueDatum<V> valueDatum, out OptionalErrorDatum optionalErrorDatum){
        if (this.Mode == OptionalValueErrorMode.Value) {
            valueDatum = this.Value;
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
                this.Optional,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == OptionalValueErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out OptionalValueDatum<V> optionalValueDatum){
        if (this.Mode == OptionalValueErrorMode.Error) {
            errorDatum = this.Error;
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
                this.Optional,
                this.Value
                );
            return false;
        }
    }

}
