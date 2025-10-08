using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //������ ������ �� Inpector â���� ������ ����
    public int score = 10;

    //������ ���� �浹���� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // GameManager�� AddScore �Լ� ȣ��
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(score);
        }

        //�浹�� ������ �±� Ȯ��
        if (collision.gameObject.CompareTag("Ball"))
        {
            //���� ����
            Destroy(gameObject);
        }
    }
}
