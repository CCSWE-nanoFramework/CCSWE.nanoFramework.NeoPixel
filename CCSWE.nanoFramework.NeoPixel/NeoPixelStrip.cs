using nanoFramework.Hardware.Esp32.Rmt;
using System;
using System.Drawing;
using System.Reflection;

namespace CCSWE.nanoFramework.NeoPixel
{
    public class NeoPixelStrip: IDisposable
    {
        private const byte BitsPerLed = 24;

        // 80MHz / 4 => min pulse 0.00us
        private const byte ClockDivider = 2;
        private const float MinPulse = 1_000_000.0f / (80_000_000.0f / ClockDivider);

        private readonly ColorOrder _colorOrder;
        private readonly byte[] _data;
        private bool _disposed;
        private readonly object _lock = new();
        private readonly TransmitterChannel _transmitterChannel;

        private readonly byte[] _onePulse;
        private readonly byte[] _zeroPulse;
        private readonly byte[] _resetPulse;

        private const float APB_CLK_FREQ = 80_000_000.0f; // 80 MHz
        private const float RMT_CYCLES_PER_SEC = APB_CLK_FREQ / ClockDivider;
        private const float NS_PER_CYCLE = 1_000_000_000L / RMT_CYCLES_PER_SEC;

        public NeoPixelStrip(byte pin, ushort count, ColorOrder colorOrder = ColorOrder.GRB)
        {
            _colorOrder = colorOrder;

            Count = count;

            var transmitterChannelSettings = new TransmitChannelSettings(pinNumber: pin)
            {
                EnableCarrierWave = false,
                ClockDivider = ClockDivider,
                IdleLevel = false,
            };
            _transmitterChannel = new TransmitterChannel(transmitterChannelSettings);

            var totalBits = 24 * Count;

            _data = new byte[(totalBits + 1) * 4];

            /* Values from Sample...
            _onePulse = new byte[] { (byte)(0.7 / MinPulse), 128, (byte)(0.6 / MinPulse), 0 };
            _zeroPulse = new byte[] { (byte)(0.35 / MinPulse), 128, (byte)(0.8 / MinPulse), 0 };
            _resetPulse = GetResetPulse(MinPulse);
            */

            // Values from serializing the RmtCommands Ws2812b (THESE SEEM TO WORK GOOD BUT ARE THEY CORRECT?)
            _onePulse = new byte[] { 32, 128, 18, 0 };
            _zeroPulse = new byte[] { 16, 128, 34, 0 };
            _resetPulse = new byte[] { 208, 7, 208, 7 };

            _onePulse = new byte[] { (byte)(0.8 / MinPulse), 128, (byte)(0.45 / MinPulse), 0 };
            _zeroPulse = new byte[] { (byte)(0.4 / MinPulse), 128, (byte)(0.85 / MinPulse), 0 };
            _resetPulse = GetResetPulse(MinPulse);

            // Values from serializing the RmtCommands Ws2812c
            /*
            _onePulse = new byte[] { 52, 128, 52, 0 };
            _zeroPulse = new byte[] { 14, 128, 52, 0 };
            _resetPulse = new byte[] { 120, 5, 120, 5 };
            */

            var resetIndex = _data.Length - 4;

            _data[resetIndex + 0] = _resetPulse[0];
            _data[resetIndex + 1] = _resetPulse[1];
            _data[resetIndex + 2] = _resetPulse[2];
            _data[resetIndex + 3] = _resetPulse[3];

            Clear();
        }

        public ushort Count { get; }

        ~NeoPixelStrip() => Dispose(false);

        public void Clear()
        {
            Fill(Color.Black);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            lock (_lock)
            {
                if (_disposed)
                {
                    return;
                }

                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _transmitterChannel.Dispose();
            }

            _disposed = true;
        }

        public void Fill(Color color)
        {
            var colorBytes = color.ToBytes(_colorOrder);
            var commandIndex = 0;
            ushort ledIndex;

            for (ledIndex = 0; ledIndex < Count; ledIndex++)
            {
                byte colorIndex;

                for (colorIndex = 0; colorIndex < 3; colorIndex++)
                {
                    byte bitIndex;
                    byte colorByte = colorBytes[colorIndex];
                    for (bitIndex = 0; bitIndex < 8; bitIndex++)
                    {
                        if ((colorByte & 128) != 0)
                        {
                            _data[0 + commandIndex] = _onePulse[0];
                            _data[1 + commandIndex] = _onePulse[1];
                            _data[2 + commandIndex] = _onePulse[2];
                            _data[3 + commandIndex] = _onePulse[3];
                        }
                        else
                        {
                            _data[0 + commandIndex] = _zeroPulse[0];
                            _data[1 + commandIndex] = _zeroPulse[1];
                            _data[2 + commandIndex] = _zeroPulse[2];
                            _data[3 + commandIndex] = _zeroPulse[3];
                        }

                        colorByte <<= 1;
                        commandIndex += 4;
                    }
                }
            }
        }

        private byte[] GetResetPulse(float minPulse)
        {
            var result = new byte[4];
            var duration0 = (ushort)(50 / minPulse);
            var duration1 = (ushort)(50 / minPulse);

            var remaining = duration0 % 256;
            result[0] = (byte)remaining;
            result[1] = (byte)((duration0 - remaining) / 256);

            remaining = duration1 % 256;
            result[2] = (byte)remaining;
            result[3] = (byte)((duration1 - remaining) / 256);

            return result;
        }

        private int GetStartIndex(int index)
        {
            return index * BitsPerLed * 4;
        }

        public void SetLed(int index, Color color)
        {
            var colorBytes = color.ToBytes(_colorOrder);
            byte colorIndex;
            var commandIndex = GetStartIndex(index);

            for (colorIndex = 0; colorIndex < 3; colorIndex++)
            {
                byte bitIndex;
                byte colorByte = colorBytes[colorIndex];
                for (bitIndex = 0; bitIndex < 8; bitIndex++)
                {
                    if ((colorByte & 128) != 0)
                    {
                        _data[0 + commandIndex] = _onePulse[0];
                        _data[1 + commandIndex] = _onePulse[1];
                        _data[2 + commandIndex] = _onePulse[2];
                        _data[3 + commandIndex] = _onePulse[3];
                    }
                    else
                    {
                        _data[0 + commandIndex] = _zeroPulse[0];
                        _data[1 + commandIndex] = _zeroPulse[1];
                        _data[2 + commandIndex] = _zeroPulse[2];
                        _data[3 + commandIndex] = _zeroPulse[3];
                    }

                    colorByte <<= 1;
                    commandIndex += 4;
                }
            }
        }

        /*
        private void SerializeColor(byte b, TransmitterChannel transmitter)
        {
            for (int index = 0; index < 8; ++index)
            {
                transmitter.AddCommand(((int)b & 128) != 0 ? this.OnePulse : this.ZeroPulse);
                b <<= 1;
            }
        }
        */

        /*
        public void SetLeds(int start, int length, byte[] color)
        {

        }

        public void SetLeds(int start, int length, Color color)
        {
            SetLeds(start, length, color.ToBytes(_colorOrder));
        }
        */

        public void Update()
        {
            _transmitterChannel.SendData(_data, true);
        }
    }
}
