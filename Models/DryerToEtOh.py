from Interface.IMachines import IMachines


class DryerToEtOh(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Waste = 0.95
        self.Flow = 0.2

    def trasfer(self):
        transfer = 0
        lost = 0
        if (self.Capacity <= self.Flow):
            lost = self.Capacity - (self.Capacity * self.Waste)
            transfer = self.Capacity * self.Waste
            self.Capacity -= transfer
        else:
            lost = self.Capacity - (self.Flow * self.Waste)
            transfer = self.Flow * self.Waste
            self.Capacity -= transfer
        return { "transfer":transfer, "lost":lost }
