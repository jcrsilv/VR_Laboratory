using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class OnCollisionMethanol : MonoBehaviour
{
    public GameObject PlateExp3;

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlateExp3")
        {
            PlateExp3.GetComponent<LiquidContainer>().fillAmountPercent = 0.9f;
        }
    }
}
