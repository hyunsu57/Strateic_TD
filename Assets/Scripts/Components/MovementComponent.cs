using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    // 탄환을 움직이는 클래스 생성 - 탄환을 움직이는게 필요
    // 일정간격마다 움직이는 클래스 생성
    // 알림이 오면 총알을 생성하는 클래스 생성
    // 일정 시간이 지나면 탄환이 삭제되는 부분도 생성 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float moveSpeed = 5f; // 총알의 이동 속도
    [SerializeField] Vector3 moveDirection = Vector3.forward; // 총알의 이동 방향

    
    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;   // 탄환을 이동시키는 부분, 이 코드를 통해 탄환이 오른쪽으로 이동된다.
    }

    //가장 가까운 대상을 타켓팅 하는 함수
    public void SetDirection(Vector3 direction) {
        moveDirection = direction;
    }
}
