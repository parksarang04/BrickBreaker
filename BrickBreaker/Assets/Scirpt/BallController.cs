using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballspeed = 3f;
    public Vector3 offset;

    private bool isMoving = false;
    private Rigidbody2D rb;
    private Transform paddleTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        paddleTransform = GameObject.Find("Paddle").transform;
        //���� �е� ������ �Ÿ� ���
        offset = transform.position - paddleTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ���� ���� �߻���� �ʾҴٸ� �е��� ����ٴϰ� �Ѵ�.
        if (!isMoving)
        {
            //���� ��ġ = �е��� ��ġ + �ʱ� ������
            transform.position = paddleTransform.position + offset;

            //�����̽� �ٸ� ������ �� �߻�
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isMoving = true;
                //���� �ణ ���� �༭ �밢������ �߻�
                rb.AddForce(new Vector2(1f, 2f).normalized * ballspeed,ForceMode2D.Impulse);
            }
        }
    }
    //�浿 �� �ӵ� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�߻���� �ʾ��� �� �浹 ����
        if (!isMoving) return;
        //���� �ӵ� ����
        Vector2 velocity = rb.velocity;
        //�ּ� �ӵ� ����
        if (velocity.magnitude < ballspeed)
        {
            //������ �����ϰ� �ӷ¸� �ʱ� �ӷ����� ������
            rb.velocity = velocity.normalized * ballspeed;
        }
    }
}
