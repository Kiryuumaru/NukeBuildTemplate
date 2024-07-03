# NukeBuildHelpersTemplate

NukeBuildTemplate is a project template repository for setting up build automation using NukeBuild. This template is designed to work seamlessly with GitHub Actions and Azure Pipelines, allowing for efficient CI/CD and release management across multiple projects and environments within a single repository.

**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|NukeBuildHelpers|[![NuGet](https://buildstats.info/nuget/NukeBuildHelpers?includePreReleases=true)](https://www.nuget.org/packages/NukeBuildHelpers/)|

## Features

- **Multi-project and Multi-environment Support**: Handle releases for multiple projects and environments in a single repository.
- **CI/CD Integration**: Generate GitHub Actions and Azure Pipelines workflows.
- **Automated Versioning**: Interactive CLI for bumping project versions with validation.
- **Flexible Build Flow**: Implement the target entries to create custom build flows.

## Quick Start

### Using the Template

1. Create a New Repository from Template

    Simply visit the [NukeBuildTemplate](https://github.com/Kiryuumaru/NukeBuildTemplate) repository on GitHub and click the `Use this template` button.

2. Clone the Repository
    
    ```
    git clone https://github.com/<your-username>/<your-repo>.git
    cd <your-repo>
    ```

### Configuring Your `Build.cs`

1. Define Environment Branches

    ```csharp
    class Build : BaseNukeBuildHelpers
    {
        ...

        public override string[] EnvironmentBranches { get; } = [ "prerelease", "master" ];

        public override string MainEnvironmentBranch { get; } = "master";
    }
    ```

2. Create custom build flows, implement any of the target entries `TestEntry`, `BuildEntry` or `PublishEntry`.

    ```csharp
    class Build : BaseNukeBuildHelpers
    {
        ...
        
        TestEntry TestEntry => _ => _
            .AppId("sample_app")
            .RunnerOS(RunnerOS.Ubuntu2204)
            .Execute(() =>
            {
                // test logic here
            });

        BuildEntry BuildEntry => _ => _
            .AppId("sample_app")
            .RunnerOS(RunnerOS.Windows2022)
            .Execute(() =>
            {
                // build logic here
            });

        PublishEntry PublishEntry => _ => _
            .AppId("sample_app")
            .RunnerOS(RunnerOS.Ubuntu2204)
            .Execute(context =>
            {
                // publish logic here
            });
    }
    ```

### Generating Workflows

- Generate GitHub and Azure Pipelines workflows using CLI commands:

    ```sh
    # Generate GitHub workflow
    build githubworkflow

    # Generate Azure Pipelines workflow
    build azureworkflow
    ```

    These commands will generate `azure-pipelines.yml` and `.github/workflows/nuke-cicd.yml` respectively.

### Bumping Project Version

- Use the `build bump` command to interactively bump the project version:

    ```sh
    build bump
    ```

## Versioning and Status

- The `Version` subcommand shows the current version from all releases. Example output from the subcommand:

    ```
    ╬═════════════════════╬═════════════╬════════════════════╬═════════════════════╬
    ║        App Id       ║ Environment ║   Bumped Version   ║      Published      ║
    ╬═════════════════════╬═════════════╬════════════════════╬═════════════════════╬
    ║ nuke_build_helpers  ║ prerelease  ║ 2.1.0-prerelease.1 ║ 2.0.0-prerelease.8* ║
    ║                     ║   master    ║ 2.0.0              ║         yes         ║
    ║---------------------║-------------║--------------------║---------------------║
    ║ nuke_build_helpers2 ║ prerelease  ║ 0.1.0-prerelease.2 ║         no          ║
    ║                     ║   master    ║ -                  ║         no          ║
    ╬═════════════════════╬═════════════╬════════════════════╬═════════════════════╬
    ```

- The `StatusWatch` subcommand continuously monitors the version status. Example output from the subcommand:
    
    ```
    ╬═════════════════════╬═════════════╬════════════════════╬═══════════════╬
    ║        App Id       ║ Environment ║      Version       ║    Status     ║
    ╬═════════════════════╬═════════════╬════════════════════╬═══════════════╬
    ║ nuke_build_helpers  ║ prerelease  ║ 2.1.0-prerelease.2 ║   Published   ║
    ║                     ║   master    ║ 2.0.0              ║   Published   ║
    ║---------------------║-------------║--------------------║---------------║
    ║ nuke_build_helpers2 ║ prerelease  ║ 0.1.0-prerelease.2 ║  Run Failed   ║
    ║                     ║   master    ║ -                  ║ Not published ║
    ╬═════════════════════╬═════════════╬════════════════════╬═══════════════╬
    ```

    Status types include:

    - **Run Failed:** The build encountered an error and did not complete successfully.
    - **Published:** The build was successfully published.
    - **Publishing:** The build is currently in the process of being published.
    - **Waiting for Queue:** The build is waiting in the queue to be processed.
    - **Not Published:** The build has not been published.

##  For More Information

For more information, visit the [NukeBuildHelpers](https://github.com/Kiryuumaru/NukeBuildHelpers) repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [NukeBuild](https://nuke.build/) for providing the foundation for this project.
