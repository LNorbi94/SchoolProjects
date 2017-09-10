#!/usr/bin/python

import socket
import time

clientSocket = socket.socket()
host = socket.gethostname()
port = 3333

clientSocket.connect((host, port))
clientSocket.send('Seeder ready'.encode())
myAddress = clientSocket.getsockname()
clientSocket.close

serverSocket = socket.socket()
serverSocket.bind(myAddress)
serverSocket.listen(5)

leecher, leecher_addr = serverSocket.accept()
print ('Leecher connected to Seeder from ', leecher_addr)
leecher.send('ZH'.encode())

leecher.close()
serverSocket.close()