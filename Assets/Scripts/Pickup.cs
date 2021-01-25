using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,80 * Time.deltaTime,0));
    }
    public void isKill()
    {
        GameManager.pickups.Remove(id);
        Destroy(gameObject);
    }
}
