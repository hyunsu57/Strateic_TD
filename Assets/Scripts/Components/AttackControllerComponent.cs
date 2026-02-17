using UnityEngine;
using R3;


public class AttackControllerComponent : MonoBehaviour
{

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
