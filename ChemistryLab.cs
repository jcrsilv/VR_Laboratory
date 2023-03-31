using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnitySimpleLiquid;
using UnityEngine.SceneManagement;

public class ChemistryLab : SceneData
{
    public Button btn;
    public GameObject TaskButton;
    public TextMeshProUGUI RobotInstructions;
    public GameObject Pointer;

    [Space]
    [Header("Experiment 1")]
    public GameObject Exp1;
    public bool experiment1;
    public GameObject MiniPotassium;

    [Space]
    [Header("Experiment 2")]
    public GameObject Exp2;
    public bool experiment2;
    public GameObject BeakerExp2;
    public MeshCollider BrownBottleMeshCollider;
    public MeshCollider BrownBottleFluidMeshCollider;
    public CapsuleCollider BrownBottleCapsuleCollider;
    public MeshCollider AluminiumMeshCollider;
    public CapsuleCollider AluminiumCapsuleCollider;
    public GameObject MiniAluminium;

    [Space]
    [Header("Experiment 3")]
    public GameObject Exp3;
    public bool experiment3;
    public GameObject PlateExp3;
    public MeshCollider NitromethaneMeshCollider;
    public MeshCollider NitromethaneFluidMeshCollider;
    public CapsuleCollider NitromethaneCapsuleCollider;
    public MeshCollider MethanolMeshCollider;
    public MeshCollider MethanolFluidMeshCollider;
    public CapsuleCollider MethanolCapsuleCollider;
    public MeshCollider LighterMeshCollider;
    public BoxCollider LighterBoxCollider;
    public GameObject FlameExp3;



    void Start()
    {
        experiment1 = false;
        experiment2 = false;
        experiment3 = false;
        Exp1.SetActive(false);
        Exp2.SetActive(false);
        Exp3.SetActive(false);
        AluminiumCapsuleCollider.enabled = false;
        AluminiumMeshCollider.enabled = false;

        btn.onClick.AddListener(ButtonOnClick);
    }

    void ButtonOnClick()
    {
        Pointer.SetActive(false);
        experiment1 = true;
       
    }

    private void Update()
    {
        if(experiment1 == true )
        {      
            StartCoroutine(StartExperiment1());
        }
        if(experiment2 == true )
        {
            StartCoroutine(StartExperiment2());  
        }
        if (experiment3 == true)
        {
            StartCoroutine(StartExperiment3());
        }
    }

    IEnumerator StartExperiment1()
    {
        Exp1.SetActive(true);
        TaskButton.SetActive(false);
        RobotInstructions.text = "Grab the potassium rock and place it in the water of the beaker";     
        
        if(MiniPotassium.activeSelf == true)
        {
            experiment1 = false;
            RobotInstructions.text = "Well done for completing experiment 1";
            yield return new WaitForSeconds(10.0f);
            StartCoroutine(StartExperiment2());
        }
       

    }

    IEnumerator StartExperiment2()
    {
        experiment2 = true;
        yield return new WaitForSeconds(3.0f);
        Exp1.SetActive(false);     
        Exp2.SetActive(true);
        

        if( BeakerExp2.GetComponent<LiquidContainer>().fillAmountPercent > 0.5f && MiniAluminium.activeSelf == false)
        {
            BrownBottleMeshCollider.enabled = false;
            BrownBottleFluidMeshCollider.enabled = false;
            BrownBottleCapsuleCollider.enabled = false;

            AluminiumCapsuleCollider.enabled = true;
            AluminiumMeshCollider.enabled = true;

            RobotInstructions.text = "Grab the alumium and place it into the beaker with bromine";
        }
        else if (BeakerExp2.GetComponent<LiquidContainer>().fillAmountPercent > 0.5f && MiniAluminium.activeSelf == true)
        {
            experiment2 = false;
            RobotInstructions.text = "Well done for completing experiment 2";
            yield return new WaitForSeconds(10.0f);
            StartCoroutine(StartExperiment3());
        }
        else
        {
            RobotInstructions.text = "Grab the brown bottle with bromine and pour it into the beaker";
        }
        
    }

    IEnumerator StartExperiment3()
    {
        experiment3 = true;
        yield return new WaitForSeconds(3.0f);
        Exp2.SetActive(false);
        Exp3.SetActive(true);

        RobotInstructions.text = "Grab the Nitromethane that is in the whte bottle and pour it into the plate.";

        if(PlateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.2f && FlameExp3.activeSelf == false)
        {
            NitromethaneMeshCollider.enabled = false;
            NitromethaneFluidMeshCollider.enabled = false;
            NitromethaneCapsuleCollider.enabled = false;

            MethanolCapsuleCollider.enabled = true;
            MethanolMeshCollider.enabled = true;
            MethanolFluidMeshCollider.enabled = true;

            RobotInstructions.text = "Grab the tube with Methanol  and pour it into the plate that has Nitromethane.";

        }
        if (PlateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.9f && FlameExp3.activeSelf == false)
        {
            NitromethaneMeshCollider.enabled = false;
            NitromethaneFluidMeshCollider.enabled = false;
            NitromethaneCapsuleCollider.enabled = false;

            MethanolCapsuleCollider.enabled = false;
            MethanolMeshCollider.enabled = false;
            MethanolFluidMeshCollider.enabled = false;

            LighterMeshCollider.enabled = true;
            LighterBoxCollider.enabled = true;

            RobotInstructions.text = "Grab the lighter and add the flame  into the plate that has Nitromethane and Methanol.";

        }
        else if (PlateExp3.GetComponent<LiquidContainer>().fillAmountPercent == 0.9f && FlameExp3.activeSelf == true)
        {
            experiment3 = false;
            RobotInstructions.text = "Well done for completing experiment 3";
            yield return new WaitForSeconds(5.0f);
            NextScene();
        }
    }

    
}
