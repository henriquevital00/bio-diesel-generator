from Interface.IMachines import IMachines


class Lavagem(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 1.5
        self.Waste = 0.975
        self.Lost = 0
        self.Waste = 0

    # chamar a cada 3 segundos, pois existem 3 tanques com vazao de 1.5 l/s
    def trasfer(self):
        transfer = 0
        lost = 0
        if (self.Capacity <= self.Flow):
            Lost = self.Capacity - (self.Capacity * self.Waste)
            transfer = (((self.Capacity * self.Waste) * self.Waste) * self.Waste)
            self.Capacity -= transfer
        else:
            Lost = self.Capacity - (self.Flow * self.Waste)
            transfer = (((self.Flow * self.Waste) * self.Waste) * self.Waste)
            self.Capacity -= transfer

        return { "transfer": transfer, "lost": Lost }