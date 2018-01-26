using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class UdpClientSocket : MonoBehaviour
{
    // 접속할 곳의 IP주소
    private string m_address = "";
    // 접속 할 곳의 포트 번호
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
            SendMessage();
        }
    }

    // 클라이언트와의 접속 송신 접속 종료
    void SendMessage()
    {
        Debug.Log("[UDP] Start communication");

        // 서버에 접속
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        // 메시지 송신
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello this is client (유리나)");

        // SendTo 함수는 송신할 때마다 IP주소와 포트 번호를 지정한다
        // UDP는 접속 절차가 없다
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(m_address), m_port);
        m_socket.SendTo(buffer, buffer.Length, SocketFlags.None, endpoint);

        // 접속 종료
        m_socket.Close();

        Debug.Log("[UDP] End communication");
    }
}
