namespace Brimborium.TheMeaningOfLiff;

// generated 2 Downgrade

public readonly partial record struct OptionalFailureErrorDatum<F>{
    public NoDatum ToNoDatum()
        => new NoDatum(this.Meaning, this.LogicalTimestamp);

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optional){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optional = this.OptionalDatum;
            return true;
        } else {
            if (this.Mode == OptionalFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            optional = default;
            return false;
        }
    }

    public bool TryGetOptionalDatum([MaybeNullWhen(false)] out NoDatum optionalDatum, [MaybeNullWhen(true)] out FailureErrorDatum<F> failureErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.NoValue) {
            optionalDatum = this.OptionalDatum;
            failureErrorDatum = default;
            return true;
        } else {
            optionalDatum = default;
            failureErrorDatum = new FailureErrorDatum<F>(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.Failure => FailureErrorMode.Failure,
                    OptionalFailureErrorMode.Error => FailureErrorMode.Error,
                    OptionalFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.FailureDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failure){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failure = this.FailureDatum;
            return true;
        } else {
            if (this.Mode == OptionalFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            failure = default;
            return false;
        }
    }

    public bool TryGetFailureDatum([MaybeNullWhen(false)] out FailureDatum<F> failureDatum, [MaybeNullWhen(true)] out OptionalErrorDatum optionalErrorDatum){
        if (this.Mode == OptionalFailureErrorMode.Failure) {
            failureDatum = this.FailureDatum;
            optionalErrorDatum = default;
            return true;
        } else {
            failureDatum = default;
            optionalErrorDatum = new OptionalErrorDatum(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.NoValue => OptionalErrorMode.NoValue,
                    OptionalFailureErrorMode.Error => OptionalErrorMode.Error,
                    OptionalFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.ErrorDatum
                );
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum error){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            error = this.ErrorDatum;
            return true;
        } else {
            if (this.Mode == OptionalFailureErrorMode.Uninitialized) {
                throw new InvalidOperationException($"Mode:{this.Mode}");
            }
            error = default;
            return false;
        }
    }

    public bool TryGetErrorDatum([MaybeNullWhen(false)] out ErrorDatum errorDatum, [MaybeNullWhen(true)] out OptionalFailureDatum<F> optionalFailureDatum){
        if (this.Mode == OptionalFailureErrorMode.Error) {
            errorDatum = this.ErrorDatum;
            optionalFailureDatum = default;
            return true;
        } else {
            errorDatum = default;
            optionalFailureDatum = new OptionalFailureDatum<F>(
                ((this.Mode) switch {
                    OptionalFailureErrorMode.NoValue => OptionalFailureMode.NoValue,
                    OptionalFailureErrorMode.Failure => OptionalFailureMode.Failure,
                    OptionalFailureErrorMode.Uninitialized => throw new UninitializedException(),
                    _ => throw new InvalidOperationException($"Mode:{this.Mode}")
                }),
                this.OptionalDatum,
                this.FailureDatum
                );
            return false;
        }
    }

}
// generated 2 Downgrade
