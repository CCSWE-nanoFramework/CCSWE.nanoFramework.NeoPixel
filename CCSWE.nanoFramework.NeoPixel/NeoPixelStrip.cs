using nanoFramework.Hardware.Esp32.Rmt;
using System;
using System.Drawing;
using CCSWE.nanoFramework.NeoPixel.Extensions;

namespace CCSWE.nanoFramework.NeoPixel
{
    public class NeoPixelStrip: IDisposable
    {
        // 80MHz / 4 => min pulse 0.00us
        private const byte ClockDivider = 2;
        private const float MinPulse = 1000000.0f / (80000000.0f / ClockDivider);

        private readonly byte[] _data;
        private bool _disposed;
        private readonly object _lock = new();
        private readonly TransmitterChannel _transmitterChannel;

        private readonly byte[] _onePulse;
        private readonly byte[] _zeroPulse;
        private readonly byte[] _resetPulse;

        public NeoPixelStrip(byte pin, ushort count)
        {
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

            _onePulse = new byte[] { (byte)(0.7 / MinPulse), 128, (byte)(0.6 / MinPulse), 0 };
            _zeroPulse = new byte[] { (byte)(0.35 / MinPulse), 128, (byte)(0.8 / MinPulse), 0 };
            _resetPulse = GetResetPulse(MinPulse);
        }

        public ushort Count { get; }

        ~NeoPixelStrip() => Dispose(false);

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

        public void Fill(byte[] color)
        {
            ushort led;
            int i = 0;
            for (led = 0; led < Count; led++)
            {
                byte col;
                for (col = 0; col < 3; col++)
                {
                    byte bit;
                    for (bit = 0; bit < 8; bit++)
                    {
                        if ((color[col] & (1 << bit)) != 0)
                        {
                            _data[0 + i] = _onePulse[0];
                            _data[1 + i] = _onePulse[1];
                            _data[2 + i] = _onePulse[2];
                            _data[3 + i] = _onePulse[3];
                        }
                        else
                        {
                            _data[0 + i] = _zeroPulse[0];
                            _data[1 + i] = _zeroPulse[1];
                            _data[2 + i] = _zeroPulse[2];
                            _data[3 + i] = _zeroPulse[3];
                        }
                        i += 4;
                    }
                }
            }

            //RES
            _data[0 + i] = _resetPulse[0];
            _data[1 + i] = _resetPulse[1];
            _data[2 + i] = _resetPulse[2];
            _data[3 + i] = _resetPulse[3];
        }

        public void Fill(Color color)
        {
            Fill(color.ToBytes(ColorOrder.GRB));
        }

        private byte[] GetResetPulse(float minPulse)
        {
            var result = new byte[4];
            var duration0 = (ushort)(25 / minPulse);
            var duration1 = (ushort)(26 / minPulse);

            var remaining = duration0 % 256;
            result[0] = (byte)remaining;
            result[1] = (byte)((duration0 - remaining) / 256);

            remaining = duration1 % 256;
            result[2] = (byte)remaining;
            result[3] = (byte)((duration1 - remaining) / 256);

            return result;
        }

        public void Update()
        {
            _transmitterChannel.SendData(_data, false);
        }
    }
}
