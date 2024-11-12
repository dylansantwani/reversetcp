using System.Net.Sockets;
using System.Net;
using System.Text;

int port = 10;

IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);
Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

try
{
    listener.Bind(localEndPoint);
    listener.Listen(10);  

    while (true)
    {
        Console.WriteLine("Awaiting connection. Listening on port " + port);
        Socket clientSocket = listener.Accept();
        byte[] bytes = new Byte[1024];
        string data = null;
       
        while (true)
        {
            //send
            Console.WriteLine("Connected to target. Reversing connection.");
            Console.WriteLine("Waiting on user instruction");
            string instruction = Console.ReadLine();
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(instruction);
            clientSocket.Send(byData);
            //recive
            int numByte = clientSocket.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, numByte);
            Console.WriteLine(data);

        }
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}
