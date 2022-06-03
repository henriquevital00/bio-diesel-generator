import json
import time
import os


class Dashboard:

    @staticmethod
    def clear():
        clear = lambda: os.system('clear')

    @staticmethod
    def show(oilResidualTankObj, oilTankObj, reactorObj, decantadorObj, glicerineObj, lavagemObj, dryerObj, bioDieselObj, dryerToEtohObj, etohObj, naohObj):
        tempo = 0
        while True:
            data = {
                "Tanque_de_oleo": {
                    "Capacidade": oilTankObj.Capacity
                },
                "Reator": {
                    "Capacidade": reactorObj.Capacity,
                    "Ciclo": reactorObj.ciclo
                },
                "Tanque_residual_oleo": {
                    "Capacidade" : oilResidualTankObj.Capacity
                },
                "Decantador": {
                    "Capacidade": decantadorObj.Capacity,
                    "Ciclo" : decantadorObj.ciclo,
                    "sleep": decantadorObj.sleeping
                },
                "Glicerina": {
                    "Capacidade": glicerineObj.Capacity
                },
                "Lavagem": {
                    "Capacidade": lavagemObj.Capacity,
                    "Perda" : lavagemObj.lost,
                    "emulsao": lavagemObj.emulssao
                },
                "Secador": {
                    "Capacidade": dryerObj.Capacity,
                    "Perda" : dryerObj.lost
                },
                "Biodiesel": {
                    "Capacidade": bioDieselObj.Capacity
                },
                "SecadordeEtoh": {
                    "Capacidade": dryerToEtohObj.Capacity,
                    "Perda" : dryerToEtohObj.lost
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
            tempo += 1
            time.sleep(1)
            if tempo == 3600:
                break
