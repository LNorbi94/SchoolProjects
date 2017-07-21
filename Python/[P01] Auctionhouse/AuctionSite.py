#! /usr/bin/env python
# -*- coding: iso-8859-2 -*-
# Szerzo:		Lestar Norbert
# Neptun kod:	A8UZ7T
# E-mail cím:	lestarnrbert@inf.elte.hu

import sys
import re

class _good:
	'Structure for goods'

	def __init__(self, name, status, price, index):
		self.name	= name
		self.status	= status
		self.price	= price
		self.sold	= False
		self.index	= index

class _auctionSite:
	'Class for storing the data of auction site'
	
	goods = {}
	
	def __init__(self, fh):
		for line in fh:
			lines = re.split(r'\;', line, re.U)
			if( len(lines) > 1 ):
				goodsSplit	= re.split('(\d+). ', lines[0], re.U)
				index		= goodsSplit[1]
				name		= goodsSplit[2]
				status		= lines[1].strip()
				price		= lines[2].strip()
				self.goods[index] = _good(name, status, price, index)
			else:
				lines = line.split(':')
				if( len(lines) > 1 ):
					auctionersSplit	= re.split('(\d+)\. ', lines[1], re.U)
					name			= lines[0]
					number			= auctionersSplit[1].strip()
					price			= auctionersSplit[2].strip()
					if( int(price) >= int(self.goods[number].price) ):
						self.goods[number].price		= price
						self.goods[number].auctioner	= name
						self.goods[number].sold			= True
	
	def calcOutput(self, ftw):
		for good in self.goods.values():
			if(good.sold):
				temp = good.index + ". " + good.name + ", " + good.auctioner + " " + good.price
				print >>ftw, temp

try:
	filename	= sys.argv[1]
	fh			= open(filename, "r")
	ftw			= open("eredmeny.txt", "w")
	acSite		= _auctionSite(fh)
	acSite.calcOutput(ftw)
except IndexError:
	print "Adj meg egy file-t!"
except IOError:
	print "Nincs ilyen file!"
else:
	ftw.close()
	fh.close()
