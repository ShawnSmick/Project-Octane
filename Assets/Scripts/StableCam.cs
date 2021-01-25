using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableCam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerCar;
    public float yRotation;
    // Update is called once per frame
    void Awake()
    {
        yRotation = playerCar.transform.eulerAngles.y;
    }
    void LateUpdate()
    {
        yRotation = Quaternion.Lerp(Quaternion.Euler(0,yRotation,0),Quaternion.Euler(0,playerCar.transform.eulerAngles.y,0),6*Time.deltaTime).eulerAngles.y;
        transform.eulerAngles = new Vector3(0,yRotation,0);
    }
}
