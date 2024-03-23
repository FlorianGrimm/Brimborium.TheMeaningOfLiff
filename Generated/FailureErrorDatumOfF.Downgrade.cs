namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct FailureErrorDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == FailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == FailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out ErrorDatum errorDatum){
        if (this.Mode == FailureErrorMode.Failure) {
            failureDatum = this.FailureDatum;
            errorDatum = default;
            return true;
        } else {
            failureDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == FailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == FailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out FailureDatum<F> failureDatum){
        if (this.Mode == FailureErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            failureDatum = default;
            return true;
        } else {
            errorDatum = default;
            failureDatum = this.FailureDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
