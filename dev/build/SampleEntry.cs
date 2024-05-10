using NukeBuildHelpers;
using NukeBuildHelpers.Attributes;
using NukeBuildHelpers.Enums;

namespace _build;

public class SampleEntry : AppEntry<Build>
{
    public override bool RunParallel => false;

    public override RunsOnType BuildRunsOn => RunsOnType.Ubuntu2204;

    public override RunsOnType PublishRunsOn => RunsOnType.Ubuntu2204;

    [SecretHelper("GITHUB_TOKEN")]
    readonly string GithubToken;

    public override void Build()
    {

    }

    public override void Publish()
    {

    }
}
