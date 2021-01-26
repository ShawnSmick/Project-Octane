using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBase : NetworkObject
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 5f;
    //public int id;
    private GameObject _parent;
    
    //public Target target;
    public bool Targeting = false;
    private ParticleSystem emit;
    public GameObject explosion;
    public float aliveTime = 0;
    public bool synced = true;

    void Start()
    {
        emit = GetComponentInChildren<ParticleSystem>();
        // GetComponent<Rigidbody>().detectCollisions = false;
    }


    void FixedUpdate()
    {
        aliveTime += Time.deltaTime;
        if(!synced)
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    //https://www.youtube.com/watch?v=lLl0DVzRksk This is cursed please never again.
    public void SetParent(GameObject parentalfigure) // Please Die Immediately
    {
        _parent = parentalfigure;
    }
    public GameObject GetParent()
    {
        return _parent;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        //Make sure you are not hitting daddy, he doesnt like that. Also make sure you are not colliding with fellow projectiles
        Debug.Log("HIT");
       // if(other.gameObject.GetComponent<Player())
        if (other.gameObject != _parent && other.gameObject.tag != "Projectiles")
        {
            Rigidbody CollidedRB = other.gameObject.GetComponent<Rigidbody>();
           // isKill();
        }
    }*/
    public override void isKill()
    {
        if (emit != null)
        {
            DetachParticle();
        }
         if (explosion != null)
         {
             GameObject exp = Instantiate(explosion,transform.position,Quaternion.identity);
             Destroy(exp,5);
         }
        base.isKill();
    }
    public void updatePosition(Vector3 _pos,Quaternion _rot)
    {
        transform.position = _pos;
        transform.rotation = _rot;
    }
    private void DetachParticle()
    {
        emit.transform.parent = null;
        emit.Stop();
        Destroy(emit.gameObject,5);
    }
}
