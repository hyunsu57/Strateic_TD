using UnityEngine;
using R3;


[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(ManualDestroyComponent))]  
public class HealthManualDestroyLinker : MonoBehaviour
{       
    // 이 스크립트는 HealthComponent 와 ManualDestroyComponent 를 연결하는 역할을 한다.
    // RequireComponent 어트리뷰트는 해당 컴포넌트가 반드시 존재해야 함을 명시, 이렇게 추가하면 유니티에서 링커를 컴포넌트에 추가하면 자동으로 RequireComponent 로 선언된 스크립트들이 추가된다.
    
    // HealthComponent 와 ManualDestroyComponent 연결고리, 링크연결
    void Start() {
        // getComponent : 해당 오브젝트에 붙어있는 컴포넌트를 가져오는 함수
        var healthComponent = GetComponent<HealthComponent>();
        var manualDestroyComponent = GetComponent<ManualDestroyComponent>();

        if(healthComponent == null) {
            Debug.LogError("HealthComponent not found on " + gameObject.name);
            return;
        }

        // 구독 , 옵저버 패턴
        // healthComponent 의 deathSubject 가 알림을 보내면, manualDestroyComponent 의 DestroySelf() 함수 실행
        // healthComponent.deathSubject.Subscribe(_ => {
        //     manualDestroyComponent.DestroySelf();
        // });

        healthComponent.OnDeath.Subscribe(_ => {
            manualDestroyComponent.DestroySelf();
        }).AddTo(this); // this : HealthManualDestroyLinker 가 파괴될때 구독도 자동으로 해제됨
    }

    void Update() {
        
    }
}   
