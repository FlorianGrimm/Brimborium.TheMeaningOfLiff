namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalErrorDatum{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out ErrorDatum errorDatum){
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

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == OptionalErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == OptionalErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out NoDatum optionalDatum){
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
