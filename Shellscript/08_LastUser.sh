#!/bin/bash
echo "Utolso user ABC sorrendben:"
sort /etc/passwd|awk -F':' '{print $5}'|tail -1
