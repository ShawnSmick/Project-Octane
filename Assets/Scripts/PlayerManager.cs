using System.Collections;
using System.Collections.Generic;
using UnityEngine;
struct StateSnapshot
{
    Vector3 Position;
    Vector3 Velocity;
    Quaternion Rotation;

}
public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float correctSpeed = 2f;
    public GameObject explosion;
    public int[] Ammo;
    public Vector3 positionActual;
    public TMPro.TextMeshPro nameText;
    public float Turbo = 5f;
    public int Energy = 100,Health = 100;
    public GameObject Frozen;
    public ParticleSystem Burning;
    public Radar radar;
    public void Start()
    {
        Ammo = new int[GameManager.instance.Missiles.Length];
    }
    public void Update()
    {
        //transform.position=Vector3.MoveTowards(transform.position,positionActual,correctSpeed* Time.deltaTime);
    }
    public void IsKill()
    {
       // StableCam _cam = GetComponentInChildren<StableCam>();
       // _cam.transform.parent = null;
        if (explosion != null)
        {
            GameObject exp = Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(exp,5);
        }
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
    public void SetName(string _name)
    {
        username = _name;
        if (id != Client.instance.myID)
            nameText.text = username;

    }
}
