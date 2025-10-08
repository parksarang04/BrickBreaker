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
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput*speed*Time.deltaTime,0f);
        rb.MovePosition(rb.position+ movement);

    }
}
