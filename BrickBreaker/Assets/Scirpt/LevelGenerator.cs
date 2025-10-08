using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab;

    // Inspector���� ������ �� �ִ� �迭 ũ��
    public int rows = 5;       // ������ ������ ��
    public int cols = 10;      // ������ ������ ��

    // ������ ��ġ�� ���� ����
    public float spacingX = 1.1f;  // X�� ����
    public float spacingY = 0.55f; // Y�� ����

    private BoxCollider2D areaCollider;

    void Start()
    {
        areaCollider = GetComponent<BoxCollider2D>();

        if (areaCollider == null)
        {
            Debug.LogError("LevelGenerator�� BoxCollider2D ������Ʈ�� �ʿ��մϴ�. �迭�� �������� �ʽ��ϴ�.");
            return; // ������Ʈ�� ������ ���⼭ ���� �ߴ�
        }

        // GenerateBricks() �Լ� ȣ���� �� ���� ����
        GenerateBricks();
        Debug.Log("Level Generator Started Rows : " + rows);
    }

    void GenerateBricks()
    {
        // Collider�� ������ ������ ���� �ʰ� ���� (Start()���� �̹� üũ������ ������ġ)
        if (areaCollider == null) return;

        // BoxCollider2D�� ��� ���
        Bounds bounds = areaCollider.bounds;

        //���� ��ġ ���� (BoxCollider�� ���� ��� �𼭸�)
        // newStartPosition = �ݶ��̴��� ���� ���� X ��ǥ, ���� ���� Y ��ǥ
        Vector3 finalStartPosition = new Vector3(bounds.min.x, bounds.max.y, 0f);

        // Brick �������� ũ�⸦ ������� ��ġ�� ����
        // �̰��� ������ �߽���(Pivot)�� �迭�� ������(Top-Left)�� ���߱� ���� ����.
        // �� ���� �����ؾ� ���� �迭�� �ݶ��̴� ��輱�� �� �°� ����
        // Brick ������Ʈ�� Collider2D�� ������ ��Ȯ�� ũ�⸦ ���ϴ� ��
        // ���⼭�� �ӽ� �� 0.5f�� ����մϴ�. (Brick�� ���̰� 1�̶�� ����)
        float brickHalfHeight = 0.5f;
        finalStartPosition.y -= brickHalfHeight; // �߽����� ���߱� ���� Y���� ���� ���� ���̸�ŭ �����ϴ�.


        // 1. ���� �ݺ��� ��� : ��� ���� ��� ��ȸ
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

                // ���� ���� (Instantiate)
                Instantiate(brickPrefab, position, Quaternion.identity);               
            }
        }
    }
}