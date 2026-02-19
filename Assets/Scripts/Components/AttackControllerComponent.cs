using UnityEngine;
using R3;


public class AttackControllerComponent : MonoBehaviour
{
    // 공격대상이 공격범위에 들어오면 알림을 보내고, 공격대상이 공격범위에서 나가면 알림을 보내는 컴포넌트
    // 원거리 캐릭터는 범위에 적이 있으면 가장 가까운적, 근접 캐릭터는 가장 가까운 적에게 공격 하도록 이렇게 했다
    readonly Subject<Unit>  attackStartSubject = new Subject<Unit>();
    readonly Subject<Unit> attackEndSubject = new Subject<Unit>();
    public Observable<Unit> OnAttackStart => attackStartSubject;
    public Observable<Unit> OnAttackEnd => attackEndSubject;
    

    bool isAttacking = false;

    private void Awake() {
        // 메모리 누수를 위해 소스 추가
        attackStartSubject.AddTo(this);
        attackEndSubject.AddTo(this);
        
    }

    public void StartAttack() {
        if(!isAttacking) {
            Debug.Log("공격시작");
            isAttacking = true;
            attackStartSubject.OnNext(Unit.Default);
        }
    }

    public void EndAttack() {
        if(isAttacking){
            Debug.Log("공격중단");
            isAttacking = false;
            attackEndSubject.OnNext(Unit.Default); 
        }
    }
}
