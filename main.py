from Models.BioDiesel import BioDiesel
from Models.Reactor import Reactor
from Models.OilTank import OilTank
import threading

def runMachines():
    oilTank = OilTank()
    reactor = Reactor()
    

    oilTankThread = threading.Thread(target=oilTank.verify)
    threading.Timer(10, OilTank.setCapacity).start()
    decantadorThread = threading.Thread(target=reactor.verify)
    decantadorThread.start()
    oilTankThread.start()
    #dryerThread = threading.Thread(target=, args=(1,))
    #dryerToEtOhThread = threading.Thread(target=, args=(1,))
    #etOhThread = threading.Thread(target=, args=(1,))
    #glicerineThread = threading.Thread(target=, args=(1,))
    #lavagemThread = threading.Thread(target=, args=(1,))
    #naOhThread = threading.Thread(target=, args=(1,))
    #oilTankThread = threading.Thread(target=, args=(1,))
    #reactorThread = threading.Thread(target=, args=(1,))


if __name__ == '__main__':
    runMachines()
