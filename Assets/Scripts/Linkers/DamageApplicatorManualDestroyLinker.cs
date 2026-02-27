using UnityEngine;
using R3;


[RequireComponent(typeof(DamageApplicatorComponent))]
[RequireComponent(typeof(ManualDestroyComponent))]
// 총알과 대상이 맞으면 총알이 사라지면서 데미지를 주는 기능
public class DamageApplicatorManualDestroyLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var damageApplicator = GetComponent<DamageApplicatorComponent>();
        var manualDestroy = GetComponent<ManualDestroyComponent>();

        if(damageApplicator == null || manualDestroy == null) {
            Debug.LogError("DamageApplicatorComponent or ManualDestroyComponent is not assigned.");
            return; 
        }


        damageApplicator.OnDamageApplied
        .Subscribe(_=> manualDestroy.DestroySelf()).AddTo(this); // DamageApplicatorComponent의 OnDamageApplied 이벤트에 구독자로 등록하여 데미지가 적용될 때마다 DestroySelf 메서드가 호출되도록 설계
    }

}
