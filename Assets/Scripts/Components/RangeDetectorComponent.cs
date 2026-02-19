using UnityEngine;
using R3;

public class RangeDetectorComponent : MonoBehaviour
{

    readonly Subject<IDamageable> targetEnteredSubject = new Subject<IDamageable>();
    readonly Subject<IDamageable> targetExitedSubject = new Subject<IDamageable>();
    public Subject<IDamageable> OnTargetEntered => targetEnteredSubject;
    public Subject<IDamageable> OnTargetExited => targetExitedSubject;
    
    [SerializeField] string targetTag = "Enemy";


    void Awake() {
        targetEnteredSubject.AddTo(this);
        targetExitedSubject.AddTo(this);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(targetTag)) {
            var damageable = other.GetComponent<IDamageable>();
            if(damageable != null) {
                Debug.Log("공격범위에 들어왔습니다 ");
                targetEnteredSubject.OnNext(damageable);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(targetTag)) {
            var damageable = other.GetComponent<IDamageable>();
            if(damageable != null) {
                Debug.Log("공격범위에서 나갔습니다 ");
                targetExitedSubject.OnNext(damageable);
            }
        }
    }
}
