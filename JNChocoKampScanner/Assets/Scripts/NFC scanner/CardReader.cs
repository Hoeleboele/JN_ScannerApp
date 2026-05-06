using Lando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NFC_scanner
{
    public static class CardReader
    {
        public static Cardreader cardReader = new Cardreader();

        public static void CloseApp()
        {
            cardReader.StopWatch();
            cardReader.Dispose();
        }
    }
}
