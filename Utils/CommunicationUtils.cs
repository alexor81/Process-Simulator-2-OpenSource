// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.IO.Ports;
using System.Net;

namespace Utils
{
    public static class CommunicationUtils
    {
        public static string    checkTCP_IP(string aIP)
        {
            if (String.IsNullOrWhiteSpace(aIP) || aIP.Equals("localhost", StringComparison.Ordinal))
            {
                return "127.0.0.1";
            }

            try
            {
                IPAddress.Parse(aIP);
            }
            catch
            {
                throw new ArgumentException("Invalid IP Address.");
            }

            return aIP;
        }

        public static void      checkTCP_Port(int aPort)
        {
            if (aPort < 0 || aPort > 65535)
            {
                throw new ArgumentException("Invalid Port.");
            }
        }

        public static void      checkSerial_Port(string aPortName)
        {
            if (aPortName.StartsWith("COM") == false) throw new ArgumentException("Invalid port name. ");
            
            try
            {
                Int32.Parse(aPortName.Substring(3));
            }
            catch
            {
                throw new ArgumentException("Invalid port name. ");
            }
        }
    }
}
