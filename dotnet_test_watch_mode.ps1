cls

$baseDirectory = Join-Path -Path (Get-Location) -ChildPath ""
$projectTestPath = Join-Path -Path (Get-Location) -ChildPath "Expectativas_de_Mercado.XUnit"
$sourceDirs = "$baseDirectory\Expectativas_de_Mercado.ViewModel;$baseDirectory\Expectativas_de_Mercado.Repository;$baseDirectory\Expectativas_de_Mercado.Model;"
$reportPath = Join-Path -Path (Get-Location) -ChildPath "Expectativas_de_Mercado.XUnit\TestResults"
$coverageXmlPath = Join-Path -Path (Join-Path -Path $projectTestPath -ChildPath "TestResults") -ChildPath "coveragereport"

# Função para matar processos com base no nome do processo que estajam em execução 
function Stop-ProcessesByName {
    $processes = Get-Process | Where-Object { $_.ProcessName -like 'dotnet*' } | Where-Object { $_.MainWindowTitle -eq '' }
    if ($processes.Count -gt 0) {
        $processes | ForEach-Object { Stop-Process -Id $_.Id -Force }
    }
}


function Remove-TestResults {    
    if (Test-Path $reportPath) {
        Remove-Item -Recurse -Force $reportPath
    }
}

 function Wait-TestResults {
    $REPEAT_WHILE = 0
    while (-not (Test-Path $reportPath)) {
        echo "Agaurdando TestResults..."
        Start-Sleep -Seconds 10        
        if ($REPEAT_WHILE -eq 6) { break }
        $REPEAT_WHILE = $REPEAT_WHILE + 1
    }

    $REPEAT_WHILE = 0
    while (-not (Test-Path $coverageXmlPath)) {
        echo "Agaurdando Coverage Report..."
        Start-Sleep -Seconds 10        
        if ($REPEAT_WHILE -eq 6) { break }
        $REPEAT_WHILE = $REPEAT_WHILE + 1
    }   

 } 

Stop-ProcessesByName
Remove-TestResults
dotnet clean slnPixCharge.sln > $null 2>&1
$watchProcess = Start-Process "dotnet" -ArgumentList "watch", "test", "./Expectativas_de_Mercado.XUnit/Expectativas_de_Mercado.XUnit.csproj", "--project ./Expectativas_de_Mercado.XUnit/Expectativas_de_Mercado.XUnit.csproj", "--collect:""XPlat Code Coverage;Format=opencover""", "/p:CollectCoverage=true", "/p:CoverletOutputFormat=cobertura" -PassThru
 Wait-TestResults
 Invoke-Item $coverageXmlPath\index.html
$watchProcess.WaitForExit()
Stop-ProcessesByName; 
Exit 