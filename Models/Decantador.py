from Interface.IMachines import IMachines


class Decantador(IMachines):

    def __init__(self):
        super().__init__()
        self.sleeping = False
        self.Capacity = 0
        self.Flow = 1
        self.Volume = 10
        self.timeToSleep = 5

    def setCapacity(self, quantity):
        if (self.Capacity <= self.Volume):
            sobrou = self.Volume - self.Capacity
            if (quantity <= sobrou):
                Capacity += quantity
                quantity = 0
            else:
                Capacity += sobrou
                quantity -= sobrou
        return
        {
            "quantity":quantity
        }

    # Separar o transfer em 1% glicerina 96% solucao e 3% EtOh para mostrar no terminal
    def trasfer(self):
        transfer = 0

        if (not self.sleeping):
            if (self.Capacity <= self.Flow):
                transfer = self.Capacity
                self.Capacity -= transfer
            else:
                transfer = self.Flow
                self.Capacity -= transfer

        return { "transfer": transfer }

    def setState(self):
        if (self.sleeping):
            timeToSleep -= 1
            if (timeToSleep == 0):
                self.sleeping = False
                timeToSleep = 5
