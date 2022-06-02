from Interface.IMachines import IMachines
import socket
import time
import random
import threading
import select

class OilTank(IMachines):

    def __init__(self):
        super().__init__()
        self.Flow = 0.75
        self.host = ""
        self.port = 65440
        self.portToReactor = 65441

    def transfereLoop(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToReactor))
            while True:
                if self.Capacity > 0:
                    s.send(b"get_oil")
                    data = s.recv(1024).decode("utf-8")
                    print(f"Capacidade tanque reator: {data}")
                    if float(data) < 2.5:
                        sobra = 2.5 - float(data)
                        transfer = self.calculateTransfer(sobra)
                        #print(f"\nValor a ser transferido: {transfer}")
                        if transfer > 0:
                            sendString = f"set_oil {transfer}"
                            s.send(sendString.encode("utf-8"))
                   #         print("ENVIOU")
                time.sleep(1)


    def responde(self, clientsocket, addr):
        timeout = 30
        while True:
            ready_sockets, _, _ = select.select(
                [clientsocket], [], [], timeout
            )
            if ready_sockets:
                receivedMessage = clientsocket.recv(1024).decode("utf-8")
                receivedMessage = receivedMessage.split()
                if receivedMessage[0] == "set_capacity":
                    self.setCapacity(float(receivedMessage[1]))

        clientsocket.close()

    def verify(self):

        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.host, self.port))
            s.listen()
            while True:
                conn, addr = s.accept()
                threading.Thread(target=self.responde, args=(conn, addr)).start()
