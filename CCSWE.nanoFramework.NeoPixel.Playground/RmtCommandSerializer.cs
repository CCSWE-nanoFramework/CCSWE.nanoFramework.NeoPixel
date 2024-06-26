using nanoFramework.Hardware.Esp32.Rmt;

namespace CCSWE.nanoFramework.NeoPixel.Playground
{
    internal static class RmtCommandSerializer
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

        public static byte[] SerializeCommand(RmtCommand command)
        {
            var data = new byte[4];
            if (command.Duration0 <= byte.MaxValue)
            {
                data[0] = (byte)command.Duration0;
                data[1] = command.Level0 ? (byte)128 : (byte)0;
            }
            else
            {
                var num = command.Duration0 % 256;
                data[0] = (byte)num;
                data[1] = (byte)((command.Level0 ? 128 : 0) + (command.Duration0 - num) / 256);
            }

            if (command.Duration1 <= byte.MaxValue)
            {
                data[2] = (byte)command.Duration1;
                data[3] = command.Level1 ? (byte)128 : (byte)0;
            }
            else
            {
                var num = command.Duration1 % 256;
                data[2] = (byte)num;
                data[3] = (byte)((command.Level1 ? 128 : 0) + (command.Duration1 - num) / 256);
            }

            return data;
        }
    }
}

