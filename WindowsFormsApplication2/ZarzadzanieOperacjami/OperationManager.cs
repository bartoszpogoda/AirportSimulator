using SymulatorLotniska.Operacje;
using SymulatorLotniska.Planes;
using System;
using System.Windows.Forms;

namespace SymulatorLotniska.ZarzadzanieOperacjami
{
    public class OperationManager
    {
        private Timer timer;
        private OperationList operationList;
        public OperationManager(AppWindow uchwytOknoAplikacji)
        {
            timer = new Timer(); 
            timer.Tick += new EventHandler(onTimerTick);
            timer.Interval = ConfigurationConstants.interwalTimera;
            timer.Enabled = false; // timer ma sie właczać jak lista operacji nie jest pusta

            operationList = new OperationList();
        }

        private void executeOperationChain()
        {
            if(operationList.getFirst() == null)
            {
                stopTimer();
                return;
            }
            operationList.getFirst().wykonajOperacje(operationList);
        }

        public void addOperation(IOperation operacja)
        {
            operationList.addElement(new OperationListElement(operacja));
            startTimer();
        }

        private OperationListElement get(IOperation operacja)
        {
            operationList.iteratorToStart();
            if (operationList.currentAtIterator() == null) return null;
            if (operationList.currentAtIterator().operation == operacja) return operationList.currentAtIterator();

            while (operationList.iteratorHasNext())
            {
                operationList.iteratorNext();
                if (operationList.currentAtIterator().operation == operacja) return operationList.currentAtIterator();
            }
            return null;
        }
        private IOperation get(Plane samolot)
        {
            operationList.iteratorToStart();
            if (operationList.currentAtIterator() == null) return null;
            if (operationList.currentAtIterator().operation.getPlane() == samolot) return operationList.currentAtIterator().operation;

            while (operationList.iteratorHasNext())
            {
                operationList.iteratorNext();
                if (operationList.currentAtIterator().operation.getPlane() == samolot) return operationList.currentAtIterator().operation;
       
            }
            return null;
        }

        public void stopOperation(Plane samolot)
        {
            IOperation operacja = get(samolot);
            stopOperation(operacja);
        }
        public void stopOperation(IOperation operacja)
        {
            operacja.stop();
            OperationListElement element = get(operacja);
            if(element != null) operationList.removeElement(element);
            
        }
        
        public void stopTimer()
        {
            timer.Enabled = false;
        }
        public void startTimer()
        {
            timer.Enabled = true;
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            executeOperationChain();    //wykonanie metody dla kazdej operacji w liscie
        }

    }
}
