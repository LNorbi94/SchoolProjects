#!/usr/bin/python

import socket
import pickle
import thread
import random

a_random_number = random.randint(1, 200)
clients = []

def on_new_client(client, addr):
        print 'Got connection from ', addr
        guess = '-1'
        global a_random_number
        while int(guess) != a_random_number:
            guess = client.recv(1024)
            print (str(addr[0]) + ':' + str(addr[1]) + ' made a guess: ' + guess)
            if int(guess) == a_random_number:
                client.send("You won!".encode())
                a_random_number = random.randint(1, 200)
                for cli in clients:
                    if cli != client:
                        cli.send('Someone else has won!'.encode())
                        cli.close()
            elif int(guess) < a_random_number:
                client.send("You should try a bigger number!".encode())
            else:
                client.send("You should try a smaller number!".encode())
        client.close()

serversocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
serversocket.bind(('localhost', 42002))
serversocket.listen(5)

while True:
        (client, addr) = serversocket.accept()
        thread.start_new_thread(on_new_client, (client, addr))
        clients.append(client)

serversocket.close()
