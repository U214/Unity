using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csDestroy : MonoBehaviour {
    public int hp = 3;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "OnTriggerEnter");
        Debug.Log("other name : " + other.gameObject.name + " tag : " + other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            hp--;

            if (hp <= 0)
            {
                //Destroy(gameObject);
                if (gameObject.name == "Player")
                {
                    SceneManager.LoadScene("LoseScene");
                } else
                {
                    SceneManager.LoadScene("WinScene");
                }
            }
        }
    }
}
