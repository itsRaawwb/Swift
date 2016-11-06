using UnityEngine;
using System.Collections;
[AddComponentMenu("Movement/MoveScript")]
public class MovementScript : MonoBehaviour
{
    private Vector3 forward;
    private Rigidbody rb;
    private Transform Mcam;
    //input Keys
    private float moveHorizontal =0.0f,
                    moveVertical = 0.0f;
    private bool jump;
    private const float k_GroundRayLength = 1.5f;
    private float m_JumpPower = .7f;


    public float forwardSpeed = 10.0f;

    Vector3 momentum;
    Vector3 direction;
    Vector3 originalPosition;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Mcam = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Define local vectors based on where im facing
        Vector3 forward = Mcam.TransformDirection(Vector3.forward);
        Vector3 right = Mcam.TransformDirection(Vector3.right);
        GetInput();

        if (Physics.Raycast(transform.position, Vector3.down, k_GroundRayLength) && jump)
            AddJumpForce();

        AddMoveForce(forward, right);
        UpdateCamera();
    }

    void GetInput()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        jump = Input.GetKey(KeyCode.Space);
    }

    void AddJumpForce()
    {
        rb.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
    }

    void AddMoveForce(Vector3 forward, Vector3 right)
    {
        rb.AddForce(new Vector3(forward.x, 0, forward.z) * moveVertical * forwardSpeed);
        rb.AddForce(new Vector3(right.x, 0, right.z) * moveHorizontal * forwardSpeed);
    }

    void UpdateCamera()
    {
        Mcam.position = transform.position + new Vector3(0, 0.5f, 0);
    }
}
