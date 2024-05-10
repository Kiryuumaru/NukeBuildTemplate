using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using NukeBuildHelpers;
using NukeBuildHelpers.Attributes;
using NukeBuildHelpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _build;

public class SampleEntry : AppEntry<Build>
{
    public override bool RunParallel => false;

    public override RunsOnType BuildRunsOn => RunsOnType.Ubuntu2204;

    public override RunsOnType PublishRunsOn => RunsOnType.Ubuntu2204;

    [SecretHelper("NUGET_AUTH_TOKEN")]
    readonly string NuGetAuthToken;

    [SecretHelper("GITHUB_TOKEN")]
    readonly string GithubToken;
}
