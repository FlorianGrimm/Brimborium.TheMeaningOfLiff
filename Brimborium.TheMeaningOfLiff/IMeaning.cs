﻿namespace Brimborium.TheMeaningOfLiff;

public interface IWithMeaning {
    string? Meaning { get; }
}

// TODO: WEICHEI
//public interface IWithMeaning<T> : IWithMeaning {
//    T Value { get; }
//    // string? Meaning { get; }
//}

//public record class PropertyMeaning<T>(
//    T Value,
//    string? Meaning
//    ) : IWithMeaning;

//public record struct ValueMeaning<T>(
//    T Value,
//    string? Meaning 
//    ): IWithMeaning;