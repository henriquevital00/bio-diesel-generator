from Interface.IMachines import IMachines
import socket
import time
import select

class Lavagem(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 1.5
        self.Waste = 0.975
        self.lost = 0
        self.host = ""
        self.port = 65438
        self.portToDryer = 65434

    # chamar a cada 3 segundos, pois existem 3 tanques com vazao de 1.5 l/s
    def transfereLoop(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToDryer))
            while True:
                transfer = 0
                if (self.Capacity > 0):
                    sizeSubstance = self.Capacity if self.Capacity <= self.Flow else self.Flow

                    self.lost = sizeSubstance - (sizeSubstance * self.Waste)
                    transfer = sizeSubstance * self.Waste
                    self.Capacity -= transfer
                    if transfer > 0:
                        sendToSecadorTransferString = f"set_capacity {transfer}"
                        s.send(sendToSecadorTransferString.encode("utf-8"))
                time.sleep(1)

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
                    msgRecebida = conn.recv(1024).decode("utf-8")
                    if msgRecebida:
                        msgRecebidaSplit = msgRecebida.split()
                        if msgRecebidaSplit[0] == "set_capacity":
                            self.setCapacity(float(msgRecebidaSplit[1]))
                time.sleep(1)
