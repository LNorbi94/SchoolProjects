#!/bin/bash
grep -v "/bin/bash$" /etc/passwd|wc -l
