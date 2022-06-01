from Interface.IMachines import IMachines
import socket
import time

class BioDiesel(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 2
        self.hostToReactor = ""
        self.portToReactor = 65432
        self.portFromReactor = 65433

    def verify(self):

        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.hostToReactor, self.portFromReactor))
            send = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            send.connect((self.hostToReactor, self.portToReactor))
            while True:
                time.sleep(1)
                if self.Capacity > 0:
                    send.sendall("get_restante".encode("utf-8"))
                    s.listen()
                    conn, addr = s.accept()
                    with conn:
                        data = conn.recv(1024)
                        if data:
                            msgRecebida = data.decode("utf-8")
                            print(f"Mensagem recebida: {msgRecebida}")
                            transferToReactor = self.trasfer(restante=float(msgRecebida))
                            if transferToReactor["transfer"] > 0:
                                transferToString = str(transferToReactor["transfer"])
                                print(f"Valor a ser transferido {transferToReactor}")
                                self.sendMessage(self.hostToReactor, self.portToReactor, transferToString)