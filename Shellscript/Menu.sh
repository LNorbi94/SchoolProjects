#!/bin/bash
while true ; do
read -p "Melyik menut szeretne elerni? [1 - Datum; 2 - Naptar; 3 - Kilepes] " menu
case "$menu" in
1) date ;;
2) cal ;;
3) break ;;
esac
done
