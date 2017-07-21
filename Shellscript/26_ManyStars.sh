#!/bin/bash
for (( i=1; i<=$1; i++ ))
	do
		for (( j=1; j<=$i; j++ ))
		do
			Stars+='*'
		done
	echo "$Stars"
	Stars=""
	done
