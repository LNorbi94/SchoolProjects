#!/bin/bash
if test `gawk -F: '{ print $1 }' /etc/passwd|grep "$1"` ; then echo "Van ilyen felhasznalo." ; fi
if test `who|grep "^$1"|wc -l` -ge 1 ; then echo "Be van jelentkezve."
echo "Terminal: "
who|grep "^$1"|cut -f2 -d' '|head -1 ; fi
