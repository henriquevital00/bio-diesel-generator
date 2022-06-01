from Interface.IMachines import IMachines


class Reactor(IMachines):

    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 5
        self.Volume = 5
        self.naOh = 0
        self.etOh = 0
        self.oil = 0
        self.hostFromBioDiesel = ""
        self.portFromBioDiesel = 65432
        self.portToBioDiesel = 65433

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
        receivedMessage = self.receiveMessage(self.hostFromBioDiesel, self.portFromBioDiesel)
        if receivedMessage == "get_restante":
            print("aqui")
            restante = str(self.getRestante())
            self.sendMessage(self.hostFromBioDiesel, self.portToBioDiesel, restante)
        #elif receivedMessage == "setEtOh":
