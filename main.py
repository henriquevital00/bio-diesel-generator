from Models.BioDiesel import BioDiesel
from Models.Reactor import Reactor
import threading

def runMachines():
    bio = BioDiesel()
    reactor = Reactor()
    bioDieselThread = threading.Thread(target=bio.verify)
    decantadorThread = threading.Thread(target=reactor.verify)
    decantadorThread.start()
    bioDieselThread.start()
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
