using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY);
        transform.position += new Vector3(movement.x, movement.y, 0f) * moveSpeed * Time.deltaTime;
    }
}

