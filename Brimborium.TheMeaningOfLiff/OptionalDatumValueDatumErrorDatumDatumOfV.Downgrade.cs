namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumValueDatumErrorDatumDatum<V>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueDatumErrorDatumDatum<V> valueDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueDatumErrorDatumDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueDatumErrorDatumDatum = new ValueDatumErrorDatumDatum<V>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumErrorDatumMode.Value => ValueDatumErrorDatumMode.Value,
                    OptionalDatumValueDatumErrorDatumMode.Error => ValueDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalDatumErrorDatumDatum optionalDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.Value) {
            valueDatum = this.ValueDatum;
            optionalDatumErrorDatumDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalDatumErrorDatumDatum = new OptionalDatumErrorDatumDatum(
                ((this.Mode) switch {
                    OptionalDatumValueDatumErrorDatumMode.NoValue => OptionalDatumErrorDatumMode.NoValue,
                    OptionalDatumValueDatumErrorDatumMode.Error => OptionalDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalDatumValueDatumDatum<V> optionalDatumValueDatumDatum){
        if (this.Mode == OptionalDatumValueDatumErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalDatumValueDatumDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalDatumValueDatumDatum = new OptionalDatumValueDatumDatum<V>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumErrorDatumMode.NoValue => OptionalDatumValueDatumMode.NoValue,
                    OptionalDatumValueDatumErrorDatumMode.Value => OptionalDatumValueDatumMode.Value,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum
                );
            return false;
        }
    }

}
