import socket
import time


class IMachines:
    def __init__(self):
        self.Capacity = 0
        self.Flow = 0
        self.Volume = 0
        self.Waste = 0

    def setCapacity(self, quantity):
        self.Capacity += quantity

        return { "Capacity": self.Capacity }

    def calculateTransfer(self, restante=""):
        transfer = 0
        #restante = kwargs.pop("restante", "")

        if (self.Capacity > 0):
            sizeSubstance = self.Capacity if self.Capacity <= self.Flow else self.Flow
            if restante != '':
                quantidadeASerTransferida = restante if restante <= sizeSubstance else sizeSubstance
                transfer = quantidadeASerTransferida
                self.Capacity -= transfer
            else:
                transfer = sizeSubstance
                self.Capacity -= transfer
        return transfer

    def trasfer(self, HOST, PORT):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as send:
            send.connect((HOST, PORT))
            while True:
                send.sendall(b"get_transfer")
                data = send.recv(1024).decode("utf-8")
                if data:
                    self.calculateTransfer(restante)
                time.sleep(1)



        #transfer = 0
        #if (self.Capacity > 0):
        #    if (self.Capacity <= self.Flow):
        #        transfer = self.Capacity
        #        self.Capacity -= transfer
        #    else:
        #        transfer = self.Flow
        #        self.Capacity -= transfer
        #return { "transfer": transfer }

    def sendMessage(self, host,port, message):
        try:
            with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
                s.connect((host, port))
                s.sendall(message.encode("utf-8"))
            return True
        except:
            return False

    def receiveMessage(self, host, port):
        try:
            with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
                s.bind((host, port))
                s.listen()
                conn, addr = s.accept()
                with conn:
                    #print(f"Connected by {addr}")
                    while True:
                        data = conn.recv(1024)
                        if not data:
                            return ''
                        return data.decode("utf-8")
        except Exception as e:
            return str(e)
