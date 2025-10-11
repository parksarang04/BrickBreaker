using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    public GameObject brickPrefab;

    // Inspector���� ������ �� �ִ� �迭 ũ��
    public int rows = 5;       // ������ ������ ��
    public int cols = 10;      // ������ ������ ��

    // ������ ��ġ�� ���� ����
    public float spacingX = 1.1f;  // X�� ����
    public float spacingY = 0.55f; // Y�� ����

    private BoxCollider2D areaCollider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // BoxCollider2D ������Ʈ ��������
        areaCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        // Level 1�� ���� ����
        GenerateBricks();
    }

    // LevelGenerator�� Ȱ��ȭ�� �� ����
    public void GenerateNextLevel(int level)
    {
        // ���� ���� ���� ��� �ı�
        DestroyExistingBricks();

        // ���̵��� ���� �迭 ũ�� �Ǵ� ���� ���� ����
        rows = 5 + (level - 1); //������ �ö󰥼��� ���� �ϳ��� �߰�

        // ���ο� ���� ���� ���� ȣ��
        GenerateBricks();
    }

    // ���� ���� ���� ��� �ı�
    private void DestroyExistingBricks()
    {
        // ���� �ִ� ��� "Brick" �±� ������Ʈ�� ã�´�
        GameObject[] oldBricks = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject brick in oldBricks)
        {
            Destroy(brick);
        }
    }

    void GenerateBricks()
    {
        // Collider�� ������ ������ ���� �ʰ� ���� (������ġ)
        if (areaCollider == null) return;

        // BoxCollider2D�� ��� ���
        Bounds bounds = areaCollider.bounds;

        //���� ��ġ ���� (BoxCollider�� ���� ��� �𼭸�)
        Vector3 finalStartPosition = new Vector3(bounds.min.x, bounds.max.y, 0f);

        // Brick �������� ũ�⸦ ������� ��ġ�� ���� (�߽����� ���߱� ����)
        float brickHalfHeight = 0.5f;
        finalStartPosition.y -= brickHalfHeight; // �߽����� ���߱� ���� Y���� ���� ���� ���̸�ŭ �����ϴ�.

        // 1. ���� �ݺ��� ��� : ��� ���� ��� ��ȸ
        int count = 0;

        //���� ������ ���� �ִ� ������ ���
        int maxHP = 1 + (rows / 3);
        if (maxHP < 1) maxHP = 1;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ���� ��ġ���� ���
                Vector3 position = finalStartPosition;

                // j�� ���� X�� ��ġ�� ������ �̵�
                position.x += j * spacingX;

                // i�� ���� Y�� ��ġ�� �Ʒ��� �̵�
                position.y -= i * spacingY;
                // ������ ��ġ ��� ���� ����

                // ���� ���� (Instantiate)
                GameObject newBrickObject = Instantiate(brickPrefab, position, Quaternion.identity);

                // ������ �Ҵ� ����
                Brick newBrick = newBrickObject.GetComponent<Brick>();
                if (newBrick != null)
                {
                    // 1. ������ ���� ���� (1���� maxHP����)
                    newBrick.hitPoints = Random.Range(1, maxHP + 1);

                    //newBrick.UpdateColor();
                }
                //������ �Ҵ� ���� ��

                count++;
            }
        }
        GameManager.Instance.totalBricks = count;
    }
}