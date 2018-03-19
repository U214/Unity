using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시리얼라이즈
// 복잡한 형태의 데이터 배열 저장
// 게임의 모든 상태 데이터 저장 예제
public class Test : MonoBehaviour {

    // 개별 속성값을 지정해 줄 수 없다
    public SerialiTest1[] st1;

    // 인스펙터뷰에서 보면 속성 값이 보인다
    public SerialiTest2[] str2;
}

public class SerialiTest1 : MonoBehaviour
{
    public int p = 5;
    public Color c = Color.white;
}

// Serializable 속성을 사용하면 하위 속성이 있는
// 클래스를 속성에 포함 할 수 있다
// public 클래스만 가능
[System.Serializable]
public class SerialiTest2 : System.Object
{
    public int p = 5;
    public Color c = Color.white;
}