#!/bin/bash
if test $# -ne 3 ; then echo "Hiba, nem harom parametert adott meg." ; fi
if test $# -eq 3 ; then echo $3;echo $2;echo $1 ; fi
