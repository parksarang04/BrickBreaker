using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //����(static) ������ �̿��ϸ� �ٸ� ��ũ��Ʈ���� GameManager.instance.������ ���� ���� ����
    public static GameManager Instance;

    //���� ���� ����(Inspector)���� ���� ����
    private bool isGameOver = false;
    
    public int totalBricks;       //���� ������ ��ü ���� ��
    public float ballSpeed = 8f;  // 
    public GameObject gameOverText;
   

    //public bool isGameOver;
    //�� ������ ���� ����(Inspector)���� ���� ����
    public GameObject ballPrefab;
    private Transform paddleTransform;

    //Ȱ��ȭ�� �� ������Ʈ
    private GameObject currentBall;

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
        
        if(isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            //���� ���� ���¿��� R Ű�� ������ ���� �����
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    //�� ���� �� ���� �Լ�
    public void SpawnBall()
    {
        if(paddleTransform != null && ballPrefab != null)
        {
            // ���� �е� ��ġ�� ��ġ (offset�� ballControll���� ó��
            Vector3 spawnPosition = paddleTransform.position + new Vector3(0, 0.5f, 0);
            currentBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

            //�� ��Ʈ�ѷ��� "���� �߻���� ����" ���¸� �˷���
            BallController ballController = currentBall.GetComponent<BallController>();
            if(ballController != null)
            {
                //�� �Լ��� BallController�� �߰��ϰ� ȣ���ϸ�, IsMoving �� Collider ���¸� ��Ȱ��ȭ�� �� ���� ó������
                //ballController.ResetBallState();
            }

        }
    }


    //���� ���� ó�� �Լ�
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }
}
