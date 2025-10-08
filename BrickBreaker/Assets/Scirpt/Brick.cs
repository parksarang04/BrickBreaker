using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //벽돌이 깨졌을 때 Inpector 창에서 점수를 조절
    public int score = 10;

    //벽돌이 공과 충돌했을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GameManager의 AddScore 함수 호출
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(score);
        }

        GameManager.Instance.totalBricks--;

        if (GameManager.Instance.totalBricks <= 0)  //카운터가 0 이하일 때
        {
            GameManager.Instance.LevelUp();  //레벨 업 함수 호출
        }

        //충돌한 상대방의 태그 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            //벽돌 제거
            Destroy(gameObject);
        }
    }
}
