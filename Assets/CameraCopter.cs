using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCopter : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControls controls;
    public float inputX;
    private void Awake()
    {

        controls = new PlayerControls();
        
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    // Update is called once per frame
    void Update()
    {




        transform.position += transform.forward * 30 * Time.deltaTime*controls.Gameplay.Accelerate.ReadValue<Vector2>().y;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y + 90f * Time.deltaTime* controls.Gameplay.Turn.ReadValue<Vector2>().x,0);

            transform.position += transform.up * 15 * Time.deltaTime*controls.Gameplay.Turn.ReadValue<Vector2>().y;

    }
}
