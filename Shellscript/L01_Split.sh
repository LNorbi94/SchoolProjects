#!/bin/bash
if [ $# -eq 0 ] || [ $1 == "--help" ]
then
echo "A fájl neve után írja be a mozgatni kívánt kiterjesztéseket."
echo "Pl.: . pelda.sh png gif"
echo "A program kiválogatja a jelenlegi könyvtárból ezen"
echo "kiterjesztéseket ugyanilyen nevű almappába, majd a mozgatott"
echo "fájlok neveit kiírja egy eredmeny.log nevű fájlba."
echo "Ezt a rövid tájékoztatót elérheti a --help paraméterrel,"
echo "vagy a program paraméter nélküli meghívása esetén."
else
for j in "$@"
do
if test ! `ls *.$j` ; then echo "Nem történt mozgatás.">>eredmeny.log ; else
IFS=!
array=(`find *.$j -printf %f!`)
mkdir $j

for i in ${array[*]}
do
	echo "A(z) "$i" nevű fájl át lett mozgatva a(z) "$j" könyvtárba.">>eredmeny.log
	mv "$i" ./$j/
done
fi
done
fi
