namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalFailureDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out FailureDatum<F> failureDatum){
        if (this.Mode == OptionalFailureMode.NoValue) {
            optionalDatum = this.Optional;
            failureDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureDatum = this.Failure;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureMode.Failure) {
            failure = this.Failure;
            return true;
        } else {
            failure = default;
            return false;
        }
    }

    public bool TryGetFailure(out FailureDatum<F> failureDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalFailureMode.Failure) {
            failureDatum = this.Failure;
            optionalDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalDatum = this.Optional;
            return false;
        }
    }

}