﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ.Sockets;
using NetMQ;

namespace SecondNetMQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serverSocket = new ResponseSocket())
            {
                serverSocket.Bind("tcp://*:5566");
                while (true)
                {
                    string message1 = serverSocket.ReceiveFrameString();

                    Console.WriteLine("Receive message :\r\n{0}\r\n", message1);

                    string[] msg = message1.Split(':');
                    string message = msg[1];


                    #region 根据接收到的消息，返回不同的信息
                    if (message == "Hello")
                    {
                        serverSocket.SendFrame("World");
                    }
                    else if (message == "ni hao ")
                    {
                        serverSocket.SendFrame("你好！");
                    }
                    else if (message == "hi")
                    {
                        serverSocket.SendFrame("HI");
                    }
                    else
                    {
                        serverSocket.SendFrame(message);
                    }
                    #endregion

                    if (message == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
