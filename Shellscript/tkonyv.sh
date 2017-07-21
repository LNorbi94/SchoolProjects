#!/bin/bash
if [[ ! -f ./t.txt ]] ; then touch t.txt ; fi
n=0
echo "Menu:"
echo "1. add"
echo "2. list"
echo "3. keres"
echo "4. torol"
echo "5. kilep"
until [  $n -eq 5  ]
do
read -p "Adja meg a kert menu szamat: " n
case $n in
1) read -p "Adja meg a hozzaadni kivant nevet: " nev ; read -p "Adja meg a telefonszamat: " szam
if [[ `grep -F "$nev" t.txt` ]] ; then echo "Ilyen nev mar letezik." ; else echo "$nev:$szam">>t.txt ; fi
;;
2) cat t.txt
;;
3) read -p "Adja meg a nevet/telefonszamot: " keres
a=`awk -F':' '{ print $1 }' t.txt|grep "^$keres$"`
b=`awk -F':' '{ print $2 }' t.txt|grep "^$keres$"`
if [ "$a" == "$keres" ] || [ "$b" == "$keres" ]
then grep -F "$keres" t.txt
else echo "Nincs ilyen nev/telefonszam!" ; fi
;;
4) read -p "Adja meg a torolni kivant nevet/telefonszamot: " kerest
c=`awk -F':' '{ print $1 }' t.txt|grep "^$kerest$"`
d=`awk -F':' '{ print $2 }' t.txt|grep "^$kerest$"`
if [ "$c" == "$kerest" ] || [ "$d" == "$kerest" ]
then
echo "`grep -v "$kerest" t.txt`">t.txt
else echo "Nincs ilyen nev/telefonszam!" ; fi
;;
esac
done
sed -i '/^$/d' t.txt
