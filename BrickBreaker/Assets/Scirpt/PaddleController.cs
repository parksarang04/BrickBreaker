using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 50f;    //Inspector 에서 조절 가능
    public Rigidbody2D rb;      // Rigidbody2D 컴포넌트 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontalInput, 0, 0);

        //화면 밖으로 나가지 않도록 제한
        float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
