namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalFailureErrorDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out FailureErrorDatum<F> failureErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            failureErrorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureErrorDatum = new FailureErrorDatum<F>(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.Failure => FailureErrorMode.Failure,
                    OptionalFailureErrorMode.Error => FailureErrorMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out OptionalErrorDatum optionalErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalErrorDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalErrorDatum = new OptionalErrorDatum(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.NoValue => OptionalErrorMode.NoValue,
                    OptionalFailureErrorMode.Error => OptionalErrorMode.Error,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out OptionalFailureDatum<F> optionalFailureDatum){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalFailureDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalFailureDatum = new OptionalFailureDatum<F>(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.NoValue => OptionalFailureMode.NoValue,
                    OptionalFailureErrorMode.Failure => OptionalFailureMode.Failure,
                    _ => throw new InvalidOperationException()
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
