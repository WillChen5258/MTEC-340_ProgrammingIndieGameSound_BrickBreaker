using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode LeftDirection = KeyCode.A;
    public KeyCode RightDirection = KeyCode.D;
    
    void Update()
    {
        float movement = 0.0f;

        if (Input.GetKey(LeftDirection))
        {
            movement -= Speed;
        }

        if (Input.GetKey(RightDirection))
        {
            movement += Speed;
        }

        transform.Translate(new Vector3(movement, 0.0f, 0.0f) * Time.deltaTime);
    }
}