using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

    private int hp = 5;
    public bool isDead = false;

    CameraShake cameraShake = null;

    void Start()
    {
        cameraShake = GetComponentInChildren<CameraShake>();
        GameObject.Find("Hp").GetComponent<Text>().text = "My Health : " + hp; 
    }

    public void DamageByEnemy()
    {
        if (isDead) return;

        --hp;
        GameObject.Find("Hp").GetComponent<Text>().text = "My Health : " + hp;
        cameraShake.PlayerCameraShake();

        if (hp <= 0) isDead = true;
    }
}
