from Interface.IMachines import IMachines
import socket
import time

class BioDiesel(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 2
        self.host = ""
        self.port = 65432
        self.portToReactor = 65434

    def verify(self):

        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.host, self.port))
            send = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            send.connect((self.host, self.portToReactor))
            while True:
                if self.Capacity > 0:
                    print("oleo")
                    send.sendall("get_restante".encode("utf-8"))
                    print("enviou oleo")
                    s.listen()
                    conn, addr = s.accept()
                    with conn:
                        data = conn.recv(1024).decode("utf-8")
                        if data:
                            msgRecebida = data.decode("utf-8")
                            print(f"Mensagem recebida: {msgRecebida}")
                            transferToReactor = self.trasfer(restante=float(msgRecebida))
                            if transferToReactor["transfer"] > 0:
                                transferToString = str(transferToReactor["transfer"])
                                print(f"Valor a ser transferido {transferToReactor}")
                                send.sendall(transferToString)
                time.sleep(1)
