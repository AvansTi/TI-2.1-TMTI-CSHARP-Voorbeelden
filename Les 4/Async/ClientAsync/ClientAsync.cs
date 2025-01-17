﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        StartClient(Convert.ToInt32(args[0]));
        Console.ReadLine();
    }

    private static async void StartClient(int port)
    {
        TcpClient client = new TcpClient();                  
        await client.ConnectAsync(IPAddress.Loopback, port); // loopback represents localhost
        LogMessage("Connected to Server");
        using (var networkStream = client.GetStream())
        {
            using (var writer = new StreamWriter(networkStream)) {
                using (var reader = new StreamReader(networkStream)) {
                    writer.AutoFlush = true;
                    for (int i = 0; i < 10; i++) {
                        await writer.WriteLineAsync(DateTime.Now.ToLongDateString());
                        var dataFromServer = await reader.ReadLineAsync();
                        if (!string.IsNullOrEmpty(dataFromServer)) {
                            LogMessage(dataFromServer);
                        }

                    }
                }
            }
        }
        client?.Close();
    }
    private static void LogMessage(string message, [CallerMemberName]string callername = "")  {
        System.Console.WriteLine("{0} - Thread-{1}- {2}",
            callername, Thread.CurrentThread.ManagedThreadId, message);
    }

}
