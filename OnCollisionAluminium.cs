using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAluminium : MonoBehaviour
{
    public GameObject MiniAluminium;
    public AudioSource Exp2AudioMiniAluminium;


      void Start()
    {
        MiniAluminium.SetActive(false);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BeakerExp2")
        {
            MiniAluminium.SetActive(true);
            Exp2AudioMiniAluminium.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
