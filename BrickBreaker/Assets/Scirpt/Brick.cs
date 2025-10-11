using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //벽돌이 깨졌을 때 Inpector 창에서 점수를 조절
    public int score = 10;
    public int hitPoints = 1; //벽돌의 내구도
    public Color[] healthColors; //내구도에 따른 색상 배열

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        UpdateColor(); //시작할 때 색상 업데이트
    }

    //벽돌이 공과 충돌했을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoints--; // 벽돌 내구도 무조건 1감소

        if (hitPoints <=0)
        {
            GameManager.Instance.totalBricks--; //벽돌 카운터 감소
            GameManager.Instance.AddScore(10); //점수 추가

            if(GameManager.Instance.totalBricks <= 0)
            {
                GameManager.Instance.LevelUp(); //레벨 업 함수 호출
            }
            Destroy(gameObject);
        }
        else
        {
            UpdateColor(); //색상 업데이트
        }
    }
    public void UpdateColor()
    {
        //내구도가 1일 때 healthColors[0], 2일 때 healthColors[1]...
        // healthColors 배열의 인덱스를 넘어가지 않도록 방어 로직 추가
        int colorIndex = hitPoints - 1;

        if (colorIndex >= 0 && colorIndex < healthColors.Length)    // 배열의 범위를 벗어나지 않도록 방어 로직
        {
            spriteRenderer.color = healthColors[colorIndex];
        }
        else if (hitPoints > healthColors.Length)
        {
            //만약 내구도가 배열 길이보다 크다면, 가장 높은 내구도 색상 사용
            spriteRenderer.color = healthColors[healthColors.Length - 1];
        }
    }
}
