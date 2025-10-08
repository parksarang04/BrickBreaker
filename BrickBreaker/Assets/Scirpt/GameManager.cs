using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //����(static) ������ �̿��ϸ� �ٸ� ��ũ��Ʈ���� GameManager.instance.������ ���� ���� ����
    public static GameManager Instance;

    //���� ���� ����(Inspector)���� ���� ����
    public float currentScore;
    public int   currenlives;

    //public bool isGameOver;
    //�� ������ ���� ����(Inspector)���� ���� ����
    public GameObject ballPrebab;
    private Transform paddleTransform;

    //Ȱ��ȭ�� �� ������Ʈ
    private GameObject currenBall;

    // start ���� ���� ����Ǿ� instance ������ �ڱ� �ڽ��� �Ҵ�
    void Awake()
    {
        // GameManager�� �� �ϳ��� �����ϵ��� ����
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject paddleObject = GameObject.FindGameObjectWithTag("Paddle"); // �� ��ü�� �˻��ؼ� "Paddle" �±װ� �پ��ִ� ���� ������Ʈ�� ã�� �� ����� paddleObject ������ ����
        if(paddleObject != null) //paddleObject�� ���������� ã�Ҵٸ�
        {
            paddleTransform = paddleObject.transform;   // ã�� �е� ������Ʈ�� Transform ������Ʈ�� paddkeTeansform ������ ����

            SpawnBall(); //���� ���� �� �� ����
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���� ŉ�� �Լ�
    public void AddScore(int points)
    {
        currentScore += points;
        Debug.Log("Score" + currentScore);
    }

    //���� ���� �Լ�
    public void LoseLife()
    {
        currenlives--;
        Debug.Log("Life" + currenlives);

        if(currenlives > 0)
        {
            //������ ������ �� �� ����
            Invoke("SpawnBall", 1f);  //1�� �Ŀ� SpawnBall �Լ� ����
        }
        else
        {
            GameOver();
        }
    }
    //�� ���� �� ���� �Լ�
    void SpawnBall()
    {
        if(paddleTransform != null && ballPrebab != null)
        {
            // ���� �е� ��ġ�� ��ġ (offset�� ballControll���� ó��
            Vector3 spawnPosition = paddleTransform.position + new Vector3(0, 0.5f, 0);
            currenBall = Instantiate(ballPrebab, spawnPosition, Quaternion.identity);

            //�� ��Ʈ�ѷ��� "���� �߻���� ����" ���¸� �˷���
            BallController ballController = currenBall.GetComponent<BallController>();
            if(ballController != null)
            {
                //�� �Լ��� BallController�� �߰��ϰ� ȣ���ϸ�, IsMoving �� Collider ���¸� ��Ȱ��ȭ�� �� ���� ó������
                //ballController.ResetBallState();
            }

        }
    }

    //���� ���� ó�� �Լ�
    void GameOver()
    {
        Debug.Log("Game Over! Final Score : " +currentScore);
        //�߰����� ���� ���� ó�� ���� �ۼ� ����
    }
}
