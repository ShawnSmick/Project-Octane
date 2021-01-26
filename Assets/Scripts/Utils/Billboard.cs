using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

   // private RectTransform rectTransform;
    private void Start()
    {
        //rectTransform = gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
