using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadarTracked : MonoBehaviour
{
    public Image Blip;
    RadarObject Self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Self==null)
        {
            Self = Radar.RegisterRadarObject(this.gameObject,Blip);
        }
    }

}
