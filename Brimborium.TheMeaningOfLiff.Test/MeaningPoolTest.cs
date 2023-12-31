namespace Brimborium.TheMeaningOfLiff;

public class MeaningPoolTest {
    [Fact]
    public void MeaningPool001() {
        var sut = new MeaningPool();
        var act1 = sut.GetMeaning("a", "b");
        Assert.Equal("a", act1.Context);
        Assert.Equal("b", act1.Name);

        var act2 = sut.GetMeaning("a", "b");
        Assert.Same(act1, act2);
    }
}
