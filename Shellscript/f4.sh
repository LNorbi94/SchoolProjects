#!/bin/bash
ans="b"
e=$1
k=$3
if test $2 = "+" ; then ans=$(( e + k )) ; fi
if test $2 = "-" ; then ans=$((e - k )) ; fi
if test $2 = "/" ; then echo "$e/$k"|bc -l ; ans="." ; fi
if test $2 = "x" ; then ans=$(( e * k)) ; fi
if test $ans = "b" ; then echo "Rossz parameterek. N1 (muvelet) N2 formaban add meg. Pl. 2 + 5"
else echo $ans
fi
