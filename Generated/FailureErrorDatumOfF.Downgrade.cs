namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct FailureErrorDatum<F>{
    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == FailureErrorMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out ErrorDatum errorDatum){
        if (this.Mode == FailureErrorMode.Failure) {
            failureDatum = this.Failure;
            errorDatum = default;
            return true;
        } else {
            failureDatum = default;
            errorDatum = this.Error;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == FailureErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == FailureErrorMode.Error) {
            errorDatum = this.Error;
            failureDatum = default;
            return true;
        } else {
            errorDatum = default;
            failureDatum = this.Failure;
            return false;
        }
    }

}
