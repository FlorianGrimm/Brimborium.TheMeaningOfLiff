namespace Brimborium.TheMeaningOfLiff;

#if Orleans
[Orleans.Alias(nameof(NoDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public readonly partial record struct NoDatum;


[Orleans.Alias("Datum")]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public readonly partial record struct ValueDatum<V>;

[Orleans.Alias("OptionalDatum")]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public readonly partial record struct OptionalValueDatum<V>;

[Orleans.Alias(nameof(ErrorDatum))]
[Orleans.Immutable()]
[Orleans.GenerateSerializer(GenerateFieldIds = Orleans.GenerateFieldIds.None, IncludePrimaryConstructorParameters = false)]
public readonly partial record struct ErrorDatum;

[Orleans.Alias("ValueErrorDatum")]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public readonly partial record struct ValueErrorDatum<T>;

[Orleans.Alias(nameof(OptionalErrorDatum))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public partial record struct OptionalErrorDatum;

[Orleans.Alias("OptionalValueErrorDatum")]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public partial record struct OptionalValueErrorDatum<V>;

[Orleans.Alias(nameof(FlowCondition))]
[Orleans.Immutable]
[Orleans.GenerateSerializer]
public readonly partial record struct FlowCondition;
#endif
