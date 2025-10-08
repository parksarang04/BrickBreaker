using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab;

    // Inspector에서 조절할 수 있는 배열 크기
    public int rows = 5;       // 생성할 벽돌의 행
    public int cols = 10;      // 생성할 벽돌의 열

    // 벽돌의 위치와 간격 설정
    public float spacingX = 1.1f;  // X축 간격
    public float spacingY = 0.55f; // Y축 간격

    private BoxCollider2D areaCollider;

    void Start()
    {
        areaCollider = GetComponent<BoxCollider2D>();

        if (areaCollider == null)
        {
            Debug.LogError("LevelGenerator에 BoxCollider2D 컴포넌트가 필요합니다. 배열이 생성되지 않습니다.");
            return; // 컴포넌트가 없으면 여기서 실행 중단
        }

        // GenerateBricks() 함수 호출을 한 번만 실행
        GenerateBricks();
        Debug.Log("Level Generator Started Rows : " + rows);
    }

    void GenerateBricks()
    {
        // Collider가 없으면 에러를 내지 않고 종료 (Start()에서 이미 체크했지만 안전장치)
        if (areaCollider == null) return;

        // BoxCollider2D의 경계 계산
        Bounds bounds = areaCollider.bounds;

        //시작 위치 설정 (BoxCollider의 좌측 상단 모서리)
        // newStartPosition = 콜라이더의 가장 왼쪽 X 좌표, 가장 위쪽 Y 좌표
        Vector3 finalStartPosition = new Vector3(bounds.min.x, bounds.max.y, 0f);

        // Brick 프리팹의 크기를 기반으로 위치를 보정
        // 이것은 벽돌의 중심점(Pivot)을 배열의 시작점(Top-Left)에 맞추기 위한 보정.
        // 이 값을 조정해야 벽돌 배열이 콜라이더 경계선에 딱 맞게 생성
        // Brick 오브젝트의 Collider2D를 가져와 정확한 크기를 구하는 것
        // 여기서는 임시 값 0.5f를 사용합니다. (Brick의 높이가 1이라고 가정)
        float brickHalfHeight = 0.5f;
        finalStartPosition.y -= brickHalfHeight; // 중심점을 맞추기 위해 Y축을 벽돌 절반 높이만큼 내립니다.


        // 1. 이중 반복문 사용 : 행과 열을 모두 순회
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

                // 벽돌 생성 (Instantiate)
                Instantiate(brickPrefab, position, Quaternion.identity);               
            }
        }
    }
}