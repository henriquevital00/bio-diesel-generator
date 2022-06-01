from Interface.IMachines import IMachines
import socket
import time

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
        self.portToBioDiesel = 65432
        self.port = 65434

    def getRestante(self) -> int:
        return self.Volume - self.Capacity

    # metodo adiciona a quantidade que for possivel da substancia, se possivel adicionar tudo ele retorna o valor do que sobrou
    # da substancia
    def setCapacityNaoh(self, quantity):
        if (self.Capacity <= self.Volume):
            sobrou = self.Volume - self.Capacity
            if (quantity <= sobrou):
                self.Capacity += quantity
                self.naOh += quantity
                quantity = 0
            else:
                self.Capacity += sobrou
                self.naOh += sobrou
                quantity -= sobrou
        return {"quantity": quantity}

    def setCapacityEtoh(self,  quantity):
        if (self.Capacity <= self.Volume):
            sobrou = self.Volume - self.Capacity
            if (quantity <= sobrou):
                self.Capacity += quantity
                self.etOh += quantity
                quantity = 0
            else:
                self.Capacity += sobrou
                self.etOh += sobrou
                quantity -= sobrou
        return {"quantity": quantity}

    def setCapacityOil(self, quantity):
        print("oi")
        #if (self.Capacity <= self.Volume):
        #    sobrou = self.Volume - self.Capacity
        #    if (quantity <= sobrou):
        #        self.Capacity += quantity
        #        self.oil += quantity
        #        quantity = 0
        #    else:
        #        self.Capacity += sobrou
        #        self.oil += sobrou
        #        quantity -= sobrou
        #return {"quantity": quantity}

    # Verificargit clone
    def trasfer(self):
        transfer = 0
        parte = 0
        if (self.Capacity > 0):
            if (self.Capacity <= self.Flow):
                parte = self.Capacity/4
                if (self.naOh >= parte and self.etOh >= parte and self.oil >= (parte * 2)):
                    transfer = self.Capacity
                    self.Capacity -= transfer
                    self.naOh -= parte
                    self.etOh -= parte
                    self.oil -= (parte*2)
            else:
                parte = self.Flow / 4
                if (self.naOh >= parte and self.etOh >= parte and self.oil >= (parte * 2)):
                    transfer = self.Flow
                    self.Capacity -= transfer
                    self.naOh -= parte
                    self.etOh -= parte
                    self.oil -= (parte*2)

        return { "tansfer":transfer, "naOh":parte, "etOh":parte, "oil":(parte*2) }

    def verify(self):

        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.bind((self.host, self.port))
            send = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            send.connect((self.host, self.portToBioDiesel))
            while True:
                print("reator")
                s.listen()
                conn, addr = s.accept()
                print("pegou o conn")
                print(f"\n{conn}\n")
                with conn:
                    receivedMessage = conn.recv(1024).decode("utf-8")
                    print(f"\nMensagem recebida: {receivedMessage}")
                    if receivedMessage == "get_restante":
                        print("veio reator")
                        restante = str(self.getRestante())
                        #send.sendall(restante.encode("utf-8"))
                        #self.sendMessage(self.hostFromBioDiesel, self.portToBioDiesel, restante)
                    #elif receivedMessage == "setEtOh":
                    time.sleep(1)
