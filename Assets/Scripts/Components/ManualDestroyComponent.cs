using UnityEngine;

public class ManualDestroyComponent : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
