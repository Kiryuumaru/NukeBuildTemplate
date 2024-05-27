using NukeBuildHelpers;

class Build : BaseNukeBuildHelpers
{
    public static int Main() => Execute<Build>(x => x.Version);

    public override string[] EnvironmentBranches { get; } = ["prerelease", "master"];

    public override string MainEnvironmentBranch => "master";
}
