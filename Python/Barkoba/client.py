#!/usr/bin/python

import socket
import pickle

def start_and_receive_message(host, port):
    clientsocket = socket.socket()

    clientsocket.connect((host, port))
    message = ''
    while 'won' not in message:
        x = raw_input('Please enter your guess: ')
        clientsocket.send(x.encode())
        message = clientsocket.recv(1024)
        print (message.decode())
    clientsocket.close()

start_and_receive_message('localhost', 42002)