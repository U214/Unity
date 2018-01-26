using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class TcpServerSocket : MonoBehaviour {

    // 리스닝 소켓
    private Socket      m_listener = null;
    // 접속 할 곳의 포트 번호
    private const int   m_port = 50765;
    // 통신용 변수
    private Socket      m_socket = null;
    // 상태
    private State       m_state;

    private enum State
    {
        SelectHost = 0,
        StartListener,
        AcceptClient,
        ServerCommunication,
        StopListener,
    }

	void Start () {
        m_state = State.SelectHost;
	}

    void OnGUI()
    {
        if (m_state == State.SelectHost)
        {
            if (GUI.Button(new Rect(20, 40, 150, 20), "Start Server"))
            {
                m_state = State.StartListener;
            }
        }

        if (m_state == State.AcceptClient)
        {
            if (GUI.Button(new Rect(20, 80, 150, 20), "Stop Server"))
            {
                m_state = State.StopListener;
            }
        }
    }

    void Update () {
		switch (m_state)
        {
            case State.StartListener:
                StartListener();
                break;

            case State.AcceptClient:
                AcceptClient();
                break;

            case State.ServerCommunication:
                ServerCommunication();
                break;

            case State.StopListener:
                StopListener();
                break;

            default:
                break;
        }
	}

    // 대기 시작
    void StartListener()
    {
        Debug.Log("Start Server");

        // 소켓 생성
        m_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 포트번호 할당
        m_listener.Bind(new IPEndPoint(IPAddress.Any, m_port));

        m_listener.Listen(1); // 무한

        m_state = State.AcceptClient;
    }

    // 클라이언트의 접속 대기
    void AcceptClient()
    {
        if (m_listener != null && m_listener.Poll(0, SelectMode.SelectRead))
        {
            // 온라인 게임은 블로킹되면 게임을 진행할 수 없으니
            // Poll 함수로 클라이언트가 보낸 데이터를 감시해서
            // 데이터를 수신했을 때만 accept 함수를 호출 함
            m_socket = m_listener.Accept();
            Debug.Log("[TCP] Connected form client");
            m_state = State.ServerCommunication;
        }
    }

    // 클라이언트의 메세지 수신
    void ServerCommunication()
    {
        byte[] buffer = new byte[1024];
        int recvSize = m_socket.Receive(buffer, buffer.Length, SocketFlags.None);

        if (recvSize > 0)
        {
            string message = System.Text.Encoding.UTF8.GetString(buffer);
            Debug.Log(message);
            m_state = State.AcceptClient;
        }
    }

    // 대기 종료
    void StopListener()
    {
        // 대기를 종료합니다
        if (m_listener != null)
        {
            m_listener.Close();
            m_listener = null;
        }

        m_state = State.SelectHost;

        Debug.Log("[TCP] End server communication");
    }
} 
