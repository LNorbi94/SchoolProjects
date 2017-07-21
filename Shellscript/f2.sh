#!/bin/bash
echo "A program addig olvas be, amig vege szot nem gepel be."
i=0
be=''
touch ki.txt
while [[  "$be" != "vege"  ]]; do
    read -p "Kovetkezo szo: " be
    if test $be != "vege" ; then echo $be>>ki.txt ; fi
done
cat ki.txt|sort
