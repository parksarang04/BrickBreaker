using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] GameObject brick;   // ������ ���� ������
    [SerializeField] Vector2 pos;        // ���� ��ġ
    [SerializeField] Vector2 off;        // ����
    [SerializeField] int row;            // ��
    [SerializeField] int col;            // ��

    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks()
    {
        float startX = pos.x - ((col - 1) * off.x) / 2f; // �� ���� �߾� ����
        float startY = pos.y; // ���� Y

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




