using NukeBuildHelpers;
using NukeBuildHelpers.Attributes;
using NukeBuildHelpers.Enums;
using NukeBuildHelpers.Models.RunContext;

namespace _build;

class SampleEntry : AppEntry<Build>
{
    public override bool RunParallel => false;

    public override RunsOnType BuildRunsOn => RunsOnType.Ubuntu2204;

    public override RunsOnType PublishRunsOn => RunsOnType.Ubuntu2204;

    [SecretVariable("GITHUB_TOKEN")]
    readonly string GithubToken;

    public override void Build(AppRunContext appRunContext)
    {

    }

    public override void Publish(AppRunContext appRunContext)
    {

    }
}
