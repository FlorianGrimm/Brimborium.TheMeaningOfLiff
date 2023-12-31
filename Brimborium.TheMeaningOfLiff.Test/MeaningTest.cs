namespace Brimborium.TheMeaningOfLiff;

public class MeaningTest {
    [Fact]
    public void MeaningPool001() {
        var sut = new Meaning("a", "b");
        Assert.Equal("a", sut.Context);
        Assert.Equal("b", sut.Name);
    }
}