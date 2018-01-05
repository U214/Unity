using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLegacy1 : MonoBehaviour {

    bool bFast = true;

    public void doWalk()
    {
        StartCoroutine("coWalk");
    }

    IEnumerator coWalk()
    {
        GetComponent<Animation>().Play("walk");
        // 실행 중인 애니메이션을 기다려 줌
        yield return new WaitForSeconds(0.4f);
        GetComponent<Animation>().Play("iddle");
    }

    public void doJumpPose()
    {
        StartCoroutine("coJumpPose");
    }

    IEnumerator coJumpPose()
    {
        // 0.2초씩 애니메이션을 겹쳐서 자연스럽게 만듦
        GetComponent<Animation>().CrossFade("attack_leap", 0.2f);
        yield return new WaitForSeconds(0.46f);
        GetComponent<Animation>().CrossFade("iddle", 0.2f);
    }

    public void doWalkFast() {
        if (bFast)
        {
            bFast = false;

            GetComponent<Animation>().Stop();
            GetComponent<Animation>()["walk"].speed = 4.0f;
            GetComponent<Animation>()["walk"].wrapMode = WrapMode.Once;

            StartCoroutine("coWalk");
        } else
        {
            bFast = true;

            GetComponent<Animation>().Stop();
            GetComponent<Animation>()["walk"].speed = 4.0f;
            GetComponent<Animation>()["walk"].wrapMode = WrapMode.Loop;
            GetComponent<Animation>().Play("walk");
        }
    }
}
