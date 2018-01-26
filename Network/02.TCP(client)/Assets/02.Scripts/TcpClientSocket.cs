using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class TcpClientSocket : MonoBehaviour
{
    // 접속할 곳의 IP주소
    private string m_address = "";
    // 접속 할 곳의 포트번호
    private const int m_port = 50765;
    // 통신용 변수
    private Socket m_socket = null;

    void Start()
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
        System.Net.IPAddress hostAddress = hostEntry.AddressList[0];
        Debug.Log(hostEntry.HostName);
        m_address = hostAddress.ToString();
    }

    void OnGUI()
    {
        m_address = GUI.TextField(new Rect(20, 100, 200, 20), m_address);

        if (GUI.Button(new Rect(20, 70, 150, 20), "Connect to Server"))
        {
            ClientProcess();
        }
    }

    // 클라이언트와의 접속 송신 접속해제
    void ClientProcess()
    {
        Debug.Log("[TCP] Start client communication");

        // 서버에 접속
        // 생성한 소켓은 작은 패킷은 버퍼링 하지 않도록
        // Nodelay 속성을 true로 하고 SendBufferSize는 0으로 한다
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        m_socket.NoDelay = true;
        m_socket.SendBufferSize = 1024;
        m_socket.Connect(m_address, m_port);

        // 메세지 송신
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello this is Client (유리나)");
        m_socket.Send(buffer, buffer.Length, SocketFlags.None);

        // 접속 해제
        m_socket.Shutdown(SocketShutdown.Both);
        m_socket.Close();

        Debug.Log("[TCP] End Client communication");
    }
}
