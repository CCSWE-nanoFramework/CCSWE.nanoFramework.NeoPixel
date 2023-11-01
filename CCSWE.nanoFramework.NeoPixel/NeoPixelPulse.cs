namespace CCSWE.nanoFramework.NeoPixel
{
    public struct NeoPixelPulse
    {
        public byte Duration0;
        public byte Level0;
        public byte Duration1;
        public byte Level1;

        public NeoPixelPulse(byte[] data) : this(data[0], data[1], data[2], data[3])
        {

        }

        public NeoPixelPulse(byte duration0, byte level0, byte duration1, byte level1)
        {
            Duration0 = duration0;
            Level0 = level0;
            Duration1 = duration1;
            Level1 = level1;
        }
    }
}
