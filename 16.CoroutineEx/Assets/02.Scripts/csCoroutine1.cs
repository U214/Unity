using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCoroutine1 : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Exam1", 1);
        }
	}

    IEnumerator Exam1 (int i)
    {
        // 렌더링 끝나고 실행
        yield return new WaitForEndOfFrame();

        FirstCall();

        yield return new WaitForSeconds(2.0f);

        SecondCall();
    }

    void FirstCall()
    {
        Debug.Log("First");
    }

    void SecondCall()
    {
        Debug.Log("Second");
    }

}
