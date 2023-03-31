using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questionaire : MonoBehaviour
{
    [SerializeField]Button BtSubmit = null;

    string q1 = "";
    string q2 = "";
    string q3 = "";
    string q4 = "";
    string q5 = "";

    public string Q1 { set { q1 = value; Validate(); } }
    public string Q2 { set { q2 = value; Validate(); } }
    public string Q3 { set { q3 = value; Validate(); } }
    public string Q4 { set { q4 = value; Validate(); } }
    public string Q5 { set { q5 = value; Validate(); } }

    private void Validate()
    {
      BtSubmit.interactable = q1 != "" && q2 != "" && q3 != "" && q4 != "" && q5 != "";

     }

    private void Start()
    {
        BtSubmit.interactable = false;
    }

}
