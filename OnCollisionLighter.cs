using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnCollisionLighter : MonoBehaviour
{
    public GameObject PlateExp3;
    public GameObject FlameExp3;

    private void Start()
    {
        FlameExp3.SetActive(false);
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlateExp3")
        {
            FlameExp3.SetActive(true);
        }
    }
}
