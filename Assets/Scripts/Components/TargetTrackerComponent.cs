using UnityEngine;
using R3;
using System.Collections.Generic;

//공격범위내의 대상 담당 클래스
// 가까운 대상을 찾는 함수를 추가
public class TargetTrackerComponent : MonoBehaviour
{
    List<IDamageable> targets = new List<IDamageable>();    // 현재 추적 중인 타겟 리스트
    readonly Subject<IDamageable> targetAddedSubject = new Subject<IDamageable>();  // 타겟이 추가될 때 알림을 보내는 Subject
    public Observable<IDamageable> OnTargetAdded => targetAddedSubject; // 타겟이 추가될 때 구독할 수 있는 Observable

    private void Awake() {
        targetAddedSubject.AddTo(this);
    }   

    // 타겟 추가 함수, 타겟이 null 이 아니고 살아있고, 이미 리스트에 없는 경우에만 추가
    public void AddTarget(IDamageable target) {
        if (target != null && target.IsAlive && !targets.Contains(target)) {
            targets.Add(target);
            Debug.Log($"타겟 추가: {target}");
            targetAddedSubject.OnNext(target);
        }
    }
    
    // 타겟 제거 함수, 타겟이 null 이 아니고 리스트에 있는 경우에만 제거
    public void RemoveTarget(IDamageable target) {
        if (target != null && targets.Contains(target)) {
            targets.Remove(target);
            Debug.Log($"타겟 제거: {target}");
        }
    }

    // 살아있는 타겟 리스트 반환 함수, 리스트에서 null 이거나 죽은 타겟 제거 후 반환
    public List<IDamageable> GetAliveTargets() {
        targets.RemoveAll(target => target == null || !target.IsAlive); // 리스트에서 null 이거나 죽은 타겟 제거
        return new List<IDamageable>(targets); // 살아있는 타겟 리스트 반환
    }
    

    // 가까운 공격대상을 찾기
    public IDamageable GetNearestTarget(Vector3 currentPosition) {
        // 외부에서 currentPosition 로 위치가 전달된다.
        IDamageable nearestTarget = null;
        float nearestDistance = Mathf.Infinity; 

        foreach(var target in targets) {
            if(target != null && target.IsAlive) {
                // 타겟과의 거리 계산, target.RelatedGameObject 는 IDamageable 인터페이스에서 구현된 속성으로, 타겟의 게임 오브젝트를 반환한다.
                float distance = Vector3.Distance(currentPosition, target.RelatedGameObject.transform.position); 
                if(distance < nearestDistance) {
                    nearestDistance = distance;
                    nearestTarget =  target;

                }
            }
        }

        return nearestTarget;
    }

    // 디버그용, 가장가까운 대상의 정보를 노출
    public void LogNearestTarget() {
        Vector3 currentPosition = transform.position;   // 현재 위치
        IDamageable nearestTarget = GetNearestTarget(currentPosition); // 가장 가까운 타켓
        if (nearestTarget != null) {
            Debug.Log($"가장 가까운 타겟: {nearestTarget}");
        } else {
            Debug.Log("타겟이 없습니다.");
        }
    }


}
