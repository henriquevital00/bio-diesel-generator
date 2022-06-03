from Interface.IMachines import IMachines
import socket
import time
import select

class Naoh(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 1
        self.host = ""
        self.port = 65439
        self.portToReator = 65441

    def setCapacityContinue(self):
        while True:
            self.Capacity += 0.5
            time.sleep(1)

    def transfereLoop(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToReator))

            while True:
                if self.Capacity > 0:
                    #Verifica sua substancia e nao envia se passar a proporcao de 1.25L
                    s.send(b"get_naoh")
                    data = s.recv(1024).decode("utf-8")
                    if float(data) < 1.25:
                        sobra = 1.25 - float(data)
                        transfer = self.calculateTransfer(sobra)
                        if transfer > 0:
                            sendString = f"set_naoh {transfer}"
                            s.send(sendString.encode("utf-8"))
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
                    receivedMessage = conn.recv(1024).decode("utf-8")
                    receivedMessage = receivedMessage.split()
                    if receivedMessage[0] == "set_capacity":
                        self.setCapacity(float(receivedMessage[1]))
