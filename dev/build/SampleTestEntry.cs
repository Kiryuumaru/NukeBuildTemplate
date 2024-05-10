using System;
using NukeBuildHelpers;
using NukeBuildHelpers.Enums;

namespace _build;

public class SampleTestEntry : AppTestEntry<Build>
{
    public override bool RunParallel => false;

    public override RunsOnType RunsOn => RunsOnType.Ubuntu2204;

    public override Type[] AppEntryTargets => [typeof(SampleEntry)];

    public override void Run()
    {

    }
}
