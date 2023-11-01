using System.Threading;

namespace CCSWE.nanoFramework.NeoPixel.Playground
{
    public class Program
    {
        public static void Main()
        {
            /* Ws2812b - These values are close to spec */
            /*
            var onePulse = new RmtCommand(32, true, 18, false);
            var zeroPulse = new RmtCommand(16, true, 34, false);
            var resetCommand = new RmtCommand(2000, false, 2000, false);
            */

            /* Ws2812c */
            /*
            var onePulse = new RmtCommand(52, true, 52, false);
            var zeroPulse = new RmtCommand(14, true, 52, false);
            var resetCommand = new RmtCommand(1400, false, 1400, false);
            */

            /*
            var onePulseBytes = RmtCommandSerializer.SerializeCommand(onePulse);
            var zeroPulseBytes = RmtCommandSerializer.SerializeCommand(zeroPulse);
            var resetCommandBytes = RmtCommandSerializer.SerializeCommand(resetCommand);
            */

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
