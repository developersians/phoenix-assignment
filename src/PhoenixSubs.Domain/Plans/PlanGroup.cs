using System.ComponentModel;

namespace PhoenixSubs.Domain;

public enum PlanGroup
{
    [Description("Bronze subscription")]
    Bronze = 1,

    [Description("Silver subscription")]
    Silver = 2,

    [Description("Gold subscription")]
    Gold = 3,

    [Description("Platinum subscription")]
    Platinum = 4,
}
