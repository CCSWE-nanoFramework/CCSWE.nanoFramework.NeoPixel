using nanoFramework.Hardware.Esp32.Rmt;
using System;
using System.Drawing;
using CCSWE.nanoFramework.NeoPixel.Drivers;

namespace CCSWE.nanoFramework.NeoPixel
{
    public class NeoPixelStripDriver2: IDisposable
    {
        private const byte BitsPerLed = 24;

        private readonly byte[] _data;
        private bool _disposed;
        private readonly object _lock = new();
        private readonly TransmitterChannel _transmitterChannel;

        private readonly ColorOrder _colorOrder;
        private readonly NeoPixelPulse _onePulse;
        private readonly NeoPixelPulse _zeroPulse;

        public NeoPixelStripDriver2(byte pin, ushort count, NeoPixelDriver driver)
        {
            Count = count;

            var transmitterChannelSettings = new TransmitChannelSettings(pinNumber: pin)
            {
                EnableCarrierWave = false,
                ClockDivider = driver.ClockDivider,
                IdleLevel = false,
            };
            _transmitterChannel = new TransmitterChannel(transmitterChannelSettings);

            var totalBits = 24 * Count;

            _data = new byte[(totalBits + 1) * 4];

            var resetIndex = _data.Length - 4;

            _data[resetIndex + 0] = driver.ResetPulse[0];
            _data[resetIndex + 1] = driver.ResetPulse[1];
            _data[resetIndex + 2] = driver.ResetPulse[2];
            _data[resetIndex + 3] = driver.ResetPulse[3];

            _colorOrder = driver.ColorOrder;
            _onePulse = new NeoPixelPulse(driver.OnePulse);
            _zeroPulse = new NeoPixelPulse(driver.ZeroPulse);

            Clear();
        }

        public ushort Count { get; }

        ~NeoPixelStripDriver2() => Dispose(false);

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
                            _data[0 + commandIndex] = _onePulse.Duration0;
                            _data[1 + commandIndex] = _onePulse.Level0;
                            _data[2 + commandIndex] = _onePulse.Duration1;
                            _data[3 + commandIndex] = _onePulse.Level1;
                        }
                        else
                        {
                            _data[0 + commandIndex] = _zeroPulse.Duration0;
                            _data[1 + commandIndex] = _zeroPulse.Level0;
                            _data[2 + commandIndex] = _zeroPulse.Duration1;
                            _data[3 + commandIndex] = _zeroPulse.Level1;
                        }

                        colorByte <<= 1;
                        commandIndex += 4;
                    }
                }
            }
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
                        _data[0 + commandIndex] = _onePulse.Duration0;
                        _data[1 + commandIndex] = _onePulse.Level0;
                        _data[2 + commandIndex] = _onePulse.Duration1;
                        _data[3 + commandIndex] = _onePulse.Level1;
                    }
                    else
                    {
                        _data[0 + commandIndex] = _zeroPulse.Duration0;
                        _data[1 + commandIndex] = _zeroPulse.Level0;
                        _data[2 + commandIndex] = _zeroPulse.Duration1;
                        _data[3 + commandIndex] = _zeroPulse.Level1;
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
            _transmitterChannel.SendData(_data, false);
        }
    }
}
