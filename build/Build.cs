using NukeBuildHelpers;
using NukeBuildHelpers.Common.Attributes;
using NukeBuildHelpers.Entry;
using NukeBuildHelpers.Entry.Extensions;
using NukeBuildHelpers.Runner.Abstraction;

class Build : BaseNukeBuildHelpers
{
    public static int Main() => Execute<Build>(x => x.Interactive);

    public override string[] EnvironmentBranches { get; } = ["prerelease", "master"];

    public override string MainEnvironmentBranch => "master";

    [SecretVariable("GITHUB_TOKEN")]
    readonly string? GithubToken;

    BuildEntry BuildEntry => _ => _
        .AppId("sample_app")
        .RunnerOS(RunnerOS.Windows2022)
        .Execute(() =>
        {
            // build logic here
        });

    TestEntry TestEntry => _ => _
        .AppId("sample_app")
        .RunnerOS(RunnerOS.Ubuntu2204)
        .Execute(() =>
        {
            // test logic here
        });

    PublishEntry PublishEntry => _ => _
        .AppId("sample_app")
        .RunnerOS(RunnerOS.Ubuntu2204)
        .Execute(context =>
        {
            // publish logic here
        });
}
