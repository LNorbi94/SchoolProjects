#!/bin/bash
echo "A program addig olvas be, amig ENTER-t nem gepel be."
while [[  "$be" != "ENTER"  ]]; do
	read -p "Keresett fajl/konyvtar: " be
	find ./ -maxdepth 1 -name "$be"
done
be=""
