using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
    bool IsAlive { get; }

    // 대상의 거리를 파악하기위함
    GameObject RelatedGameObject { get; }
}
