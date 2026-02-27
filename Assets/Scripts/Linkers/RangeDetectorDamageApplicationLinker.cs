using UnityEngine;
using R3;


[RequireComponent(typeof(DamageApplicatorComponent))]
[RequireComponent(typeof(RangeDetectorComponent))]
// 총알이 적중했을때 데미지를 주는 기능
public class RangeDetectorDamageApplicationLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rangeDetector = GetComponent<RangeDetectorComponent>();
        var damageApplicator = GetComponent<DamageApplicatorComponent>();

        if(rangeDetector == null || damageApplicator == null ) {
            Debug.LogError("RangeDetectorComponent or DamageApplicatorComponent is not assigned.");
            return;
        }   

    
        rangeDetector.OnTargetEntered
        .Subscribe(target => damageApplicator.ApplyDamage(target))
        .AddTo(this); // RangeDetectorComponent의 OnTargetEntered 이벤트에 구독자로 등록하여 대상이 범위에 들어올 때마다 ApplyDamage 메서드가 호출되도록 설계
    }

    
}
