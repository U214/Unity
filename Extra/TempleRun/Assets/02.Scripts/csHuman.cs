using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csHuman : MonoBehaviour {

    public GUISkin skin;        // GUI Skin

    GameObject manager;         // Bridge Manager

    int speedForward = 12;      // 전진 속도
    int speedSide = 6;          // 옆걸음 속도
    int jumpPower = 300;        // Jump Power

    bool canJump = true;
    bool canTurn = false;
    bool canLeft = true;
    bool canRight = true;
    bool isGround = true;
    bool isDead = false;

    float dirX = 0;             // 좌우 이동 방향 -1왼 1오
    float score = 0;

    Vector3 touchStart;         // 모바일의 터치 시작 위치

	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        manager = GameObject.Find("BridgeManager");
	}
	
	void Update () {
        if (isDead) return;

        // Esc키로 게임 종료
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        CheckMove();
        MoveHuman();

        score += Time.deltaTime * 1000;
	}

    // 이동 가능한지 여부 체크
    void CheckMove()
    {
        RaycastHit hit;

        // 주인공이 땅 위에 있는지 여부
        isGround = true;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
            if (hit.transform.tag == "BRIDGE")
            {
                isGround = true;
            }
        }

        // 왼쪽으로 이동 가능한지 여부
        canLeft = true;
        if (Physics.Raycast(transform.position, -transform.right, out hit, 0.7f))
        {
            if (hit.transform.tag == "GUARD")
            {
                canLeft = false;
            }
        }

        // 오른쪽으로 이동 가능한지 여부
        canRight = true;
        if (Physics.Raycast(transform.position, transform.right, out hit, 0.7f))
        {
            if (hit.transform.tag == "GUARD")
            {
                canRight = false;
            }
        }
    }

    // 주인공 이동
    void MoveHuman()
    {
        dirX = 0;

        // 모바일
        if (Application.platform == RuntimePlatform.Android  ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            CheckMobile();
        } else
        {
            CheckKeyboard();
        }

        // 이동 방향 설정
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

    void CheckMobile()
    {
        // 중력 가속도 센서 읽기
        float x = Input.acceleration.x;

        // 좌우 이동 속도를 줄인다
        if (x < -0.2f && canLeft && isGround) dirX = -0.6f;
        if (x > 0.2f && canLeft && isGround) dirX = 0.6f;

        // 모든 터치에 대해 조사
        foreach (Touch tmp in Input.touches)
        {
            // 터치 시작 위치 설정
            if (tmp.phase == TouchPhase.Began)
            {
                touchStart = tmp.position;
            }

            if (tmp.phase == TouchPhase.Moved)
            {
                Vector3 touchEnd = tmp.position;

                // 점프 - 아래에서 위로 드래그
                if (isGround && canJump && touchEnd.y - touchStart.y > 100)
                {
                    StartCoroutine("JumpHuman");
                }

                // 왼쪽으로 드래그
                if (canTurn && touchEnd.x - touchStart.x < -100)
                {
                    RotateHuman("LEFT");
                }

                // 오른쪽으로 드래그
                if (canTurn && touchEnd.x - touchStart.x > 100)
                {
                    RotateHuman("RIGHT");
                }
            }
        }
    }

    void CheckKeyboard()
    {
        float key = Input.GetAxis("Horizontal");

        // 좌우 이동 방향 설정
        if (key < 0 && canLeft && isGround) dirX = -1;
        if (key > 0 && canRight && isGround) dirX = 1;

        // 점프
        if (isGround && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("JumpHuman");
        }

        // 회전
        if (canTurn)
        {
            if (Input.GetKeyDown(KeyCode.Q)) RotateHuman("LEFT");
            if (Input.GetKeyDown(KeyCode.E)) RotateHuman("RIGHT");
        }
    }

    IEnumerator JumpHuman()
    {
        canJump = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        GetComponent<Animation>().Play("jump_pose");

        yield return new WaitForSeconds(1);
        GetComponent<Animation>().Play("run");
        canJump = true;
    }

    void RotateHuman (string sDir)
    {
        canTurn = false;            // 반복 회전 금지

        // 현재의 회전각 구하기
        Vector3 rot = transform.eulerAngles;

        switch (sDir)
        {
            case "LEFT": rot.y -= 90; break;
            case "RIGHT": rot.y += 90; break;
        }

        // 회전 각 설정
        transform.eulerAngles = rot;

        // 주인공 방향으로 다리 만들기
        manager.SendMessage("MakeBridge", sDir, SendMessageOptions.DontRequireReceiver);
    }

    // deadZone 충돌
    void OnCollisionEnter (Collision col)
    {
        if (col.transform.tag == "DEAD")
        {
            isDead = true;
            GetComponent<Animation>().Play("idle");
        }
    }

    // 기타 장애물과 충돌
    void OnTriggerEnter (Collider col)
    {
        switch (col.transform.tag)
        {
            case "TURN":
                canTurn = true;
                break;

            case "COIN":
                score += 1000;
                Destroy(col.gameObject);
                break;
        }
    }

    // 충돌 끝
    void OnTriggerExit (Collider col)
    {
        if (col.tag == "TURN")
        {
            canTurn = false;
        }
    }
    

}
