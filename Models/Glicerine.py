from Interface.IMachines import IMachines
import socket
import time
import select

class Glicerine(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.host = ""
        self.port = 65437

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
