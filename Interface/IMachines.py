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

    def calculateTransfer(self, restante=""):
        transfer = 0

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
