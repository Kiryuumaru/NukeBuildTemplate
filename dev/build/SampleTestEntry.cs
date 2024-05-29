using System;
using NukeBuildHelpers;
using NukeBuildHelpers.Enums;
using NukeBuildHelpers.Models.RunContext;

namespace _build;

class SampleTestEntry : AppTestEntry<Build>
{
    public override RunsOnType RunsOn => RunsOnType.Ubuntu2204;

    public override Type[] AppEntryTargets => [typeof(SampleEntry)];

    public override void Run(AppTestRunContext appTestContext)
    {

    }
}
