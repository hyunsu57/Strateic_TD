using UnityEngine;
using R3;

[RequireComponent(typeof(AttackControllerComponent))]

public class TargetTrackerAttackControllerLinker : MonoBehaviour
{

    [SerializeField] TargetTrackerComponent targetTracker; // 타겟 트랙커 컴포넌트 참조
    AttackControllerComponent attackController; // 공격 컨트롤러 컴포넌트 참조

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackController = GetComponent<AttackControllerComponent>();

        if(targetTracker == null || attackController == null) {
            Debug.Log("TargetTrackerComponent or AttackControllerComponent not found on " + gameObject.name);
            return;
        }

        targetTracker.OnTargetAdded.Subscribe(_ => attackController.StartAttack()).AddTo(this); // 타겟이 추가될 때 공격 컨트롤러에 타겟 설정
    }


    void Update()
    {
        if(targetTracker == null || attackController == null) {
            return;
        }
        
        if(targetTracker.GetAliveTargets().Count == 0) {
            attackController.EndAttack(); // 살아있는 타겟이 없으면 공격 컨트롤러의 타겟 제거
        }
    }

    
}
