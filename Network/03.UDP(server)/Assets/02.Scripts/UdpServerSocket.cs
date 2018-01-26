using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class UdpServerSocket : MonoBehaviour
{
    // 접속할 곳의 IP주소
    private string m_address = "";
    // 접속 할 곳의 포트 번호
    private const int m_port = 50765;
    // 통신용 변수
    private Socket m_socket = null;
    // 상태
    private State m_state;

    private enum State
    {
        SelectHost = 0,
        CreateListner,
        ReceiveMessage,
        CloseListener,
    }

    void Start()
    {
        m_state = State.SelectHost;
    }

    void OnGUI()
    {
        if (m_state == State.SelectHost)
        {
            if (GUI.Button(new Rect(20, 40, 150, 20), "Start Server"))
            {
                m_state = State.CreateListner;
            }
        }

        if (m_state == State.ReceiveMessage)
        {
            if (GUI.Button(new Rect(20, 80, 150, 20), "Stop Server"))
            {
                m_state = State.CloseListener;
            }
        }
    }

    void Update()
    {
        switch (m_state)
        {
            case State.CreateListner:
                CreateListner();
                break;

            case State.ReceiveMessage:
                ReceiveMessage();
                break;

            case State.CloseListener:
                CloseListener();
                break;

            default:
                break;
        }
    }

    // 소켓 생성
    void CreateListner()
    {
        Debug.Log("[UDP] Start Server");

        // 소켓 생성
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        // 포트번호 할당
        m_socket.Bind(new IPEndPoint(IPAddress.Any, m_port));

        m_state = State.ReceiveMessage;
    }

    // 다른 단말에서 보낸 메세지 수신
    void ReceiveMessage()
    {
        if (m_socket.Poll(0, SelectMode.SelectRead))
        {
            Debug.Log("[UDP] Receive data form client");

            byte[] buffer = new byte[1024];
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint senderRemote = (EndPoint)sender;

            int recvSize = m_socket.ReceiveFrom(buffer, SocketFlags.None, ref senderRemote);
            if (recvSize > 0)
            {
                string message = System.Text.Encoding.UTF8.GetString(buffer);
                Debug.Log(message);
                m_state = State.ReceiveMessage;
            }
        }
    }

    // 대기 종료
    void CloseListener()
    {
        // 대기를 종료합니다
        if (m_socket != null)
        {
            m_socket.Close();
            m_socket = null;
        }

        m_state = State.SelectHost;

        Debug.Log("[UDP] End server");
    }
}
