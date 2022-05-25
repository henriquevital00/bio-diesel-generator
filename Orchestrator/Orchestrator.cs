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
        private Naoh naOh;
        private Etoh etOh;
        private Decantador decantador;

        public Orchestrator()
        {
            //CONTROLLERS
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

            //Moodels
            oilTank = new OilTank();
            reactor = new Reactor();
            naOh = new Naoh();
            etOh = new Etoh();
            decantador = new Decantador();
        }

        public void Start()
        {
            // Insere Oleo Etoh Naoh
            new Timer(oilTankController.SetCapacity, new { oilTank, quantity=Utils.RandomNumber(1, 2) }, 0, 10000);
            new Timer(etohController.SetCapacityApi, new { etOh, quantity = 0.25 }, 0, 1000);
            new Timer(naohController.SetCapacityApi, new { naOh, quantity = 0.5 }, 0, 1000);
            new Timer(decantadorController.SetStatusApi, null, 0, 1000);

            // Transfere Oleo
            dynamic transferTanqueOleo = oilTankController.GetTransfer(oilTank);

            // Insere no Reator o Oleo
            if (transferTanqueOleo.transfer > 0)
            {
                dynamic quantidadeOleoReator = reactorController.SetCapacityOilApi(reactor, transferTanqueOleo);
                //Verificar volume do reator
                // Insere Oleo no reator
                if (quantidadeOleoReator > 0)
                {
                    reactorController.SetCapacityOilApi(reactor, quantidadeOleoReator);
                }
            }
            //Transfere Etoh para Reator
            if (etohController.GetCapacity(etOh) > 0)
            {
                dynamic quantidadeEtOhTranferida = etohController.GetTransfer(etOh);
                
                // Insere EtOh no reator
                if (quantidadeEtOhTranferida > 0)
                {
                    reactorController.SetCapacityEtohApi(reactor, quantidadeEtOhTranferida);
                }
            }
            // transfere Naoh para Reator
            if (etohController.GetCapacity(etOh) > 0)
            {
                dynamic quantidadeNaOhTranferida = naohController.GetTransfer(naOh);
                // insere Naoh no reator

                if (quantidadeNaOhTranferida > 0)
                {
                    reactorController.SetCapacityNaohApi(reactor, quantidadeNaOhTranferida);
                }

            }
            dynamic quantidadeTransferidaReator = reactorController.GetTransfer(reactor);
            dynamic quantidadeTransferidaDecantador = 0;

            // Insere a transferencia do reator no decantador
            // Verificar se pode inserir tudo
            if (quantidadeTransferidaReator > 0)
            {
                decantadorController.SetCapacityApi(decantador, quantidadeTransferidaReator);
            }
            // Verifica se o Decantador possui substancia para transferir
            if (decantadorController.GetCapacity(decantador) > 0)
            {
                quantidadeTransferidaDecantador = decantadorController.GetTransfer(decantador);
            }

            if (quantidadeTransferidaDecantador > 0)
            {

            }
        }
    }
}