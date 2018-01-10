using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {

    private int hp = 5;
    public bool isDead = false;
    public GameObject overText;

    CameraShake cameraShake = null;

    void Start()
    {
        overText.SetActive(false);
        cameraShake = GetComponentInChildren<CameraShake>();
        GameObject.Find("Hp").GetComponent<Text>().text = "My Health : " + hp; 
    }

    public void DamageByEnemy()
    {
        if (isDead) return;

        --hp;
        GameObject.Find("Hp").GetComponent<Text>().text = "My Health : " + hp;
        cameraShake.PlayerCameraShake();

        if (hp <= 0)
        {
            isDead = true;

            overText.SetActive(true);
            overText.GetComponentInChildren<Text>().gameObject.SetActive(true);

            StartCoroutine(pressAnykey());
        }
    }

    IEnumerator pressAnykey()
    {
        while (true)
        {
            if (Input.GetButton("Jump"))
            {
                SceneManager.LoadScene("Game");
            }
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(2.0f);
        //SceneManager.LoadScene("Game");
    }

}
