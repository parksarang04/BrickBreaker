using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPreFab;

    //Inspector���� ������ �� �ִ� �迭 ũ��
    public int roew = 5;        //������ ������ ��
    public int columns = 10;    //������ ������ ��

    // ������ ��ġ�� ���� ����
    public float spacingX = 1.1f; //X�� ����
    public float spacingY = 0.55f; //Y�� ����
    public Vector3 startPosition = new Vector3(-6f, 3f, 0f);    //���� �迭�� ���۵� ��ġ

    void Start()
    {
        //������ ���۵��ڸ��� ���� �迭�� �����ϴ� �Լ� ȣ��
        GenerateBricks();
    }

    void GenerateBricks()
    {
        // 1. ���� �ݺ��� ��� : ��� ���� ��� ��ȸ
        for(int i =0; i < roew; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                // ������ ���� ��ġ ���

                //���� ��ġ���� ���
                Vector3 posotion = startPosition;

                // j�� ���� x�� ��ġ�� ������ �̵�
                posotion.x += j * spacingX;

                // i�� ���� Y�� ��ġ�� �Ʒ��� �̵�(i�� �����ϸ� ������ �Ʒ���)
                posotion.y -= i * spacingY;

                //���� ���� (Instantiate)
                Instantiate(brickPreFab, posotion, Quaternion.identity);
            }
        }
    }
}
