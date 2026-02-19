using UnityEngine;
using R3;

[RequireComponent(typeof(TargetTrackerComponent))]
[RequireComponent(typeof(RangeDetectorComponent))]

//공격범위에 들어온 대상을 전달하는 링커
public class RangeDetectorTargetTrackerLinker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 타켓 트랙커 정보
        var rangeDetector = GetComponent<RangeDetectorComponent>();
        var targetTracker = GetComponent<TargetTrackerComponent>();

        if(rangeDetector == null || targetTracker == null) {
            Debug.Log("RangeDetectorComponent or TargetTrackerComponent not found on " + gameObject.name);
            return;
        }

        // 공격 범위에 들어온 대상을 타겟 트랙커에 추가
        rangeDetector.OnTargetEntered.Subscribe(target => targetTracker.AddTarget(target)).AddTo(this);
        // 공격 범위에서 나간 대상을 타겟 트랙커에서 제거
        rangeDetector.OnTargetExited.Subscribe(target => targetTracker.RemoveTarget(target)).AddTo(this);
    }


}
