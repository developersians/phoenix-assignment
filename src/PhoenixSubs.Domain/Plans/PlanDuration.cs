using System.ComponentModel;

namespace PhoenixSubs.Domain;

public enum PlanDuration
{
    [Description("6 months duration")]
    SixMonth = 6,

    [Description("1 year duration")]
    TwelveMonth = 12,
}
