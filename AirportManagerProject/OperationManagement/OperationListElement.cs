﻿using SymulatorLotniska.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorLotniska.OperationManagement
{
    class OperationListElement
    {
        public IOperation operation;
        public OperationListElement nextElement;
        public OperationListElement previousElement;

        public OperationListElement(IOperation operacja)
        {
            operation = operacja;
            nextElement = null;
            previousElement = null;
        }

        public void wykonajOperacje(OperationList handleOperationList) 
        {
            if (!operation.execute())
                handleOperationList.removeElement(this);
          
            if(nextElement != null) nextElement.wykonajOperacje(handleOperationList);
        }
    }
}
