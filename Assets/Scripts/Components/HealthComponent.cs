using UnityEngine;
using R3;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;

    [SerializeField] SerializableReactiveProperty<int> currentHealth = new SerializableReactiveProperty<int>();
    public ReadOnlyReactiveProperty<int> CurrentHealth => currentHealth;

    // 버블을 방지하기위해 내부에서만 조작하도록 protected 
    bool isAlive = true;
    public bool IsAlive => isAlive;

    readonly public Subject<Unit> deathSubject = new Subject<Unit>();    //알림을 보내는 클래스 , 유니티 이벤트를 보낼때 사용
    public Observable<Unit> OnDeath => deathSubject; //구독자가 구독할 수 있는 observable 속성
    public GameObject RelatedGameObject => gameObject; // IDamageable 인터페이스 구현, 자신의 게임 오브젝트 반환
    void Awake()
    {
        deathSubject.AddTo(this); // HealthComponent 가 파괴될때 구독도 자동으로 해제됨, 메모리 누수 방지
        currentHealth.AddTo(this);
        isAlive = true;
        // Awake 함수는 게임 오브젝트가 활성화될 때 호출됩니다. start 함수보다 먼저 실행됩니다.

        currentHealth.Value = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        if(!isAlive) return;

        currentHealth.Value -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage.");

        if(currentHealth.Value <= 0)
        {
            Die();
        }   
    }

    public void Die()
    {
        if(!isAlive) return; // 이미 죽은 상태라면 중복 처리 방지\
        isAlive = false;
        
        // 여기에 죽음 처리 로직을 추가하세요 (예: 애니메이션 재생, 오브젝트 비활성화 등)
        gameObject.SetActive(false);

        // 구독자에게 죽음 알림 전송    , onDeath.invoke() 와 동일
        deathSubject.OnNext(Unit.Default);
        Debug.Log($"{gameObject.name} has died.");
    }

}
