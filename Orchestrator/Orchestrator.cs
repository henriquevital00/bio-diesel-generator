using BioDieselProject.Entity;
using Destro.Controllers;
using System;

namespace Orchestrators
{
    public class Orchestrator
    {
        // Constrollers
        private BioDieselController bioDieselController;
        private DecantadorController decantadorController;
        private DryerController dryerController;
        private DryerToEtOhController dryerToEtOhController;
        private EtohController etohController;
        private GlicerineController glicerineController;
        private LavagemController lavagemController;
        private NaohController naohController;
        private OilTankController oilTankController;
        private ReactorController reactorController;

        // Models
        private OilTank oilTank;
        private Reactor reactor;

        public Orchestrator()
        {
            bioDieselController = new BioDieselController();
            decantadorController = new DecantadorController();
            dryerController = new DryerController();
            dryerToEtOhController = new DryerToEtOhController();
            etohController = new EtohController();
            glicerineController = new GlicerineController();
            lavagemController = new LavagemController();
            naohController = new NaohController();
            oilTankController = new OilTankController();
            reactorController = new ReactorController();

            oilTank = new OilTank();
            reactor = new Reactor();
        }

        public void Start()
        {
            dynamic quantidadeOleoOilTank = oilTankController.SetCapacity(oilTank, Utils.RandomNumber(1, 2));
            Console.WriteLine("Valor: " + quantidadeOleoOilTank);
            //Console.WriteLine(quantidadeOleoTanqueOleo.ToString());
            /*dynamic transferTanqueOleo = oilTankController.GetTransfer(oilTank);
            if (transferTanqueOleo.transfer > 0)
            {
                object quantidadeOleoReator = reactorController.SetCapacityOilApi(reactor, transferTanqueOleo);
            }*/

        }
    }
}