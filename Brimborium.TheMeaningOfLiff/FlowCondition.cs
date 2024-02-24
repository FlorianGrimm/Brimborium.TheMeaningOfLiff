namespace Brimborium.TheMeaningOfLiff;

[DebuggerNonUserCode]
public readonly partial record struct FlowCondition(
        ValueDatum<bool> Condition,
        string Description
    ) {
    public static implicit operator bool(FlowCondition flowCondition) => flowCondition.Condition.Value;
    public static implicit operator FlowCondition(ValueDatum<bool> condition) => new FlowCondition(condition, string.Empty);
    public static implicit operator FlowCondition(bool condition) => new FlowCondition(new ValueDatum<bool>(condition), string.Empty);
}

public interface IFlowDecision<T> {
    FlowCondition Decision(
        T value,
        T comparative
        , string description);
}
