#!/usr/bin/python

import socket
import pickle

def start_and_receive_message(host, port):
    clientsocket = socket.socket()

    clientsocket.connect((host, port))
    x = raw_input('Please enter your wish: ')
    message_to_send = '[C] ' + x;
    clientsocket.send(message_to_send.encode())
    message = clientsocket.recv(1024)
    print message

    clientsocket.close()

start_and_receive_message('localhost', 42002)