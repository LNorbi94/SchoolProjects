#!/usr/bin/python
# coding: utf-8
# Szerző:		Lestár Norbert
# Neptun kód:	A8UZ7T
# E-mail cím:	lestarnrbert@inf.elte.hu

import os
import re

def toPython(file):
    block = "    "
    copy = file[:-5] + ".py"
    source = open(file, "r")
    destination = open(copy, "w")
    for line in source:
        if re.match(r'\n', line):
            continue;
        line = re.sub(r"\;\;", '\n', line);
        line = line.split('\n')
        j = 0
        for i in range(0, len(line)):
            line[i] = block * j + line[i]
            if re.search(r'{', line[i]):
                j += 1;
            line[i] = re.sub(r'{', ":\n" + block * j, line[i])
            if re.search(r'}', line[i]):
                j -= 1;
        line = '\n'.join(line)
        line = re.sub(r"ELAGAZAS", "if", line);
        line = re.sub(r"CIKLUS", "for", line);
        line = re.sub(r"}", "", line);
        print >>destination, line
    source.close()
    destination.close()

for file in os.listdir("."):
    if file.endswith(".prog"):
        toPython(file)