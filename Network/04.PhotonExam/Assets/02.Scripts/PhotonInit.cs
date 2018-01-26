using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonInit : MonoBehaviour {

	void Awake()
    {
        // 버젼별로 분리해서 접속
        // 접속된 애들 버전별로 그룹핑
        PhotonNetwork.ConnectUsingSettings("MyTankWar 1.0");
    }

    // 로비에 입장했을 때 호출되는 콜백 함수
    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    // 랜덤 룸 입장에 실패했을 때 호출되는 콜백 함수
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No Room");
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

        // 플레이어를 생성한다
        StartCoroutine(this.CreatePlayer());
    }

    // 네트워크에 연결되 있는 모든 클라이언트에 플레이어를 생성한다
    IEnumerator CreatePlayer()
    {
        PhotonNetwork.Instantiate("MyPlayer", new Vector3(0, 1, 0), Quaternion.identity, 0);
        yield return null;
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
