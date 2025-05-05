
Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { Write-Error $_ -ErrorAction Continue; exit 1 }

$Root = (Get-Item .).FullName
$SolutionName = (Get-Item "$Root").Name
$NukeBuildTemplatePath = "$Root/.nuke/temp/NukeBuildTemplate"

if (Test-Path $NukeBuildTemplatePath){
   Remove-Item $NukeBuildTemplatePath -Recurse -Force
}
git clone https://github.com/Kiryuumaru/NukeBuildTemplate "$NukeBuildTemplatePath"

New-Item -ItemType Directory -Force -Path "$Root/.nuke"; Copy-Item -Force -Recurse -Container "$NukeBuildTemplatePath/.nuke/*" "$Root/.nuke"
New-Item -ItemType Directory -Force -Path "$Root/build"; Copy-Item -Force -Recurse -Container "$NukeBuildTemplatePath/build/*" "$Root/build"
Copy-Item -Force "$NukeBuildTemplatePath/build.cmd" "$Root/build.cmd"
Copy-Item -Force "$NukeBuildTemplatePath/build.ps1" "$Root/build.ps1"
Copy-Item -Force "$NukeBuildTemplatePath/build.sh" "$Root/build.sh"
Copy-Item -Force "$NukeBuildTemplatePath/global.json" "$Root/global.json"

$slnFiles = Get-ChildItem -Path "$Root" -Filter "*.sln" -File
if ($slnFiles) {
	dotnet sln add "$Root/build/_build.csproj" --solution-folder "_build.csproj"
} else {
	Copy-Item -Force "$NukeBuildTemplatePath/solution.sln" "$Root/$SolutionName.sln"
}
