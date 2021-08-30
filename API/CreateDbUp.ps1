param($name);

$date = Get-Date;

$fileName = $date.ToString("yyyy-MM-dd-hh-mm-ss") + "-" + $name + ".sql";

$dir = Get-Location;

$location = $dir.ToString() + "\DbupScripts";

New-Item -Path $location -Name $fileName -ItemType "file";

$fileNameWithDir = $location + "\" + $fileName;

Invoke-Item -Path $fileNameWithDir; 
