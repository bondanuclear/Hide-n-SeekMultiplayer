using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float xSens = 5f;
    [SerializeField] float ySens = 5f;
    [SerializeField] float maxYValue = 175f;
    [SerializeField] float minYValue = -140f;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] Transform player;
    float xRotation = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log(Cursor.lockState);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        //Quaternion rot = Quaternion.Euler(angleY, 0, 0);
       // transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, Time.deltaTime * 5);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);

    }
}
