using System.Threading;
using nanoFramework.Benchmark;
using nanoFramework.Hardware.Esp32.Rmt;

namespace CCSWE.nanoFramework.NeoPixel.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            /* Ws2812b */
            var onePulse = new RmtCommand(32, true, 18, false);
            var zeroPulse = new RmtCommand(16, true, 34, false);
            var resetCommand = new RmtCommand(2000, false, 2000, false);

            /* Ws2812c */
            /*
            var onePulse = new RmtCommand(52, true, 52, false);
            var zeroPulse = new RmtCommand(14, true, 52, false);
            var resetCommand = new RmtCommand(1400, false, 1400, false);
            */

            var onePulseBytes = SerializeCommand(onePulse);
            var zeroPulseBytes = SerializeCommand(zeroPulse);
            var resetCommandBytes = SerializeCommand(resetCommand);

            //BenchmarkRunner.Run(typeof(Program).Assembly);
            BenchmarkRunner.RunClass(typeof(NeoPixelStripBenchmarks));
            Thread.Sleep(Timeout.Infinite);
        }

        private static byte[] SerializeCommand(RmtCommand command)
        {
            int index = 0;
            byte[] numArray = new byte[4];
            if (command.Duration0 <= byte.MaxValue)
            {
                numArray[index] = (byte)command.Duration0;
                numArray[1 + index] = command.Level0 ? (byte)128 : (byte)0;
            }
            else
            {
                int num = command.Duration0 % 256;
                numArray[index] = (byte)num;
                numArray[1 + index] = (byte)((command.Level0 ? 128 : 0) + (command.Duration0 - num) / 256);
            }

            if (command.Duration1 <= byte.MaxValue)
            {
                numArray[2 + index] = (byte)command.Duration1;
                numArray[3 + index] = command.Level1 ? (byte)128 : (byte)0;
            }
            else
            {
                int num = command.Duration1 % 256;
                numArray[2 + index] = (byte)num;
                numArray[3 + index] = (byte)((command.Level1 ? 128 : 0) + (command.Duration1 - num) / 256);
            }

            index += 4;
            return numArray;
        }
    }
}
