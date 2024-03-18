namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct NoDatum {

    // generated 5 switch

    public NoDatum Switch(
        NoDatum defaultValue,
        Func<NoDatum>? funcOptional = default
        ) {
        {
            return (this.Mode) switch {
                .NoValue => (funcOptional is not null) ? funcOptional() : defaultValue,
            _ => defaultValue
            };
        }
    }

}
