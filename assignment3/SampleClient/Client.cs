using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //In this step we create we define the port that the server (we want to connect) is listoning.
            int port = 5000;

            // The IP specifys the device in which here we chose (localhost) our own device
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // Now we create our client object, which is an instance of TcpClient.
            var client = new TcpClient();


            //Here we create the connection to the IP and the port that we defiend in the beginning, in order to create the
            //connection to the server.
            client.Connect(localAddr, port);

            // now we store the client's GetStream() to the variable "strm" , which becomes an instance of NetworkStream  class.
            // So the variable strm would have a write() and read() method that we're going to use to send and get data, from
            // the stream that is made between our client and Server.
            var strm = client.GetStream();

            // just created a string to send, from the client to the server, into the variable "request"
            var request = "Hello";
            Console.WriteLine($"Request: {request}");

            // Since data could only be stored and transfered by "bytes", we would encode our "request" String to the new byte
            // variable "data".
            var data = Encoding.UTF8.GetBytes(request);

            // As mentioned, the strm object has a method namely "Write()" where it stores and sends data which would be
            // readable through the server we're connected to by using the "Read()" method. The first parameter "data" defines
            // the data to be send. The second paramater defines from which index it should send the data, and the last
            // parameter defines, until which index of the data, the data should be sent. Which here data.Length means 
            // the last index.
            strm.Write(data, 0, data.Length);


            //In the following lines, the program gets the reads the data which has been stored and prints it to the console.
            byte[] buffer = new byte[client.ReceiveBufferSize];
            var bytesRead = strm.Read(buffer, 0, buffer.Length);

            var response = Encoding.UTF8.GetString(buffer);

            Console.WriteLine($"Response: {response.Trim('\0')}");

            // Here after we're done, we close the stream and end the connection with the client so we would be able to 
            // recieve another requests.
            strm.Close();
            client.Dispose();


        }
    }
}