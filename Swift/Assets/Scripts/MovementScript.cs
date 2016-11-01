using UnityEngine;
using System.Collections;
[AddComponentMenu("Movement/MoveScript")]
public class MovementScript : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardSpeed = 10.0f;
    public float backwardSpeed = 7.0f;
    public float strafeSpeed = 8.5f;
    public float jumpspeed = 10.0f;
    Vector3 momentum;
    Vector3 direction;
    Vector3 originalPosition;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(direction * forwardSpeed);
    }
}
