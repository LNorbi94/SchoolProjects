if (($args.Length -eq 0) -or ($args[0] -eq "--help"))
{
echo "A f�jl neve ut�n �rja be a mozgatni k�v�nt kiterjeszt�seket."
echo "Pl.: . pelda.ps1 png gif"
echo "A program kiv�logatja a jelenlegi k�nyvt�rb�l ezen kiterjeszt�seket ugyanilyen nev� almapp�ba, majd a mozgatott f�jlok neveit ki�rja egy eredmeny.log nev� f�jlba."
echo "Ezt a r�vid t�j�koztat�t el�rheti a --help param�terrel,"
echo "vagy a program param�ter n�lk�li megh�v�sa eset�n."
}
else {
foreach ($j in $args)
{
if (-Not (Get-ChildItem .\ -name *.$j))
{
$var=
echo "`nNem t�rt�nt mozgat�s." | Out-File eredmeny.log -Append
}
else{
$array= Get-ChildItem .\ -name *.$j
mkdir "$j"
 
foreach ($i in $array)
{
    Write-Output "`nA(z) $($i) nev� f�jl �t lett mozgatva a(z) $($j) k�nyvt�rba." | Out-File eredmeny.log -Append
    mv "$i" ./$j/
}
}
}
}