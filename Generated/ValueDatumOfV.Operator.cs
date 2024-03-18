namespace Brimborium.TheMeaningOfLiff;

// generated 5

public readonly partial record struct ValueDatum<V> {

    // generated 5 switch

    public ValueDatum<OV> Switch<OV>(
        ValueDatum<OV> defaultValue,
        Func<ValueDatum<V>, ValueDatum<OV>>? funcValue = default
        ) {
        {
            return (this.Mode) switch {
                .Value => (funcValue is not null) ? funcValue(this.Value) : defaultValue,
            _ => defaultValue
            };
        }
    }

}
