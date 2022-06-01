from Interface.IMachines import IMachines


class Naoh(IMachines):
    def __init__(self):
        super().__init__()
        self.Capacity = 0
        self.Flow = 0.5
