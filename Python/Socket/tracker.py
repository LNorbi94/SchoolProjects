#!/usr/bin/python

import socket, json

sck = socket.socket()
host = socket.gethostname()
port = 3333
sck.bind((host, port))

sck.listen(5)
seeder, seeder_addr = sck.accept()
print ('Seeder connected from ', seeder_addr)
leecher, leecher_addr = sck.accept()
print ('Leecher connected from ', leecher_addr)
leecher.send(json.dumps(seeder_addr).encode())

seeder.close()
leecher.close()
sck.close()