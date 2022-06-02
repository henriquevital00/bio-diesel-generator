import json
import time


class Dashboard:

    def __int__(self, oilResidualTankObj, oilTankObj, reactorObj, decantadorObj, glicerineObj, lavagemObj, dryerObj, bioDieselObj, dryerToEtohObj, etohObj, naohObj):
        self.oilResidualTank = oilResidualTankObj
        self.oilTank = oilTankObj
        self.reactor = reactorObj
        self.decantador = decantadorObj
        self.glicerine = glicerineObj
        self.lavagem = lavagemObj
        self.dryer = dryerObj
        self.bioDiesel = bioDieselObj
        self.dryerToEtoh = dryerToEtohObj
        self.etoh = etohObj
        self.naoh = naohObj

    def show(self):
        data = {
            "Tanque_de_oleo": {
                "Capacidade": self.oilTank.Capacity
            },
            "Reator": {
                "Capacidade": self.reactor.Capacity
            },
            "Tanque_residual_oleo": {
                "Capacidade" : self.oilResidualTank.Capacity
            },
            "Decantador": {
                "Capacidade": self.decantador.Capacity,
                "Ciclo" : 0
            },
            "Glicerina": {
                "Capacidade": self.glicerine.Capacity
            },
            "Lavagem": {
                "Capacidade": self.lavagem.Capacity,
                "Perda" : 0
            },
            "Secador": {
                "Capacidade": self.dryer.Capacity,
                "Perda" : 0
            },
            "Biodiesel": {
                "Capacidade": self.bioDiesel.Capacity
            },
            "SecadordeEtoh": {
                "Capacidade": self.dryerToEtoh.Capacity,
                "Perda" : 0
            },
            "EtOh": {
                "Capacidade": self.etoh.Capacity
            },
            "NaOh": {
                "Capacidade": self.naoh.Capacity
            }
        }
        print(json.dumps(data, sort_keys=True, indent=4))
        time.sleep(1)