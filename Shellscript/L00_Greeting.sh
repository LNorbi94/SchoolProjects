#!/bin/bash
ido=`date +%H`
#read -p "Ido:" ido
echo $ido
#if test $ido -ge 6 -a $ido -le 9 ; then echo "Jo reggelt." ; fi
#if test $ido -ge 10 -a $ido -le 17 ; then echo "Jo napot." ; fi
#if test $ido -ge 18 -a $ido -le 21 ; then echo "Jo estet." ; fi
#if test $ido -ge 22 -a $ido -le 24 ; then echo "Jo ejt." ; fi
#if test $ido -ge 0 -a $ido -le 5 ; then echo "Jo ejt." ; fi
case "$ido" in
0[6-9])echo "Jo reggelt.";;
1[0-7])echo "Jo napot.";;
1[89]|2[01])echo "Jo estet.";;
2[23]|0[0-5])echo "Jo ejt.";;
esac
