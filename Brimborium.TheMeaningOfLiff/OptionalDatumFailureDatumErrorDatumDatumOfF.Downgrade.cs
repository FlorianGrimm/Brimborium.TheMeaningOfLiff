namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumFailureDatumErrorDatumDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out FailureDatumErrorDatumDatum<F> failureDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            failureDatumErrorDatumDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureDatumErrorDatumDatum = new FailureDatumErrorDatumDatum<F>(
                ((this.Mode) switch {
                    OptionalDatumFailureDatumErrorDatumMode.Failure => FailureDatumErrorDatumMode.Failure,
                    OptionalDatumFailureDatumErrorDatumMode.Error => FailureDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalDatumErrorDatumDatum optionalDatumErrorDatumDatum){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalDatumErrorDatumDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatumErrorDatumDatum = new OptionalDatumErrorDatumDatum(
                ((this.Mode) switch {
                    OptionalDatumFailureDatumErrorDatumMode.NoValue => OptionalDatumErrorDatumMode.NoValue,
                    OptionalDatumFailureDatumErrorDatumMode.Error => OptionalDatumErrorDatumMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalDatumFailureDatumDatum<F> optionalDatumFailureDatumDatum){
        if (this.Mode == OptionalDatumFailureDatumErrorDatumMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalDatumFailureDatumDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalDatumFailureDatumDatum = new OptionalDatumFailureDatumDatum<F>(
                ((this.Mode) switch {
                    OptionalDatumFailureDatumErrorDatumMode.NoValue => OptionalDatumFailureDatumMode.NoValue,
                    OptionalDatumFailureDatumErrorDatumMode.Failure => OptionalDatumFailureDatumMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
