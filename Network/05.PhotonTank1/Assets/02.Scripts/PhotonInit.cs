using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviour {

    public InputField txtPlayerName;
    public InputField txtRoomName;

    public Button myButton;
    public Transform myViewport;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PhotonNetwork.ConnectUsingSettings("MyTankWar2 2.0");

        this.txtPlayerName.text = "Guest " + Random.Range(0, 100);

        if (string.IsNullOrEmpty(PhotonNetwork.playerName))
        {
            PhotonNetwork.playerName = this.txtPlayerName.text;
        }
    }

    // 로비에 입장했을 때 호출되는 콜백 함수
    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
 //       PhotonNetwork.JoinRandomRoom();
    }

    // 랜덤 룸 입장에 실패했을 때 호출되는 콜백 함수
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom("MyRoom");
    }

    // 룸을 생성완료 했을 때 호출되는 콜백 함수
    void OnCreatedRoom()
    {
        Debug.Log("Finish make a room");
    }

    // 룸에 입장 됬을 때 호출되는 콜백 함수
    void OnJoinedRoom()
    {
        Debug.Log("Joined room");

        PhotonNetwork.isMessageQueueRunning = false;
        StartCoroutine(this.MoveToGame());
    }

    // 네트워크에 연결되 있는 모든 클라이언트에 플레이어를 생성한다
    IEnumerator SpawnTank()
    {
        yield return new WaitForSeconds(1.0f);

        Transform[] sp = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        int idx = Random.Range(1, sp.Length);

        PhotonNetwork.Instantiate(
            "Tank", 
            sp[idx].position,
            Quaternion.identity, 
            0);
        PhotonNetwork.isMessageQueueRunning = true;
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public void MakeRoom()
    {
        RoomOptions opt = new RoomOptions();
        opt.MaxPlayers = 5;

        PhotonNetwork.playerName = txtPlayerName.text;
        PhotonNetwork.CreateRoom(txtRoomName.text, opt, TypedLobby.Default);
    }

    IEnumerator MoveToGame()
    {
        SceneManager.LoadScene("02-BattleScene");
        yield return null;
    }

    void OnReceivedRoomListUpdate()
    {
        Debug.Log("receive room List : " + PhotonNetwork.GetRoomList().Length);
        
        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            Button newButton = Instantiate(myButton) as Button;

            csButtonItem button = newButton.GetComponent<csButtonItem>();
            button.txtRoomName.text = room.name;
            button.txtNumMax.text = room.playerCount + " / " + room.maxPlayers;

            newButton.transform.SetParent(myViewport);
            newButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void JoinRoom(string str)
    {
        Debug.Log("Room Enter : " + str);

        PhotonNetwork.playerName = txtPlayerName.text;
        PhotonNetwork.JoinRoom(str);
    }
}

//// 룸 나가기 
//public void OnClickExitRoom()
//{
//    PhotonNetwork.LeaveRoom();
//}
//// 룸에서 접속 종료되었을 때 호출되는 콜백 함수
//void OnLeftRoom()
//{
//    SceneManage.LoadScene(“첫번째 씬”);
//}

//// 채팅
///// <summary>
///// Send 버튼 클릭 시 -> 채팅로그에 채팅 보이도록
///// </summary>
//public void btnTextSend()
//{
//    string chat = "\r\n" + PhotonNetwork.player.name + " : " + chatText.text;
//    chatText.text = "";
//    // 자신과 다른 클라이언트에게 전송
//    PhotonView photon = GetComponent<PhotonView>();
//    photon.RPC("AddChatText", PhotonTargets.All, chat);
//}
///// <summary>
///// 채팅 내역을 갱신한다.
///// </summary>
///// <param name="text">새로 받은 채팅텍스트</param>
//[PunRPC]
//public void AddChatText(string text)
//{
//    chatHistory.text += text;
//}

