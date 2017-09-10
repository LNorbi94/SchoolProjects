#!/usr/bin/python

import socket, json

tracker = socket.socket()
host = socket.gethostname()
port = 3333

tracker.connect((host, port))
msg = tracker.recv(1024)
print (msg.decode())
tracker.close()

seeder_addr = json.loads(msg.decode())
seeder = socket.socket()
seeder.connect((seeder_addr[0], seeder_addr[1]))
seeder.send('Leecher ready'.encode())
msg = seeder.recv(1024)
print (msg.decode())

seeder.close()