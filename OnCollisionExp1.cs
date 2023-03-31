using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExp1 : MonoBehaviour
{
    public GameObject MiniPotassium;
    public AudioSource Exp1AudioMiniPotassium;    


    private void Start()
    {
       MiniPotassium.SetActive(false); 
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "LiquidOfBEakerExp1")
        {
            MiniPotassium.SetActive(true);
            Exp1AudioMiniPotassium.enabled = true;  
            Destroy(this.gameObject);   
        }
    }
}
