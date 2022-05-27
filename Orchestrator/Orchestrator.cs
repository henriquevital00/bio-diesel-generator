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
        private Glicerine glicerine;
        private DryerToEtOh dryerToEtOh;
        private Lavagem lavagem;
        private Dryer dryer;
        private BioDiesel bioDiesel;

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
            glicerine = new Glicerine();
            dryerToEtOh = new DryerToEtOh();
            lavagem = new Lavagem();
            dryer = new Dryer();
            bioDiesel = new BioDiesel();
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

                // Verifica se sobrou substancia, caso o reator tenha atingido o volume total
                if (quantidadeOleoReator.quantity > 0)
                {
                    oilTankController.SetCapacity(new { oilTank, quantidadeOleoReator.quantity });
                }
            }
            //Transfere Etoh para Reator
            if (etohController.GetCapacity(etOh) > 0)
            {
                dynamic quantidadeEtOhTranferida = etohController.GetTransfer(etOh);
                dynamic quantidadeEtOhReactor = reactorController.SetCapacityEtohApi(reactor, quantidadeEtOhTranferida);

                // Insere EtOh no reator
                if (quantidadeEtOhReactor.quantity > 0)
                {
                    etohController.SetCapacityApi(new { etOh, quantidadeEtOhReactor.quantity });
                }
            }
            // transfere Naoh para Reator
            if (naohController.GetCapacity(naOh) > 0)
            {
                dynamic quantidadeNaOhTranferida = naohController.GetTransfer(naOh);
                dynamic quantidadeNaOhReactor = reactorController.SetCapacityNaohApi(reactor, quantidadeNaOhTranferida);
                // insere Naoh no reator

                if (quantidadeNaOhTranferida.quantity > 0)
                {
                    naohController.SetCapacityApi(new { etOh, quantidadeNaOhReactor.quantity });
                }
            }

            // Reator esta transferindo
            dynamic quantidadeTransferidaReator = reactorController.GetTransfer(reactor);
            dynamic quantidadeTransferidaDecantador = 0;

            // Insere a transferencia do reator no decantador
            // Verificar se pode inserir tudo

            //VER COM ARTHUR O DECANTADOR
            /*if (quantidadeTransferidaReator.transfer > 0)
            {
                // Verificar set Decantador
                dynamic capacidadeDecantador = decantadorController.SetCapacityApi(decantador, quantidadeTransferidaReator);

                if (capacidadeDecantador.quantity > 0)
                {
                    reactorController.SetCapacityEtohApi(reactor, capacidadeDecantador.etOh);
                    reactorController.SetCapacityNaohApi(reactor, capacidadeDecantador.naOh);
                    reactorController.SetCapacityOilApi(reactor, capacidadeDecantador.oil);
                }
            }
            // Verifica se o Decantador possui substancia para transferir
            if (decantadorController.GetCapacity(decantador) > 0)
            {
                quantidadeTransferidaDecantador = decantadorController.GetTransfer(decantador);
            }

            if (quantidadeTransferidaDecantador > 0)
            {

            }*/

            // Seta a Lavagem com a parte transferida do decantador
            // Lavegm não possui volume
            lavagemController.SetCapacityApi(lavagem, quantidadeTransferidaDecantador.substance);

            // Transfere da Lavagem para o Secador
            dynamic quantidadeTransferidaLavagem = lavagemController.GetTransfer(lavagem);

            dryerController.SetCapacityApi(dryer, quantidadeTransferidaLavagem.transfer);

            dynamic quantidadeTransferidaSecador = dryerController.GetTransfer(dryer);





        }
    }
}