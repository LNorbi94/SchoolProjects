#!/bin/bash
if test `echo "$1"|grep "*"|wc -l` -ge 1 ; then echo "Tartalmazza a * karaktert."
else echo "Nem tartalmazza a * karaktert." ; fi
