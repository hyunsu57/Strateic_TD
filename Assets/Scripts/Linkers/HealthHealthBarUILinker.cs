using UnityEngine;
using R3;

[RequireComponent(typeof(HealthBarUIComponent))]
public class HealthHealthBarUILinker : MonoBehaviour
{
    [SerializeField] HealthComponent health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var healthBarUI = GetComponent<HealthBarUIComponent>();
        if(health == null || healthBarUI == null) {
            Debug.LogError("HealthComponent or HealthBarUIComponent not found on " + gameObject.name);
            return;
        }

        health.CurrentHealth
            .Subscribe(currentHealth => {
                healthBarUI.UpdateHealth(currentHealth);
            })
            .AddTo(this); // this : HealthHealthBarUILinker 가 파괴될때 구독도 자동으로 해제됨
        healthBarUI.Initialize(health.maxHealth); // 초기화
    }


}
