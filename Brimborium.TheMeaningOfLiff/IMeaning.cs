namespace Brimborium.TheMeaningOfLiff;

public interface IWithMeaning {
    Meaning? Meaning { get; }
}

// TODO: WEICHEI
public interface IWithMeaning<T> : IWithMeaning {
    T Value { get; }
    // Meaning? Meaning { get; }
}

public record class PropertyMeaning<T>(
    T Value,
    Meaning? Meaning
    ) : IWithMeaning;

public record struct ValueMeaning<T>(
    T Value,
    Meaning? Meaning 
    ): IWithMeaning;