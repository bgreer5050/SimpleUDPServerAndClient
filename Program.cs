  static void Main(string[] args)
        {

            int PORT = 9876;
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));

            var from = new IPEndPoint(0, 0);
            Task.Run(() =>
            {
                while (true)
                {
                    var recvBuffer = udpClient.Receive(ref from);
                    Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));
                }
            });

            var data = Encoding.UTF8.GetBytes(Environment.MachineName);
            udpClient.Send(data, data.Length, "255.255.255.255", PORT);

            while(true)
            {

            }
        }
