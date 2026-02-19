using UnityEngine;
using R3;
using System.Collections.Generic;

public class TargetTrackerComponent : MonoBehaviour
{
    List<IDamageable> targets = new List<IDamageable>();
    readonly Subject<IDamageable> targetAddedSubject = new Subject<IDamageable>();
    public Observable<IDamageable> OnTargetAdded => targetAddedSubject;

    private void Awake() {
        targetAddedSubject.AddTo(this);
    }   

    public void AddTarget(IDamageable target) {
        if (target != null && target.IsAlive && !targets.Contains(target)) {
            targets.Add(target);
            Debug.Log($"타겟 추가: {target}");
            targetAddedSubject.OnNext(target);
        }
    }
    public void RemoveTarget(IDamageable target) {
        if (target != null && targets.Contains(target)) {
            targets.Remove(target);
            Debug.Log($"타겟 제거: {target}");
        }
    }
    

}
