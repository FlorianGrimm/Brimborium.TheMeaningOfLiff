namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ErrorDatum {

    // generated 5 switch

    public ErrorDatum Switch(
        ErrorDatum defaultValue,
        Func<ErrorDatum, ErrorDatum>? funcError = default
        ) {
        try {
            return (this.Mode) switch {
                .Error => (funcError is not null) ? funcError(this.Error) : this.Error,
            _ => defaultValue
            };
        } catch (Exception error) {
            return ErrorDatum.CreateFromCatchedException(error).AsErrorDatum();
        }
    }

}
