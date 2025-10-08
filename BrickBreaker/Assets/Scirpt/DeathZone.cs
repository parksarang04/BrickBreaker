using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //OnTriggerEnter2D : Is Trigger가 체크된 Collider와 닿았을 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. 닿은 오브젝트가 'Ball' 태그를 가지고 있는지 확인
        if (other.CompareTag("Ball"))
        {
            // 2. 공이 데스 존에 빠진 경우 처리(오브젝트 비활성화)
            other.gameObject.SetActive(false);

        }
    }
}
