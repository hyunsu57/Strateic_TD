using UnityEngine;
using R3;

// 데미지를 주는 클래스
public class DamageApplicatorComponent : MonoBehaviour
{

    // 데미지량과 데미지를 알려주는 기능이 필요
    [SerializeField] int attackPower = 15;
    readonly Subject<Unit> damageAppliedSubject = new Subject<Unit>();
    public Observable<Unit> OnDamageApplied => damageAppliedSubject;

    private void Awake() {
        damageAppliedSubject.AddTo(this);
    }

    //데미지를 주는 기능
    public void ApplyDamage(IDamageable target) { // 외부에서 데미지와 타켓 정보를 받아오게끔함
        if(target != null) {
            target.TakeDamage(attackPower);
            damageAppliedSubject.OnNext(Unit.Default); // 데미지가 적용되었다는 이벤트를 발행
        }
    }
}
