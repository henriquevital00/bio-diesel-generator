import threading

from Interface.IMachines import IMachines
import socket
import time
import select

class Reactor(IMachines):

    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 5
        self.Volume = 5
        self.naOh = 0
        self.etOh = 0
        self.oil = 0
        self.host = ""
        self.portToDecantador = 65440
        self.port = 65441

    def getRestante(self) -> int:
        return self.Volume - self.Capacity

    def setCapacityNaoh(self, quantity):
        self.Capacity += quantity
        self.naOh += quantity

    def setCapacityEtoh(self,  quantity):
        self.Capacity += quantity
        self.etOh += quantity

    def setCapacityOil(self, quantity):
        self.Capacity += quantity
        self.oil += quantity

    def calculateTransfer(self, restante):
        transfer = 0
        parte = 0
        if (self.Capacity > 0):
            sizeSubstance = self.Capacity if self.Capacity <= self.Flow else self.Flow
            quantidadeASerTransferida = restante if restante <= sizeSubstance else sizeSubstance
            parte = quantidadeASerTransferida/4
            if (self.naOh >= parte and self.etOh >= parte and self.oil >= (parte * 2)):
                transfer = quantidadeASerTransferida
                self.Capacity -= transfer
                self.naOh -= parte
                self.etOh -= parte
                self.oil -= (parte*2)

        return transfer

    def transfereLoop(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToDecantador))
            while True:
                if self.Capacity > 0:
                    s.send(b"get_restante")
                    data = s.recv(1024).decode("utf-8")
                    transfer = self.calculateTransfer(float(data))
                    if transfer > 0:
                        sendString = f"set_capacity {transfer}"
                        s.send(sendString.encode("utf-8"))
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
                if receivedMessage[0] == "get_restante":
                    restante = str(self.getRestante())
                    print(f"\nRetornando valor: {restante}\n")
                    clientsocket.send(restante.encode("utf-8"))
                elif receivedMessage[0] == "set_oil":
                    self.setCapacityOil(float(receivedMessage[1]))
                elif receivedMessage[0] == "set_etoh":
                    self.setCapacityEtoh(float(receivedMessage[1]))
                elif receivedMessage[0] == "set_naoh":
                    self.setCapacityNaoh(float(receivedMessage[1]))
                elif receivedMessage[0] == "get_oil":
                    sendCapacidadeOil = f"{self.oil}"
                    clientsocket.send(sendCapacidadeOil.encode("utf-8"))
                elif receivedMessage[0] == "get_etoh":
                    sendCapacidadeEtoh = f"{self.etOh}"
                    clientsocket.send(sendCapacidadeEtoh.encode("utf-8"))
                elif receivedMessage[0] == "get_naoh":
                    sendCapacidadeNaoh = f"{self.naOh}"
                    clientsocket.send(sendCapacidadeNaoh.encode("utf-8"))

        clientsocket.close()

    def verify(self):

        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.host, self.port))
            s.listen(5)
            while True:
                conn, addr = s.accept()
                threading.Thread(target=self.responde, args=(conn, addr)).start()
