from Interface.IMachines import IMachines
import socket
import select
import time

class DryerToEtOh(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Waste = 0.95
        self.Flow = 0.2
        self.host = ""
        self.port = 65435
        self.portToEtoh = 65436

    def transfereLoop(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToEtoh))
            while True:
                transfer = 0
                if (self.Capacity > 0):
                    sizeSubstance = self.Capacity if self.Capacity <= self.Flow else self.Flow

                    self.lost = sizeSubstance - (sizeSubstance * self.Waste)
                    transfer = sizeSubstance * self.Waste
                    self.Capacity -= transfer
                    if transfer > 0:
                        sendToEtohTransferString = f"set_capacity {transfer}"
                        s.send(sendToEtohTransferString.encode("utf-8"))
                time.sleep(5)

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
