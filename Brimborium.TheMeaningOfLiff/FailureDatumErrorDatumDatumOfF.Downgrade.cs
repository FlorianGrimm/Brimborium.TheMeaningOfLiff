namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct FailureDatumErrorDatumDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == FailureDatumErrorDatumMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out ErrorDatum errorDatum){
        if (this.Mode == FailureDatumErrorDatumMode.Failure) {
            failureDatum = this.FailureDatum;
            errorDatum = default;
            return true;
        } else {
            failureDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == FailureDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == FailureDatumErrorDatumMode.Error) {
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
