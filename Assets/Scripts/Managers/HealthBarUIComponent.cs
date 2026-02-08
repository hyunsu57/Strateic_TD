using UnityEngine;
using UnityEngine.UI;

// 슬라이더를 사용하기위에 UI를 사용 
public class HealthBarUIComponent : MonoBehaviour
{
    Slider healthBarSlider;

    private void Awake()
    {
        healthBarSlider = GetComponent<Slider>();   // 슬라이더 컴포넌트를 가져옴
        if (healthBarSlider == null)
        {
            Debug.LogError("HealthBarUIComponent requires a Slider component.");
        }
    }

    public void Initialize(int maxHealth)
    {
        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = maxHealth;
            healthBarSlider.value = maxHealth;
        }
    }


    public void UpdateHealth(int currentHealth)
    {
        if (healthBarSlider != null)
        {
            healthBarSlider.value = currentHealth;
        }
    }
}
