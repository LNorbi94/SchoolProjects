#!/bin/bash
n=0
bool=1
num=$(( ( RANDOM % 100 )  + 1 ))
while (( bool ))
do
	read -p "Melyik szam az? " number
	if test $num -eq $number
	then bool=0
	else ((n++))
	if test $num -ge $number
	then echo "A szam nagyobb"
	else echo "A szam kissebb"
	fi
	fi 
done
echo "Kitalaltad! Probalkozasok szama:"
echo $n
