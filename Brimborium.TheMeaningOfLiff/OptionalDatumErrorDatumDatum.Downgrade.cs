namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalDatumErrorDatumDatum{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum(out NoDatum optional){
        if (this.Mode == OptionalDatumErrorDatumMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum(out NoDatum optionalDatum, out ErrorDatum errorDatum){
        if (this.Mode == OptionalDatumErrorDatumMode.NoValue) {
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
        if (this.Mode == OptionalDatumErrorDatumMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum(out ErrorDatum errorDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalDatumErrorDatumMode.Error) {
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
