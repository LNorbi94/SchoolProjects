#!/bin/bash
i=1
while [ $i -lt 8 ]; do
	p=`echo $PATH|gawk -F: '{ print $'$i' }'`
	find /$p -name "$1"
	let i=i+1
done
