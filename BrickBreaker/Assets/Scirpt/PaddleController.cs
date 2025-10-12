using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 50f;    //Inspector ���� ���� ����
    public Rigidbody2D rb;      // Rigidbody2D ������Ʈ ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontalInput, 0, 0);

        //ȭ�� ������ ������ �ʵ��� ����
        float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
