using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadarObject
{
    public Image icon
    {
        get; set;
    }
    public GameObject owner
    {
        get; set;
    }
}

public class Radar : MonoBehaviour
{
    public Transform playerPos;
    public float mapScale = 1f;
    public float MaxDist = 100f;
    public static List<RadarObject> radObjects = new List<RadarObject>();

    public static RadarObject RegisterRadarObject(GameObject o,Image i)
    {
        Image image = Instantiate(i);
        RadarObject radar = new RadarObject() { owner = o,icon = image };
        radObjects.Add(radar);
        radar.icon.color = new Color(Random.value,Random.value,Random.value);
        return radar;
    }

    void DrawRadarDots()
    {
        if (playerPos != null)
        {
            List<RadarObject> radRemove = new List<RadarObject>();
            foreach (RadarObject ro in radObjects)
            {
                if (ro.owner != null)
                {

                    Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
                    float distToObject = Vector3.Distance(playerPos.position,ro.owner.transform.position) * mapScale;
                    if (distToObject > MaxDist)
                    {
                        distToObject = MaxDist;
                    }
                    float deltay = Mathf.Atan2(radarPos.x,radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
                    radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
                    radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

                    ro.icon.transform.SetParent(this.transform);
                    ro.icon.transform.localPosition = new Vector3(radarPos.x,radarPos.z,0);
                }
                else
                {
                    radRemove.Add(ro);
                }
            }
            foreach (RadarObject ro in radRemove)
            {
                Destroy(ro.icon);
                radObjects.Remove(ro);
            }
        }
    }

    void Update()
    {
        DrawRadarDots();
    }
}
