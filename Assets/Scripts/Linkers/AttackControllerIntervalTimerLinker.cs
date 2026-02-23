using UnityEngine;
using R3;

[RequireComponent(typeof(AttackControllerComponent))]
[RequireComponent(typeof(IntervalTimerComponent))]
// 공격 컨트롤러와 인터벌 타이머를 연결하는 클래스
public class AttackControllerIntervalTimerLinker : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var attackController = GetComponent<AttackControllerComponent>(); // AttackController 컴포넌트를 가져오는 부분, 이 코드를 통해 AttackController의 기능을 사용할 수 있게 된다.
        var intervalTimer = GetComponent<IntervalTimerComponent>(); // IntervalTimerComponent 컴포

        if(attackController == null || intervalTimer == null) {
            Debug.LogError("Missing components! Please add AttackController and IntervalTimerComponent to the GameObject.");
            return;
        }   

        attackController.OnAttackStart.Subscribe(_=> intervalTimer.StartTimer()).AddTo(this); 
        attackController.OnAttackEnd.Subscribe(_=> intervalTimer.StopTimer()).AddTo(this);
    }


}
