#!/usr/bin/python
# coding: utf-8
# Szerző:		Lestár Norbert
# Neptun kód:	A8UZ7T
# E-mail cím:	lestarnrbert@inf.elte.hu

import re
import operator

class _account:
    'Structure for account'

    def __init__(self, name, num, date, balance):
        self.name     = name
        self.num      = num
        self.date     = date
        self.balance  = balance
        self.updated  = False
        self.new      = False


class _updateAccounts:
    'Class for storing the data of account updates'

    accounts = []

    def __init__(self, fh):
        for line in fh:
            line = line.strip()
            lines = re.split(r' ', line, re.U)
            length = len(lines)
            if length > 1:
                name = ' '.join(lines[0 : length - 3])
                num = lines[length - 3]
                date = lines[length - 2]
                balance = int(lines[length - 1].strip())
                self.accounts.append( _account(name, num, date, balance) )
    
    def update(self, fh):
        date = ""
        for line in fh:
            if re.search(r'(\d+)\.(\d+)\.(\d+)\.', line):
                date = line.strip()
                self.date = date
            else:
                line = line.strip()
                lines = re.split(r' ', line, re.U)
                length = len(lines)
                if length > 1:
                    balance = int(lines[length - 1][1:])
                    if lines[length - 1][0] == '-':
                        balance *= -1
                    updated = False
                    for account in self.accounts:
                        if account.num == lines[length - 2]:
                            updated = True
                            account.updated = updated
                            account.date = date
                            account.balance += balance
                    if not updated:
                        name = ' '.join(lines[0 : length - 2])
                        acc = _account(name, lines[length - 2], date, balance)
                        acc.new = True
                        self.accounts.append( acc )
    
    def log(self, fh):
        if len(self.accounts) < 1:
            return
        self.accounts.sort(key = operator.attrgetter('name', 'num'))
        print >>fh, self.date
        print >>fh, ""
        print >>fh, "new accounts:"
        for account in self.accounts:
            if account.new:
				temp = account.name + " " + account.num
				print >>fh, temp
        print >>fh, ""
        print >>fh, "other updates:"
        for account in self.accounts:
            if account.updated:
				temp = account.name + " " + account.num
				print >>fh, temp
                
    def data(self, fh):
        for account in self.accounts:
            temp = account.name + " " + account.num + " " + account.date + " " + str(account.balance)
            print >>fh, temp

try:
    dataRead	= open("data.txt", "r")
    updateRead  = open("update", "r")
    logWrite    = open("log", "w")
    dataWrite   = open("newdata", "w")
    bank		= _updateAccounts(dataRead)
    bank.update(updateRead)
    bank.log(logWrite)
    bank.data(dataWrite)
except IOError:
	print "Nincs ilyen file!"
else:
    dataRead.close()
    updateRead.close()
    logWrite.close()
    dataWrite.close()
