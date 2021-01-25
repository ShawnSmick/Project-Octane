using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCam : MonoBehaviour
{
    // Obtain GameObjects for Transform and Translate Vales
    public GameObject playerCar;
    public GameObject playerCamera;

    // Variable to Isolate X Axis Rotation of Car
    public float carRotationX;
    [SerializeField]
    private float cameraUpThresh = 10f;
    [SerializeField]
    private float cameraDownThresh = 10f;
    void Update()
    {
        // Get the X Axis Rotation
        carRotationX = playerCar.transform.eulerAngles.x;
        //print(carRotationX); //Debug check for X rotation
        // If carRotationX is greater than the CameraUpThreshold, the camera will shift to help see down hills.        
        if (carRotationX >= cameraUpThresh && carRotationX < 180)
        {
            playerCamera.transform.localPosition = new Vector3(0,1.7f,-3f);
            playerCamera.transform.localEulerAngles = new Vector3(16f,0,0);
        }
        // Else, if carRotationX is less than the CameraDownThreshold, camera will shift to help see up hills.
        // Negative carRotationx values wrap around to 360
        else if (carRotationX <= 360 - cameraDownThresh && carRotationX >= 180)
        {
            playerCamera.transform.localPosition = new Vector3(0,2f,-2.5f);
            playerCamera.transform.localEulerAngles = new Vector3(30,0,0);
        }
        //if its neither of those things the default camera is used
        else //if (carRotationX > -1 || carRotationX < 1f)
        {
           // playerCamera.transform.localPosition = new Vector3(0,1.5f,-2.75f);
           // playerCamera.transform.localEulerAngles = new Vector3(15,0,0);
        }
        
    }
}
