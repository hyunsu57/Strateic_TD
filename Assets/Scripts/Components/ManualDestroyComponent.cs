using UnityEngine;

public class ManualDestroyComponent : MonoBehaviour
{

    // 총알이 자기 자신을 파괴하는 기능
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
