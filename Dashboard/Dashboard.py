import json
import time
import os


class Dashboard:

    #def __int__ (self, oilResidualTankObj, oilTankObj, reactorObj, decantadorObj, glicerineObj, lavagemObj, dryerObj, bioDieselObj, dryerToEtohObj, etohObj, naohObj):
        #self.oilResidualTank = oilResidualTankObj
        #self.oilTank = oilTankObj
        #self.reactor = reactorObj
        #self.decantador = decantadorObj
        #self.glicerine = glicerineObj
        #self.lavagem = lavagemObj
        #self.dryer = dryerObj
        #self.bioDiesel = bioDieselObj
        #self.dryerToEtoh = dryerToEtohObj
        #self.etoh = etohObj
        #self.naoh = naohObj

    @staticmethod
    def clear():
        clear = lambda: os.system('clear')

    @staticmethod
    def show(oilResidualTankObj, oilTankObj, reactorObj, decantadorObj, glicerineObj, lavagemObj, dryerObj, bioDieselObj, dryerToEtohObj, etohObj, naohObj):
        while True:
            data = {
                "Tanque_de_oleo": {
                    "Capacidade": oilTankObj.Capacity
                },
                "Reator": {
                    "Capacidade": reactorObj.Capacity
                },
                "Tanque_residual_oleo": {
                    "Capacidade" : oilResidualTankObj.Capacity
                },
                "Decantador": {
                    "Capacidade": decantadorObj.Capacity,
                    "Ciclo" : 0
                },
                "Glicerina": {
                    "Capacidade": glicerineObj.Capacity
                },
                "Lavagem": {
                    "Capacidade": lavagemObj.Capacity,
                    "Perda" : 0
                },
                "Secador": {
                    "Capacidade": dryerObj.Capacity,
                    "Perda" : 0
                },
                "Biodiesel": {
                    "Capacidade": bioDieselObj.Capacity
                },
                "SecadordeEtoh": {
                    "Capacidade": dryerToEtohObj.Capacity,
                    "Perda" : 0
                },
                "EtOh": {
                    "Capacidade": etohObj.Capacity
                },
                "NaOh": {
                    "Capacidade": naohObj.Capacity
                }
            }
            Dashboard.clear()
            print(json.dumps(data, sort_keys=True, indent=4))
            time.sleep(1)