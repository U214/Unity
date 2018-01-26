using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text playerCount;
    public Text roomStatus;

	void Start () {
        playerCount.text =
            "Players : " +
            PhotonNetwork.room.PlayerCount +
            " / " +
            PhotonNetwork.room.maxPlayers;
	}
	
	void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        playerCount.text =
            "Players : " +
            PhotonNetwork.room.PlayerCount +
            " / " +
            PhotonNetwork.room.maxPlayers;

        roomStatus.text += "\n[ " + player.name + " ]님이 입장했습니다.";
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        playerCount.text =
           "Players : " +
           PhotonNetwork.room.PlayerCount +
           " / " +
           PhotonNetwork.room.maxPlayers;

        roomStatus.text += "\n[ " + player.name + " ]님이 퇴장했습니다.";
    }
}
