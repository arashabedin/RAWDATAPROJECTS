using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace EchoServer
{
    public class Server
    {
        private static void Main(string[] args)
        {
            API.createAPI();
            const int port = 5000;
            var localAddr = IPAddress.Parse("127.0.0.1");

            var server = new TcpListener(localAddr, port);

            server.Start();

            Console.WriteLine("Started");

            while (true)
            {
                var client = server.AcceptTcpClient();

                Console.WriteLine("Client connected");

                var thread = new Thread(HandleClient);

                thread.Start(client);
            }
        }

        private static void HandleClient(object clientObj)
        {
            if (!(clientObj is TcpClient client)) return;

            var stream = client.GetStream();

            try
            {
                var request = Read(stream, client.ReceiveBufferSize);

               
                var response = new Response();

                if (string.IsNullOrEmpty(request.Date))
                {
                    response.Status += "missing date";
                }
               else if (Functions.isItUnix(request.Date))
                {
                    response.Status += "illegal date";
                }

                if (request.Method.Equals("{}"))
                {

                    response.Status += "missing method";
                } else if (request.Method.Contains("create")) { 
                  
                        API.create(request, ref response);
                }
                else if (request.Method.Equals("read"))
                {

                    API.read(request, ref response);
                }
                else if (request.Method.Equals("update"))
                {

                    API.update(request, ref response);
                }
                else if (request.Method.Equals("delete"))
                {

                    API.delete(request, ref response);
                }
                else if (request.Method.Equals("echo"))
                {

                    API.echo(request, ref response);
                } else
                {
                    response.Status += "illegal method";


                }
              

                WriteRepsonse(stream, response);
                stream.Close();
                client.Dispose();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
      
        static void bodyStatus(Request request, Response response)
        {

            if ( string.IsNullOrEmpty(request.Body)) response.Status += "missing body";
            else
            {
                response.Body = request.Body;
            } 
        }

        static void resourceStatus(Request request, Response response)
        {

            if (string.IsNullOrEmpty(request.Path)) response.Status += "missing resource";
         
        }
        private static void WriteRepsonse(Stream stream, Response response)
        {
            var jsonResponse = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            stream.Write(jsonResponse, 0, jsonResponse.Length);
        }

    
        public class Request
        {
            public string Method, Path, Date, Body;


            public Request()
            {
                Method = "{}";
            }
        }

        public class Response
        {
            public string Status { get; set; }
            public string Body { get; set; }
        }

         static Request Read(Stream strm, int size)
        {
            var buffer = new byte[size];
            var bytesRead = strm.Read(buffer, 0, buffer.Length);
            var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Request: {JsonConvert.SerializeObject(request)}");
            return JsonConvert.DeserializeObject<Request>(request);
        }

    }
}
