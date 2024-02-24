using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brimborium.TheMeaningOfLiff;

public readonly partial record struct FailureDatum<T>(
    [property: Orleans.Id(0)] T Value,
    [property: Orleans.Id(1)] string? Meaning = default,
    [property: Orleans.Id(2)] long LogicalTimestamp = 0
    )
    : IWithMeaning
    , ILogicalTimestamp {
}
