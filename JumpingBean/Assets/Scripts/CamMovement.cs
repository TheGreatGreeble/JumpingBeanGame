using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private Transform body;
    private GameObject player;

    private Vector3 mouseInput;
    [SerializeField]
    [Range(1f, 10f)]
    private float mouseSensetivity = 4f;

    private const float minYAngle = -50f;
    private const float maxYAngle = 50f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        body = player.GetComponentInChildren<Rigidbody>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        mouseInput.x = Input.GetAxis("Mouse X") * mouseSensetivity;
        mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensetivity;
    }

    private void FixedUpdate() {
        transform.position = player.transform.position;
        if (mouseInput.magnitude != 0) {
            //transform.Rotate(mouseInput * mouseSensetivity * 1000 * Time.deltaTime);
            //transform.Rotate(Vector3.up, mouseInput.y * 900 * Time.deltaTime);
            //transform.Rotate(transform.right, -mouseInput.x * 900 * Time.deltaTime);
            mouseInput.y = Mathf.Clamp(mouseInput.y, minYAngle, maxYAngle);

            Quaternion rotation = Quaternion.Euler(mouseInput * Time.deltaTime);


        }

    }
}
