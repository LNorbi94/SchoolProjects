#!/bin/bash
echo "Osszesen bejelentkezettek szama:"
who|wc -l
echo "Egyedi bejelentkezesek:"
who|sed 's/ .*//'|uniq|wc -l
