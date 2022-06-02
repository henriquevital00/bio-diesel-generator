from Models.OIlResidual import OilResidual
from Models.OilTank import OilTank
from Models.Reactor import Reactor
from Models.Decantador import Decantador
from Models.Glicerine import Glicerine
from Models.Lavagem import Lavagem
from Models.Dryer import Dryer
from Models.BioDiesel import BioDiesel
from Models.DryerToEtOh import DryerToEtOh
from Models.Etoh import Etoh
from Models.Naoh import Naoh
from Dashboard.Dashboard import Dashboard
import time

import threading

def runMachines():
    oilResidualTank = OilResidual()
    oilTank = OilTank()
    reactor = Reactor()
    decantador = Decantador()
    glicerine = Glicerine()
    lavagem = Lavagem()
    dryer = Dryer()
    bioDiesel = BioDiesel()
    dryerToEtoh = DryerToEtOh()
    etoh = Etoh()
    naoh = Naoh()


    # Nao tem transfereLoop, este só transfere pelo verify
    oilResidualTankThreadVerify = threading.Thread(target=oilResidualTank.verify)
    oilResidualTankThreadSetCapacity = threading.Thread(target=oilResidualTank.setCapacity)


    oilTankThreadVerify = threading.Thread(target=oilTank.verify)
    oilTankThreadTransfer = threading.Thread(target=oilTank.transfereLoop)

    reactorTankThreadVerify = threading.Thread(target=reactor.verify)
    reactorTankThreadTransfer = threading.Thread(target=reactor.transfereLoop)

    decantadorThreadVerify = threading.Thread(target=decantador.verify)
    decantadorThreadTransfer = threading.Thread(target=decantador.transfereLoop)

    # Este nao transfere, pois e tanque final
    glicerineThreadVerify = threading.Thread(target=glicerine.verify)

    lavagemThreadVerify = threading.Thread(target=lavagem.verify)
    lavagemThreadTransfer = threading.Thread(target=lavagem.transfereLoop)

    dryerThreadVerify = threading.Thread(target=dryer.verify)
    dryerThreadTransfer = threading.Thread(target=dryer.transfereLoop)

    # Este tanque nao transfere, pois e tanque final
    bioDieselThreadVerify = threading.Thread(target=bioDiesel.verify)

    dryerToEtohThreadVerify = threading.Thread(target=dryerToEtoh.verify)
    dryerToEtohThreadTransfer = threading.Thread(target=dryerToEtoh.transfereLoop)

    etohThreadVerify = threading.Thread(target=etoh.verify)
    etohThreadSetCapacity = threading.Thread(target=etoh.setCapacityContinue)
    etohThreadTransfer = threading.Thread(target=etoh.transfereLoop)

    naohThreadVerify = threading.Thread(target=naoh.verify)
    naohThreadSetCapacity = threading.Thread(target=naoh.setCapacityContinue)
    naohThreadTransfer = threading.Thread(target=naoh.transfereLoop)

    # Dashboard para mostrar os dados
    dashboardThread = threading.Thread(target=Dashboard.show, args=(oilResidualTank, oilTank, reactor, decantador, glicerine, lavagem, dryer, bioDiesel, dryerToEtoh, etoh, naoh))

    threadsList = [oilResidualTankThreadVerify, oilTankThreadVerify, reactorTankThreadVerify, decantadorThreadVerify,
                   glicerineThreadVerify,
                   lavagemThreadVerify, dryerThreadVerify, bioDieselThreadVerify, dryerToEtohThreadVerify,
                   etohThreadVerify, naohThreadVerify, oilTankThreadTransfer, reactorTankThreadTransfer,
                   decantadorThreadTransfer, lavagemThreadTransfer, dryerToEtohThreadTransfer, dryerThreadTransfer,
                   etohThreadTransfer, naohThreadTransfer, oilResidualTankThreadSetCapacity, etohThreadSetCapacity, naohThreadSetCapacity,
                   dashboardThread]


    for item in range(len(threadsList)):
        threadsList[item].start()

if __name__ == '__main__':
    runMachines()
