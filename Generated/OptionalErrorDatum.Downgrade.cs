namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalErrorDatum{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ErrorDatum errorDatum){
        if (this.Mode == OptionalErrorMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            errorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            errorDatum = this.ErrorDatum;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum error){
        if (this.Mode == OptionalErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalDatum = this.OptionalDatum;
            return false;
        }
    }

}
// generated 2 Downgrade
