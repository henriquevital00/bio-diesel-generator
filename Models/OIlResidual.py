from Interface.IMachines import IMachines
import socket
import time
import random

class OilResidual(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 0.75
        self.host = ""
        self.portToOilTank = 65440

    def setCapacity(self):
        self.Capacity += random.uniform(1, 2)
        time.sleep(10)

    def verify(self):
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((self.host, self.portToOilTank))

            while True:
                transferQuantity = self.calculateTransfer()
                if transferQuantity > 0:
                    transfer = f"set_capacity {transferQuantity}"
                    s.send(transfer.encode("utf-8"))
                time.sleep(1)
