using UnityEngine;
using R3;


// 총알 생성 클래스
public class ObjectSpawnerComponent : MonoBehaviour
{
    //총알의 정보가 전달되어야 한다.
    [SerializeField] GameObject prefab;
    readonly Subject<GameObject> objectSpawnedSubject = new Subject<GameObject>();
    public Observable<GameObject> OnObjectSpawned => objectSpawnedSubject;

    void Awake() {
        objectSpawnedSubject.AddTo(this);
    }

    public void Spawn() {
        var spawnedObject = Instantiate(prefab, transform.position, transform.rotation); // 메모리 누수 방지 위해서 오브젝트 풀링을 사용하는 것이 좋다.
        objectSpawnedSubject.OnNext(spawnedObject); // 총알이 생성되면 구독자들에게 알림을 보내는 부분, 이 코드를 통해 총알이 생성될 때마다 구독자들에게 알림이 전달된다.
    }

}
