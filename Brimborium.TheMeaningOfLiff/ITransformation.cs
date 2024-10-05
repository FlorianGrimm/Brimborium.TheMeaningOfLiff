namespace Brimborium.TheMeaningOfLiff;

public interface ITransformation<I, O> {
    O Then(I arg);
}

public interface ITransformationAsync<I, O> {
    ValueTask<O> ThenAsync(I arg);
}
