namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalFailureErrorDatum<F>{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out FailureErrorDatum<F> failureErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optionalDatum = this.Optional;
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
                this.Failure,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out OptionalErrorDatum optionalErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failureDatum = this.Failure;
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
                this.Optional,
                this.Error
                );
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out OptionalFailureDatum<F> optionalFailureDatum){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            errorDatum = this.Error;
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
                this.Optional,
                this.Failure
                );
            return false;
        }
    }

}
