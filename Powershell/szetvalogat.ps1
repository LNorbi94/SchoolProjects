if (($args.Length -eq 0) -or ($args[0] -eq "--help"))
{
echo "A fájl neve után írja be a mozgatni kívánt kiterjesztéseket."
echo "Pl.: . pelda.ps1 png gif"
echo "A program kiválogatja a jelenlegi könyvtárból ezen kiterjesztéseket ugyanilyen nevû almappába, majd a mozgatott fájlok neveit kiírja egy eredmeny.log nevû fájlba."
echo "Ezt a rövid tájékoztatót elérheti a --help paraméterrel,"
echo "vagy a program paraméter nélküli meghívása esetén."
}
else {
foreach ($j in $args)
{
if (-Not (Get-ChildItem .\ -name *.$j))
{
$var=
echo "`nNem történt mozgatás." | Out-File eredmeny.log -Append
}
else{
$array= Get-ChildItem .\ -name *.$j
mkdir "$j"
 
foreach ($i in $array)
{
    Write-Output "`nA(z) $($i) nevû fájl át lett mozgatva a(z) $($j) könyvtárba." | Out-File eredmeny.log -Append
    mv "$i" ./$j/
}
}
}
}