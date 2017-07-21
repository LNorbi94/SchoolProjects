#!/bin/bash
echo -e "x\tsin(x)\tcos(x)"
for x in {0..10}
do
sin=`echo "scale=5;s($x/10)" | bc -l`
cos=`echo "scale=5;c($x/10)" | bc -l`
n=`echo "scale=1;$x/10"|bc -l`
echo -e "$n\t$sin\t$cos"
done
