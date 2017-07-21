#!/bin/bash
read -p "Milyen stringet keresel? " string
grep "$string" *.txt|wc -l
