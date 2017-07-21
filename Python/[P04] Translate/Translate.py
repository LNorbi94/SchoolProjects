#!/usr/bin/python
# coding: utf-8
# Szerző: Lestár Norbert


class Ford:
    dictn = {}

    def __init__(self, dictn):
        self.dictn = dictn

    def fordit(self, src, dest):
        try:
            keys = open(src, "r+")
            vals = open(dest, "w+")
            for key in keys:
                key = key.split(' ')
                for k in key:
                    k = k.strip()
                    add = ' '
                    if '.' in k:
                        add = '.\n'
                        k = k.strip('.')
                    if k in self.dictn:
                        vals.write(self.dictn[k])
                        vals.write(add)
        except IOError:
            print "Nincs input file!"
        else:
            keys.close()
            vals.close()

    def findkey(self, val):
        for k, v in self.dictn.iteritems():
            if v == val:
                return k

    def visszafordit(self, src, dest):
        try:
            vals = open(src, "r+")
            keys = open(dest, "w+")
            for val in vals:
                val = val.split(' ')
                for v in val:
                    v = v.strip()
                    add = ' '
                    if '.' in v:
                        add = '.\n'
                        v = v.strip('.')
                    key = self.findkey(v)
                    keys.write(key)
                    keys.write(add)
        except IOError:
            print "Nincs input file!"
        else:
            keys.close()
            vals.close()
