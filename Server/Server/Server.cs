using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace Server
{
    class Server
    {
        private TcpListener Listener;
        private TcpClient Client;
        private int port;
        private IPAddress ipAdress = IPAddress.Any;
        private bool work = false;
        private Thread thrListener;
        private Hashtable pairs1 = new Hashtable(30);
        private Hashtable pairs2 = new Hashtable(30);
        private TcpClient[] queue = new TcpClient[5];


        public Server(int port = 4350, IPAddress ipAdress = null)
        {
            this.port = port;
            if (ipAdress != null)
            {
                this.ipAdress = ipAdress;
            }
        }
        public void StartListening()
        {
            Listener = new TcpListener(ipAdress, port);
            Listener.Start();
            work = true;
            thrListener = new Thread(KeepListening);
        }
        private void KeepListening()
        {
            while (work)
            {
                
            }
        }
    }
}
