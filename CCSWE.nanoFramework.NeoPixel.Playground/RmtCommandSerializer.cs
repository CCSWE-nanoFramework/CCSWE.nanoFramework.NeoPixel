using nanoFramework.Hardware.Esp32.Rmt;

namespace CCSWE.nanoFramework.NeoPixel.Playground
{
    internal static class RmtCommandSerializer
    {
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

