using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    Event e;
    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnGUI() {
        
        e = Event.current;
        if (e.isKey) {
            Debug.Log("Event!");
            pm.ReceiveJumpInput(e.keyCode);
        }
    }



    //


}
