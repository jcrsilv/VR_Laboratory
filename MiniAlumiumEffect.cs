using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAlumiumEffect : MonoBehaviour
{
    public GameObject MiniAluminium;
    public GameObject BeakerExp2;
    public GameObject Fire;
    public Renderer MiniAluminiumRenderer;
    public Material NewGlassMaterial;
    void Start()
    {
        MiniAluminiumRenderer = GetComponent<Renderer>();   
    }
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            StartCoroutine(StartTiming());
        }
    }

    IEnumerator StartTiming()
    {
        yield return new WaitForSeconds(12.0f);
        Fire.SetActive(false);
        MiniAluminiumRenderer.material.color = Color.black;
        BeakerExp2.GetComponent<MeshRenderer>().material = NewGlassMaterial;
    }
}
