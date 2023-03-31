using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryLabPT : MonoBehaviour
{
    public Button btn;
    public GameObject PTButton;
    public GameObject Beaker;
    public GameObject BrownBotle;
    public TextMeshProUGUI robotInstructions;
    public TextMeshProUGUI PTInstructions;

    void Start()
    {
        Beaker.SetActive(false);
        BrownBotle.SetActive(false);
        btn.onClick.AddListener(PTButtonOnClick);
     
    }

    void PTButtonOnClick()
    {
        PTButton.SetActive(false);
        Beaker.SetActive(true);
        BrownBotle.SetActive(true);       
        robotInstructions.text = "Grab the brown bottle with bromine with the controller and pour the bromine into the beaker.";

        StartCoroutine(StartTimer());
    
    }
     IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(10.0f);
        Beaker.SetActive(false);
        BrownBotle.SetActive(false);
        PTInstructions.text = "Practice completed, you will now complete a calibration process before conducting the study";
        robotInstructions.text = "Well done for completing this practice trial";


    }


    void Update()
    {
        
    }
}
