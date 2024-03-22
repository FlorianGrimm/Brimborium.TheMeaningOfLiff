namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumValueDatumFailureDatumErrorDatumDatum<V, F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ValueDatumFailureDatumErrorDatumDatum<V, F> valueDatumFailureDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            valueDatumFailureDatumErrorDatumDatum = default;
            return true;
        } else {
            optionalDatum = default;
            valueDatumFailureDatumErrorDatumDatum = new ValueDatumFailureDatumErrorDatumDatum<V, F>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => ValueDatumFailureDatumErrorDatumMode.Value,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => ValueDatumFailureDatumErrorDatumMode.Failure,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => ValueDatumFailureDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.ValueDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> value){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Value) {
            value = this.ValueDatum;
            return true;
        } else {
            value = default;
            return false;
        }
    }

    public bool TryGetValueDatum(out ValueDatum<V> valueDatum, out OptionalDatumFailureDatumErrorDatumDatum<F> optionalDatumFailureDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Value) {
            valueDatum = this.ValueDatum;
            optionalDatumFailureDatumErrorDatumDatum = default;
            return true;
        } else {
            valueDatum = default;
            optionalDatumFailureDatumErrorDatumDatum = new OptionalDatumFailureDatumErrorDatumDatum<F>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => OptionalDatumFailureDatumErrorDatumMode.NoValue,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => OptionalDatumFailureDatumErrorDatumMode.Failure,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => OptionalDatumFailureDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalDatumValueDatumErrorDatumDatum<V> optionalDatumValueDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalDatumValueDatumErrorDatumDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatumValueDatumErrorDatumDatum = new OptionalDatumValueDatumErrorDatumDatum<V>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => OptionalDatumValueDatumErrorDatumMode.NoValue,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => OptionalDatumValueDatumErrorDatumMode.Value,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Error => OptionalDatumValueDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalDatumValueDatumFailureDatumDatum<V, F> optionalDatumValueDatumFailureDatumDatum){
        if (this.Mode == OptionalDatumValueDatumFailureDatumErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalDatumValueDatumFailureDatumDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalDatumValueDatumFailureDatumDatum = new OptionalDatumValueDatumFailureDatumDatum<V, F>(
                ((this.Mode) switch {
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.NoValue => OptionalDatumValueDatumFailureDatumMode.NoValue,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Value => OptionalDatumValueDatumFailureDatumMode.Value,
                    OptionalDatumValueDatumFailureDatumErrorDatumMode.Failure => OptionalDatumValueDatumFailureDatumMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ValueDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
