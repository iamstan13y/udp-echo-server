using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpEchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;
            UdpClient client = null;

            try
            {
                client = new UdpClient(port);

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            for (;;)
            {
                try
                {
                    byte[] byteBuffer = client.Receive(ref endPoint);

                    client.Send(byteBuffer, byteBuffer.Length, endPoint);
                    Console.WriteLine("CLIENT: {0}", Encoding.ASCII.GetString(byteBuffer, 0, byteBuffer.Length));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
