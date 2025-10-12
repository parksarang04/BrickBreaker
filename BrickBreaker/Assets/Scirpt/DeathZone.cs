using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //OnTriggerEnter2D : Is Trigger�� üũ�� Collider�� ����� �� ȣ��
    public void OnTriggerEnter2D(Collider2D other)
    {
        // 1. ���� ������Ʈ�� 'Ball' �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Ball"))
        {
            // 2. ���� ���� ���� ���� ��� ó��(������Ʈ ��Ȱ��ȭ)
            Destroy(other.gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
