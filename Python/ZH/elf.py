#!/usr/bin/python

import socket
import pickle
import time

def start_and_receive_message(host, port):
    clientsocket = socket.socket()

    clientsocket.connect((host, port))
    message_to_send = '[E] How many gifts do you need?';
    clientsocket.send(message_to_send.encode())
    message = clientsocket.recv(1024)
    if '0' in message:
        print 'My services are not needed!'
    else:
        message_to_send = '[E] What is the first gift?';
        clientsocket.send(message_to_send.encode())
        message = clientsocket.recv(1024)
        time.sleep(5)
        message_to_send = '[E] Here is your ' + message + '!';
        clientsocket.send(message_to_send.encode())
    clientsocket.close()

start_and_receive_message('localhost', 42002)