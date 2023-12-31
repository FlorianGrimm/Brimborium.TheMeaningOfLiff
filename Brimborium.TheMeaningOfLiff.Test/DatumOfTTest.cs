using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brimborium.TheMeaningOfLiff;

public class DatumOfTTest {
    [Fact]
    public void DatumOfTTest01() {
        var meaning = MeaningPool.Get("Test", "DatumErrorTest");
        var sut = new Datum<int>(42, meaning, 1);

        Assert.Equal(42, sut.Value);
        Assert.StrictEqual(meaning, meaning);
        Assert.Equal(1, sut.LogicalTimestamp);
    }
}
