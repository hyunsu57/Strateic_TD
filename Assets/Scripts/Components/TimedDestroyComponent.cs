using UnityEngine;
//시간이 지나면 오브젝트를 삭제하는 컴포넌트
public class TimedDestroyComponent : MonoBehaviour
{

    [SerializeField] float destroyTime = 1f; // 오브젝트가 삭제되기까지의 시간

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
