using UnityEngine;
using R3;
using System.Collections.Generic;

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
    

}
