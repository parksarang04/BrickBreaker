using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;

    public GameObject brickPrefab;

    // Inspector에서 조절할 수 있는 배열 크기
    public int rows = 5;       // 생성할 벽돌의 행
    public int cols = 10;      // 생성할 벽돌의 열

    // 벽돌의 위치와 간격 설정
    public float spacingX = 1.1f;  // X축 간격
    public float spacingY = 0.55f; // Y축 간격

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

        // BoxCollider2D 컴포넌트 가져오기
        areaCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        // Level 1의 벽돌 생성
        GenerateBricks();
    }

    // LevelGenerator가 활성화될 때 실행
    public void GenerateNextLevel(int level)
    {
        // 기존 맵의 벽돌 모두 파괴
        DestroyExistingBricks();

        // 난이도에 따라 배열 크기 또는 생성 패턴 변겅
        rows = 5 + (level - 1); //레벨이 올라갈수록 행이 하나씩 추가

        // 새로운 벽돌 생성 로직 호출
        GenerateBricks();
    }

    // 기존 맵의 벽돌 모두 파괴
    private void DestroyExistingBricks()
    {
        // 씬에 있는 모든 "Brick" 태그 오브젝트를 찾는다
        GameObject[] oldBricks = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject brick in oldBricks)
        {
            Destroy(brick);
        }
    }

    void GenerateBricks()
    {
        // Collider가 없으면 에러를 내지 않고 종료 (안전장치)
        if (areaCollider == null) return;

        // BoxCollider2D의 경계 계산
        Bounds bounds = areaCollider.bounds;

        //시작 위치 설정 (BoxCollider의 좌측 상단 모서리)
        Vector3 finalStartPosition = new Vector3(bounds.min.x, bounds.max.y, 0f);

        // Brick 프리팹의 크기를 기반으로 위치를 보정 (중심점을 맞추기 위함)
        float brickHalfHeight = 0.5f;
        finalStartPosition.y -= brickHalfHeight; // 중심점을 맞추기 위해 Y축을 벽돌 절반 높이만큼 내립니다.

        // 1. 이중 반복문 사용 : 행과 열을 모두 순회
        int count = 0;

        //현재 레벨에 따른 최대 내구도 계산
        int maxHP = 1 + (rows / 3);
        if (maxHP < 1) maxHP = 1;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // 시작 위치에서 출발
                Vector3 position = finalStartPosition;

                // j에 따라 X축 위치를 옆으로 이동
                position.x += j * spacingX;

                // i에 따라 Y축 위치를 아래로 이동
                position.y -= i * spacingY;
                // 누락된 위치 계산 로직 복구

                // 벽돌 생성 (Instantiate)
                GameObject newBrickObject = Instantiate(brickPrefab, position, Quaternion.identity);

                // 내구도 할당 로직
                Brick newBrick = newBrickObject.GetComponent<Brick>();
                if (newBrick != null)
                {
                    // 1. 내구도 랜덤 설정 (1부터 maxHP까지)
                    newBrick.hitPoints = Random.Range(1, maxHP + 1);

                    //newBrick.UpdateColor();
                }
                //내구도 할당 로직 끝

                count++;
            }
        }
        GameManager.Instance.totalBricks = count;
    }
}