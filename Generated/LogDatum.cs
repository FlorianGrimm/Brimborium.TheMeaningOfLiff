namespace Brimborium.TheMeaningOfLiff;

public enum DatumMode { NoValue, Success, Error }

[DebuggerNonUserCode]
public readonly partial record struct LogDatum(
    DatumMode Mode,
    string? Meaning
    )
    : IWithMeaning {

    public static implicit operator LogDatum(NoDatum datum)
        => new LogDatum(DatumMode.NoValue, datum.Meaning);

    public static implicit operator LogDatum(ErrorDatum datum)
        => new LogDatum(DatumMode.Error, datum.Meaning);

    public static implicit operator LogDatum(OptionalErrorDatum datum)
        => datum.Mode switch {
            OptionalErrorMode.Error => new LogDatum(DatumMode.Error, datum.Error.Meaning),
            _ => new LogDatum(DatumMode.NoValue, datum.Optional.Meaning),
        };

}

