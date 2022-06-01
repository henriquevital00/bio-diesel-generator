from Interface.IMachines import IMachines
import socket
import random

class OilResidual(IMachines):
    def __int__(self):
        super().__init__()

    def verify(self):
        print("oi")
        self.Capacity += random.uniform(1, 2)
        #self.sendMessage(self.hostFromBioDiesel, self.portToBioDiesel, restante)