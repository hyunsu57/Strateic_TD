using UnityEngine;
using R3;

// 일정 간격으로 OO 이를 한다?
// 총알을 발사한다는가
// 무언가 알림을 받으면 일정간격으로 OO 를 하게 해주는 클래스
// 추가로 탄환 제어할수있는 기능을 추가한다.
public class IntervalTimerComponent : MonoBehaviour
{
    [SerializeField] float interval = 1.0f; // 몇초마다 알림을 보낼지 설정하는 변수, 이 코드를 통해 알림이 몇 초마다 보내질지를 설정할 수 있다.
    private float timer = 0.0f; // 타이머 변수

    // 알림을 보내는 수준
    readonly Subject<Unit> intervalElapsedSubject = new Subject<Unit>();
    public Observable<Unit> OnIntervalElapsed => intervalElapsedSubject;

    private bool isRunning = false;

    
    void Awake(){
        intervalElapsedSubject.AddTo(this);
    }


    // Update is called once per frame
    void Update()
    {
        if(isRunning) {
            timer += Time.deltaTime; // 타이머에 프레임마다 경과한 시간을 더하는 부분, 이 코드를 통해 타이머가 매 프레임마다 증가하게 된다.
            if(timer >= interval) { 
                intervalElapsedSubject.OnNext(Unit.Default); // 구독자들에게 알림을 보내는 부분, 이 코드를 통해 설정된 간격마다 구독자들에게 알림이 전달된다.
                Debug.Log("Interval Elapsed!");
                timer = 0.0f;
            }
        }
    }

    public void StartTimer() {
        isRunning = true;
        timer = interval;
    }

    public void StopTimer() {
        isRunning = false;
    }   
}
