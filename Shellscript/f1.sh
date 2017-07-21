#!/bin/bash
#for (( i = 0 ; i < 5 ; i++ ))
#do
#	num=$(( ( RANDOM % 5 )  + 1 ))
#	lotto[$i]="$num"
#	echo ${lotto[$i]}
#done
array=( `seq 1 90|shuf -n 5` )
for (( i = 0; i < 5 ; i++ ))
do
	echo ${array[$i]}
done
