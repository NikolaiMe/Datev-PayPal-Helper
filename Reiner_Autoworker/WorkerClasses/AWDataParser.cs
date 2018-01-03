using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Reiner_Autoworker.WorkerClasses
{
    class PayPalParser
    {
        public PayPalParser(string dataToParse)
        {
            Thread parsingThread = new Thread(pPPThread);
            parsingThread.Start();
        }

        public void pPPThread()
        {

        }
        
    }


}
