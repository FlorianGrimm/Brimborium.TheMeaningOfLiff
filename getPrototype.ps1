$fa="D:\github.com\FlorianGrimm\Brimborium.TheMeaningOfLiff\Brimborium.TheMeaningOfLiff\bin\Debug\net8.0\Brimborium.TheMeaningOfLiff.dll"
$fb="D:\github.com\FlorianGrimm\Brimborium.TheMeaningOfLiff\Generated\bin\Debug\net8.0\Generated.dll"
$aa=[System.Reflection.Assembly]::LoadFrom($fa)
$ab=[System.Reflection.Assembly]::LoadFrom($fb)
$ta=$aa.GetTypes()| ?{$_.IsPublic}
$tb=$ab.GetTypes()| ?{$_.IsPublic}

function GetPrototype {
    param (
        [System.Type]$type
    )
    $type.GetMembers()|%{
        $m=$_
        $m
    }
}

$pa=$ta | %{
    $t=$_
    GetPrototype $t
}
$pb=$tb | %{
    $t=$_
    GetPrototype $t
}