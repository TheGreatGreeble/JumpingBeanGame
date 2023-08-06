using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    // Trajectory Rendering vars
    [Header("Trajectory Line Renderer")]
    private LineRenderer jumpLine;
    [SerializeField]
    [Range(10,100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;

    // jumping variables
    [Header("Jumping")]
    private bool prepingJump;
    private KeyCode jumpKey;
    private bool isJump;
    [SerializeField]
    private float maxStrength;
    [SerializeField]
    private float minStrength;
    [SerializeField]
    private float maxAngleHeight;
    [SerializeField]
    private float maxAngleWidth;
    private float jumpStrength; // the actual strength of the current jump
    private Vector3 jumpAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        prepingJump = false;
        isJump = false;
        jumpKey = KeyCode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (prepingJump) {
            if (Input.GetKey(jumpKey)) {
                // render jump trajectory
                DrawProjection();
            } else if (Input.GetKeyUp(jumpKey)) {
                // jump on trajectory line
                rb.AddForce(jumpAngle * jumpStrength, ForceMode.Impulse);
                isJump = true;
                prepingJump = false;

            }
        }
    }

    private void FixedUpdate() {
        if (prepingJump) {
            
        }
    }

    private void DrawProjection() {

    }

    public void ReceiveJumpInput(KeyCode key) {
        if (prepingJump) {
            return;
        }
        prepingJump = true;
        jumpKey = key;
        jumpStrength = Random.Range(minStrength, maxStrength);
        jumpAngle = new Vector3(0f, 0.3f, 1f).normalized;

    }


}
