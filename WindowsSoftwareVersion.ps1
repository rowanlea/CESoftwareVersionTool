$name = Read-Host -Prompt 'Input your full name: '
$version = Get-ComputerInfo OsName,OsVersion
$osName = $version[0].OsName
$osVersion = $version[0].OsVersion

Get-WmiObject -Class Win32_Product |
Select-Object -Property Name,Version,Vendor |
    Export-Csv -Path .\$name#$osName#$osVersion.csv -NoTypeInformation



