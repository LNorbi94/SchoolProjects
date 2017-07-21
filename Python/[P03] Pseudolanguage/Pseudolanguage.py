#!/usr/bin/python
# ELAGAZAS feltetel {utasitasok }
# CIKLUS feltetel {utasitasok }

import os
import re

def toPython(file):
    block = "    "
    copy = file[:-5] + ".py"
    source = open(file, "r")
    destination = open(copy, "w")
    for line in source:
        if re.match(r"ELAGAZAS", line):
            line = re.sub(r"ELAGAZAS", "if", line);
            line = re.sub(r"{", ":\n" + block, line);
            line = re.sub(r";;", "\n" + block, line);
            line = re.sub(r"}", "", line);
            print >>destination, line
        elif re.match(r"CIKLUS", line):
            line = re.sub(r"CIKLUS", "for", line);
            line = re.sub(r"{", ":\n" + block, line);
            line = re.sub(r";;", "\n" + block, line);
            line = re.sub(r"}", "", line);
            print >>destination, line
        elif re.search(r"\;\;", line):
            line = line.split(';;');
            print >>destination, line[0]
            print >>destination, line[1]
        elif re.match(r'\n', line):
            pass
        else:
            print >>destination, line
    source.close()
    destination.close()

for file in os.listdir("."):
    if file.endswith(".prog"):
        toPython(file)