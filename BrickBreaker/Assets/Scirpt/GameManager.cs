using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //정적(static) 변수를 이용하면 다른 스크립트에서 GameManager.instance.변수명 으로 접근 가능
    public static GameManager Instance;

    //게임 상태 변수(Inspector)에서 조절 가능
    public float currentScore;
    public int   currenlives;

    //public bool isGameOver;
    //공 리셋을 위한 변수(Inspector)에서 조절 가능
    public GameObject ballPrebab;
    private Transform paddleTransform;

    //활성화된 공 오브젝트
    private GameObject currenBall;

    // start 보다 먼저 실행되어 instance 변수에 자기 자신을 할당
    void Awake()
    {
        // GameManager가 단 하나만 존재하도록 적용
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject paddleObject = GameObject.FindGameObjectWithTag("Paddle"); // 씬 전체를 검색해서 "Paddle" 태그가 붙어있는 게임 오브젝트를 찾고 그 결과를 paddleObject 변수에 저장
        if(paddleObject != null) //paddleObject를 성공적으로 찾았다면
        {
            paddleTransform = paddleObject.transform;   // 찾은 패들 오브젝트의 Transform 컴포넌트를 paddkeTeansform 변수에 저장

            SpawnBall(); //게임 시작 시 공 생성
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 점수 흭득 함수
    public void AddScore(int points)
    {
        currentScore += points;
        Debug.Log("Score" + currentScore);
    }

    //생명 감소 함수
    public void LoseLife()
    {
        currenlives--;
        Debug.Log("Life" + currenlives);

        if(currenlives > 0)
        {
            //생명이 남았을 때 공 리셋
            Invoke("SpawnBall", 1f);  //1초 후에 SpawnBall 함수 실행
        }
        else
        {
            GameOver();
        }
    }
    //공 생성 및 리셋 함수
    void SpawnBall()
    {
        if(paddleTransform != null && ballPrebab != null)
        {
            // 공을 패들 위치에 위치 (offset은 ballControll에서 처리
            Vector3 spawnPosition = paddleTransform.position + new Vector3(0, 0.5f, 0);
            currenBall = Instantiate(ballPrebab, spawnPosition, Quaternion.identity);

            //공 컨트롤러에 "아직 발사되지 않음" 상태를 알려줌
            BallController ballController = currenBall.GetComponent<BallController>();
            if(ballController != null)
            {
                //이 함수를 BallController에 추가하고 호출하면, IsMoving 및 Collider 상태를 비활성화를 한 번에 처리가능
                //ballController.ResetBallState();
            }

        }
    }

    //게임 오버 처리 함수
    void GameOver()
    {
        Debug.Log("Game Over! Final Score : " +currentScore);
        //추가적인 게임 오버 처리 로직 작성 가능
    }
}
