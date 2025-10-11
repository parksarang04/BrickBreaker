using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //������ ������ �� Inpector â���� ������ ����
    public int score = 10;
    public int hitPoints = 1; //������ ������
    public Color[] healthColors; //�������� ���� ���� �迭

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        UpdateColor(); //������ �� ���� ������Ʈ
    }

    //������ ���� �浹���� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoints--; // ���� ������ ������ 1����

        if (hitPoints <=0)
        {
            GameManager.Instance.totalBricks--; //���� ī���� ����
            GameManager.Instance.AddScore(10); //���� �߰�

            if(GameManager.Instance.totalBricks <= 0)
            {
                GameManager.Instance.LevelUp(); //���� �� �Լ� ȣ��
            }
            Destroy(gameObject);
        }
        else
        {
            UpdateColor(); //���� ������Ʈ
        }
    }
    public void UpdateColor()
    {
        //�������� 1�� �� healthColors[0], 2�� �� healthColors[1]...
        // healthColors �迭�� �ε����� �Ѿ�� �ʵ��� ��� ���� �߰�
        int colorIndex = hitPoints - 1;

        if (colorIndex >= 0 && colorIndex < healthColors.Length)    // �迭�� ������ ����� �ʵ��� ��� ����
        {
            spriteRenderer.color = healthColors[colorIndex];
        }
        else if (hitPoints > healthColors.Length)
        {
            //���� �������� �迭 ���̺��� ũ�ٸ�, ���� ���� ������ ���� ���
            spriteRenderer.color = healthColors[healthColors.Length - 1];
        }
    }
}
