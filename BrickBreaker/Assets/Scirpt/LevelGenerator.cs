using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPreFab;

    //Inspector에서 조절할 수 있는 배열 크디
    public int roew = 5;        //생성할 벽돌의 행
    public int columns = 10;    //생성할 벽돌의 열

    // 벽돌의 위치와 간격 설정
    public float spacingX = 1.1f; //X축 간격
    public float spacingY = 0.55f; //Y축 간격
    public Vector3 startPosition = new Vector3(-6f, 3f, 0f);    //벽돌 배열이 시작될 위치

    void Start()
    {
        //게임이 시작되자마자 벽돌 배열을 생성하는 함수 호출
        GenerateBricks();
    }

    void GenerateBricks()
    {
        // 1. 이중 반복문 사용 : 행과 열을 모두 순회
        for(int i =0; i < roew; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                // 벽돌의 생성 위치 계산

                //시작 위치에서 출발
                Vector3 posotion = startPosition;

                // j에 따라 x축 위치를 옆으로 이동
                posotion.x += j * spacingX;

                // i에 따라 Y축 위치를 아래로 이동(i가 증가하면 벽돌이 아래로)
                posotion.y -= i * spacingY;

                //벽돌 생성 (Instantiate)
                Instantiate(brickPreFab, posotion, Quaternion.identity);
            }
        }
    }
}
