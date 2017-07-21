#!/bin/bash
read -p "Melyik parancs erdekel? " cmd
read -p "Hova irjam ki? [1 - Kepernyo; 2 - TxT directoryba] " num
if test $num -eq 1 ; then man $cmd ; fi
if test $num -eq 2 ; then man $cmd>$cmd".txt" ; fi
