namespace Brimborium.TheMeaningOfLiff;

public interface IWithMeaning {
    Brimborium.TheMeaningOfLiff.Meaning? Meaning { get; }
}

// TODO: WEICHEI
//public interface IWithMeaning<T> : IWithMeaning {
//    T Value { get; }
//    // Brimborium.TheMeaningOfLiff.Meaning? Meaning { get; }
//}

//public record class PropertyMeaning<T>(
//    T Value,
//    Brimborium.TheMeaningOfLiff.Meaning? Meaning
//    ) : IWithMeaning;

//public record struct ValueMeaning<T>(
//    T Value,
//    Brimborium.TheMeaningOfLiff.Meaning? Meaning 
//    ): IWithMeaning;