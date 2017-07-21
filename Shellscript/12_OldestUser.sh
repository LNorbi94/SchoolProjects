#!/bin/bash
who|sort -k 4n|head -1|awk -F' ' '{print $1}'
