using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //get reference to player
    public Transform Player;

    //set sensitivity 
    public float MouseSens = 100f;

    //float for xRotation
    public float xRot = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to center and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

        //rotate camera pivot around player
        Player.Rotate(Vector3.up * mouseX);

        //adjust verticle rotation w clamping 
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -35f, 60f);

        //apply movement 
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);








    }
}
