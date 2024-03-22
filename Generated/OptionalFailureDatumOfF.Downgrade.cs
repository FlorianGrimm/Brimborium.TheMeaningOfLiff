namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalFailureDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            failureDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureDatum = this.FailureDatum;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum(out FailureDatum<F> failureDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalFailureMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatum = this.OptionalDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
