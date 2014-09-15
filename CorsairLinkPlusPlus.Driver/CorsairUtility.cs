﻿using CorsairLinkPlusPlus.Driver.Sensor;
using System.Text;

namespace CorsairLinkPlusPlus.Driver
{
    public static class CorsairUtility
    {
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        internal static byte GetRelativeThermistorByte(CorsairTemperatureControllableSensor sensor, CorsairThermistor thermistor)
        {
            return (byte)((((CorsairSensor)sensor).device == thermistor.device) ? thermistor.id : 7);
        }

        internal static bool DoesThermistorNeedManualPush(CorsairTemperatureControllableSensor sensor, CorsairThermistor thermistor)
        {
            return GetRelativeThermistorByte(sensor, thermistor) == 7;
        }
    }
}
