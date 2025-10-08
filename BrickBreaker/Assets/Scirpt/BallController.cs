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
    private Collider2D ballCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        paddleTransform = GameObject.Find("Paddle").transform;
        //공과 패들 사이의 거리 계산
        offset = transform.position - paddleTransform.position;

        // Collider 컴포넌트 가져오기
        ballCollider = GetComponent<Collider2D>();
        // 시작 시 Collider 비활성화
        if(ballCollider != null)
        {
            ballCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 공이 아직 발사되지 않았다면 패들을 따라다니게 한다.
        if (!isMoving)
        {
            //공의 위치 = 패들의 위치 + 초기 오프셋
            transform.position = paddleTransform.position + offset;

            //스페이스 바를 누르면 공 발사
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isMoving = true;

                //발사 직전에 Collider 활성화
                if (ballCollider != null)
                {
                    ballCollider.enabled = true;
                }
                //공의 약간 힘을 줘서 대각선으로 발사
                rb.AddForce(new Vector2(1f, 2f).normalized * ballspeed,ForceMode2D.Impulse);
            }
        }
    }
    //충동 시 속도 유지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //발사되지 않았을 때 충돌 무시
        if (!isMoving) return;
        //현재 속도 저장
        Vector2 velocity = rb.velocity;
        //최소 속도 유지
        if (velocity.magnitude < ballspeed)
        {
            //방향은 유지하고 속력만 초기 속력으로 재조정
            rb.velocity = velocity.normalized * ballspeed;
        }
    }
}
