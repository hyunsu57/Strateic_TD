using UnityEngine;

public class MovementBoundsComponent : MonoBehaviour
{
    [SerializeField] float minX = -10f;
    [SerializeField] float maxX = 10f;
    [SerializeField] float minY = -10f;
    [SerializeField] float maxY = 10f;

    // 이동범위 제한
    // LateUpdate는 모든 Update가 끝난 후에 호출된다.
    private void LateUpdate()
    {
        Vector3 position = transform.position;  // transform.position은 play의 위치다
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
