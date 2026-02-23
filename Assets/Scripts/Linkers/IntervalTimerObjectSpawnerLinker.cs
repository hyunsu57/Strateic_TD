using UnityEngine;
using R3;

[RequireComponent(typeof(IntervalTimerComponent))]
[RequireComponent(typeof(ObjectSpawnerComponent))]

//일정 간격으로 탄환을 만드는 클래스를 연결하기위해 링커클래스를 만듬
public class IntervalTimerObjectSpawnerLinker : MonoBehaviour
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var intervalTimer = GetComponent<IntervalTimerComponent>(); // IntervalTimerComponent 컴포넌트를 가져오는 부분, 이 코드를 통해 IntervalTimerComponent의 기능을 사용할 수 있게 된다.
        var objectSpawner = GetComponent<ObjectSpawnerComponent>(); // ObjectSpawnerComponent 컴포넌트를 가져오는 부분, 이 코드를 통해 ObjectSpawnerComponent의 기능을 사용할 수 있게 된다.

        if(intervalTimer == null || objectSpawner == null){
            Debug.LogError("Missing components! Please add IntervalTimerComponent and ObjectSpawnerComponent to the GameObject.");
            return;
        }

        intervalTimer.OnIntervalElapsed.Subscribe(_ => objectSpawner.Spawn()).AddTo(this); // IntervalTimerComponent의 OnIntervalElapsed 이벤트를 구독하는 부분, 이 코드를 통해 IntervalTimerComponent에서 설정된 간격마다 ObjectSpawnerComponent의 Spawn 메서드가 호출되도록 연결된다.
    }

}
