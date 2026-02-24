using UnityEngine;
using R3;


[RequireComponent(typeof(ObjectSpawnerComponent))]
// 가장가까운 대상에게 총알을 발사하게 해야함
public class ObjectSpawnerTargetTrackerLinker : MonoBehaviour
{

    [SerializeField] TargetTrackerComponent targetTracker; // 드래그를 해서 정보를 받고
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 오브젝트 할당으로 ObjectSpawnerComponent의 정보를 받아와야한다.
        var objectSpawner = GetComponent<ObjectSpawnerComponent>();
        if(objectSpawner == null || targetTracker == null) {
            Debug.LogError("ObjectSpawnerComponent or TargetTrackerComponent is not assigned.");
            return;
        }

        // ObjectSpawnerComponent의 OnObjectSpawned 이벤트에 구독자로 등록하여 총알이 생성될 때마다 HandleObjectSpawned 메서드가 호출되도록 설정  
        // spawnedObject은 생성시점의 탄환정보를 가져온다
        objectSpawner.OnObjectSpawned.Subscribe(spawnedObject => HandleObjectSpawned(spawnedObject)).AddTo(this); 
    }

    void HandleObjectSpawned(GameObject spawnedObject) {
        var movement = spawnedObject.GetComponent<MovementComponent>();
        if(movement == null) {
            Debug.LogError("Spawned object does not have a MovementComponent.");
            return;
        }

        // 가장 가까운 대상을 찾는 기능 
        var nearestTarget= targetTracker.GetNearestTarget(spawnedObject.transform.position);    // 총알이 생성된 위치에서 가장 가까운 대상을 찾는 기능을 구현해야한다.
        if(nearestTarget != null) {

            // 방향을 계산해서 총알 발사 방향을 설정하는 기능
            Vector3 direction = (nearestTarget.RelatedGameObject.transform.position - spawnedObject.transform.position).normalized;
            movement.SetDirection(direction);   // 방향으로 총알이 발사되도록 설정하는 기능
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
