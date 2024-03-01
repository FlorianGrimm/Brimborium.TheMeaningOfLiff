namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct OptionalErrorDatum{
    public bool TryGetOptional(out NoDatum optional){
        if (this.Mode == OptionalErrorMode.NoValue) {
            optional = this.Optional;
            return true;
        } else {
            optional = default;
            return false;
        }
    }

    public bool TryGetOptional(out NoDatum optionalDatum, out ErrorDatum errorDatum){
        if (this.Mode == OptionalErrorMode.NoValue) {
            optionalDatum = this.Optional;
            errorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            errorDatum = this.Error;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum error){
        if (this.Mode == OptionalErrorMode.Error) {
            error = this.Error;
            return true;
        } else {
            error = default;
            return false;
        }
    }

    public bool TryGetError(out ErrorDatum errorDatum, out NoDatum optionalDatum){
        if (this.Mode == OptionalErrorMode.Error) {
            errorDatum = this.Error;
            optionalDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalDatum = this.Optional;
            return false;
        }
    }

}
