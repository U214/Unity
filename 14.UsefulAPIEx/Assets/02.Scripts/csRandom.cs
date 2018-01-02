using System.Collections;
using UnityEngine;

public class csRandom : MonoBehaviour {

	void Start () {
        // 랜덤 값 구하기
        int randomSeedS;
        randomSeedS = (int)System.DateTime.Now.Ticks;
        //Random.seed = randomSeedS;
        Random.InitState(randomSeedS);

        // Random.Range(이상, 미만)
        int randomX = Random.Range(5, 10);
        Debug.Log("integer : " + randomX);

        float randomY = Random.Range(5.0f, 10.0f);
        Debug.Log("float : " + randomY);

        // 범위 제한
        int myVal = 10;

        float nLimit = Mathf.Clamp(myVal, 1, 5);
        Debug.Log("Clamps : " + nLimit);
    }
}
