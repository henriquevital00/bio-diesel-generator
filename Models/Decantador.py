from Interface.IMachines import IMachines
import socket
import time
import select

class Decantador(IMachines):

    def __init__(self):
        super().__init__()
        self.sleeping = False
        self.Capacity = 0
        self.Flow = 1
        self.Volume = 10
        self.timeToSleep = 5
        self.host = ""
        self.port = 65433
        self.portToGlicerine = 65437
        self.portToLavagem = 65438
        self.portToSecadorToEtoh = 65435
        self.ciclo = 0

    def setCapacity(self, quantity):
        self.Capacity += quantity

    def getRestante(self):
        return self.Volume - self.Capacity

    # Separar o transfer em 1% glicerina 96% solucao e 3% EtOh para mostrar no terminal
    def transfereLoop(self):
        toLavagemSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        toSecadorSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        toGlicerinaSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        toLavagemSocket.connect((self.host, self.portToLavagem))
        toSecadorSocket.connect((self.host, self.portToSecadorToEtoh))
        toGlicerinaSocket.connect((self.host, self.portToGlicerine))

        while True:
            self.sleeping = False
            if self.Capacity > 0:
                transfer = 0

                sizeSubstance = self.Capacity if self.Capacity <= self.Flow else self.Flow

                transfer = sizeSubstance
                self.Capacity -= transfer

                if transfer > 0:
                    self.ciclo += 1

                    sendToSecador = f"set_capacity {transfer*0.03}"
                    sendToLavagem = f"set_capacity {transfer * 0.96}"
                    sendToGlicerine = f"set_capacity {transfer * 0.01}"

                    toSecadorSocket.send(sendToSecador.encode("utf-8"))
                    toLavagemSocket.send(sendToLavagem.encode("utf-8"))
                    toGlicerinaSocket.send(sendToGlicerine.encode("utf-8"))

                    self.sleeping = True
                    time.sleep(self.timeToSleep)



    def verify(self):
        timeout = 30
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.host, self.port))
            s.listen(5)
            conn, addr = s.accept()
            while True:
                ready_sockets, _, _ = select.select(
                    [conn], [], [], timeout
                )
                if ready_sockets:
                    receivedMessage = conn.recv(1024).decode("utf-8")
                    receivedMessage = receivedMessage.split()
                    if receivedMessage[0] == "get_restante":
                        restante = str(self.getRestante())
                        conn.send(restante.encode("utf-8"))
                    elif receivedMessage[0] == "set_capacity":
                        self.setCapacity(float(receivedMessage[1]))
