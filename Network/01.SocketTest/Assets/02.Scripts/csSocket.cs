using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

public class csSocket : MonoBehaviour {

    private Socket m_Socket;

    // Receive Data Length(byte)
    private int ReceivedataLength;
    // Receive Data by this array to save
    private byte[] Receivebyte = new byte[2000];
    // Receive bytes to change string
    private string ReceiveString;

    void OnGUI()
    {
        if (GUI.Button(new Rect(80, 100, 120, 50), "Connect"))
        {
            SocketConnect();
        }

        if (GUI.Button(new Rect(220, 100, 120, 50), "Send/Receive"))
        {
            SocketTest();
        }
    }

    void SocketConnect()
    {
        // Socket create
        m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 10000);
        //m_Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);

        // Socket connect
        try
        {
            m_Socket.Connect("127.0.0.1", 9999);

            if (m_Socket.Connected)
            {
                Debug.Log("Connected");
            }
            else
            {
                Debug.Log("Fail to connect");
            }
        }
        catch (SocketException SCE)
        {
            Debug.Log("Socket connect error : " + SCE.ToString());
            return;
        }
    }

    void SocketTest()
    {
        // Send data write
        StringBuilder sb = new StringBuilder();
        sb.Append("Test1\r\n");
        sb.Append("Test2\r\n");
        sb.Append("Test3\r\n");
        sb.Append("Test4\r\n");
        sb.Append("Test5\r\n");
        sb.Append("Test6\r\n");

        try
        {
            // send
            byte[] Sendbyte = Encoding.Default.GetBytes(sb.ToString());
            m_Socket.Send(Sendbyte, Sendbyte.Length, 0);

            // Receive
            m_Socket.Receive(Receivebyte);
            ReceiveString = Encoding.Default.GetString(Receivebyte);
            ReceivedataLength = Encoding.Default.GetByteCount(ReceiveString.ToString());
            Debug.Log("Receive Data : " + ReceiveString);
            Debug.Log("Receive length : " + ReceivedataLength + "****");
        }
        catch (SocketException err)
        {
            Debug.Log("Socket send or receive error : " + err.ToString());
        }
    } 

    void OnApplicatonQuit()
    {
        Shutdown();
    }

    void Shutdown()
    {
        if (m_Socket != null)
        {
            // m_Socket.Close(); -> 쌍방간의 절교가 필요함
            m_Socket.Shutdown(SocketShutdown.Both); // 일방적인 절교
            m_Socket = null;
        }
    }
}
