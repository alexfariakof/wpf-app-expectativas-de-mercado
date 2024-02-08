$projectTestPath = Get-Location
$projectPath =  (Resolve-Path -Path ..).Path
$sourceDirs = "$projectPath\Expectativas_de_Mercado.ViewModel;$projectPath\Expectativas_de_Mercado.Repository;$projectPath\Expectativas_de_Mercado.Model;$projectPath\Bacen.Integration;"
$reportPath = Join-Path -Path $projectTestPath -ChildPath "TestResults"
$coverageXmlPath = Join-Path -Path (Join-Path -Path $projectTestPath -ChildPath "TestResults") -ChildPath "coveragereport"

# Excuta Teste Unitarios sem restore e build e gera o relatório de cobertura do Backend
dotnet test ./Expectativas_de_Mercado.XUnit.csproj --results-directory $reportPath /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --collect:"XPlat Code Coverage;Format=opencover" --no-restore --no-build
reportgenerator -reports:$projectTestPath\coverage.cobertura.xml -targetdir:$coverageXmlPath -reporttypes:"Html;lcov;" -sourcedirs:$sourceDirs