#!/usr/bin/python

import socket
import pickle
import operator
import thread

gifts = []

def child(client, message):
    global gifts
    if len(gifts) < 5:
        gifts.append(message[4:])
        client.send('Your wish has been granted!'.encode())
    else:
        client.send('I\'m sorry, good luck next time!'.encode())

def elf(client, message):
    global gifts
    client.send(str(len(gifts)).encode())
    message = client.recv(1024).decode()
    print message
    if len(gifts) > 0:
        client.send(gifts[0].encode())
        del gifts[0]
        message = client.recv(1024).decode()
        print message


def on_new_client(client, addr):
        print 'Got connection from ', addr
        message = client.recv(1024).decode()
        if '[C]' in message:
            child(client, message);
        elif '[E]' in message:
            elf(client, message);
        client.close()

serversocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serversocket.bind(('localhost', 42002))
serversocket.listen(5)

while True:
        (client, addr) = serversocket.accept()
        thread.start_new_thread(on_new_client, (client, addr))

serversocket.close()