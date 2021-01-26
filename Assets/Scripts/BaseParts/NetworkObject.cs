using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObject : MonoBehaviour
{
    private int id;
    public int GetID()
    {
        return this.id;
    }
    public void SetID(int id)
    {
        this.id = id;
    }
    public virtual void NetworkFixedUpdate()
    {
        //Likely put the timewarp code here?
    }
    public void UpdatePosition(Vector3 _pos,Quaternion _rot)
    {
        transform.position = _pos;
        transform.rotation = _rot;
    }
    public virtual void isKill()
    {
        GameManager.NetworkedObjects.Remove(GetID());
        Destroy(gameObject);
    }
}
