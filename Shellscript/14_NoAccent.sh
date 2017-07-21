#!/bin/bash
read -p "Melyik fajlt konvertaljam at? (legyen ebben a konyvarban) " fname
cat $fname|tr 'áőöóúüúűéí' 'aooouuuuei' >$fname"_ekezetnelkul"
echo "Ekezetek eltavolitva, mentve "$fname"_ekezetnelkul neven."
