using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] GameObject brick;   // 생성할 벽돌 프리팹
    [SerializeField] Vector2 pos;        // 시작 위치
    [SerializeField] Vector2 off;        // 간격
    [SerializeField] int row;            // 행
    [SerializeField] int col;            // 열

    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks()
    {
        float startX = pos.x - ((col - 1) * off.x) / 2f; // 열 기준 중앙 정렬
        float startY = pos.y; // 시작 Y

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Vector2 spawnPos = new Vector2(
                    startX + (j * off.x),
                    startY + (i * off.y)
                );
                Instantiate(brick, spawnPos, Quaternion.identity);
            }
        }
    }
}




