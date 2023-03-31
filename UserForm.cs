using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.IO;
using System.Text;
using UnityEngine.SocialPlatforms;

public class UserForm : MonoBehaviour
{
    [SerializeField] InputField Username = null;
    [SerializeField] InputField Age = null;
    [SerializeField] TMP_Dropdown Gender = null;
    [SerializeField] TMP_Dropdown HE = null;
    [SerializeField] TMP_Dropdown Group = null;
    [SerializeField] TMP_Dropdown Vision = null;
    [SerializeField] TMP_Dropdown Hearing = null;

    [SerializeField] Button btn = null;
    // Start is called before the first frame update
    void Start()
    {
        btn.interactable = false;
        Username.onValueChanged.AddListener(delegate { Validate(); });
        Age.onValueChanged.AddListener(delegate { Validate(); });
        btn.onClick.AddListener(delegate { SaveUserDemographics();  });
        btn.onClick.AddListener(delegate { CreateUserFolder(); });
    }
    private void Validate()
    {
        btn.interactable = Username.text != "" && Age.text != "";

    }

    public void SaveUserDemographics()
    {
        string path = $"{Application.dataPath}/Static/Data" + "UsersDemographics.csv";
        if(!File.Exists(path))
        {
            string header = "Username, Age, Gender, HighestEducation, Group, Vision, Hearing" + Environment.NewLine;

            File.AppendAllText(path, header);
        }

        string values = $"{Username.text}, {Age.text}, {Gender.options[Gender.value].text}, {HE.options[HE.value].text}, {Group.options[Group.value].text}, {Vision.options[Vision.value].text}, {Hearing.options[Hearing.value].text}" + Environment.NewLine;
        File.AppendAllText(path, values);
        SceneData.NextScene();
    }

    public void CreateUserFolder()
    {
        string pathDataFolder = "";
        string date = System.DateTime.Now.ToString("yyyy_MM_dd");

        if (Group.options[Group.value].text == "Control")
        {
            pathDataFolder = $"{Application.dataPath}/Static/Data/Controls/{Username.text + "_" + date}";
        }
        else if(Group.options[Group.value].text == "ADHD Traits")
        {
            pathDataFolder = $"{Application.dataPath}/Static/Data/PwADHD/{Username.text + "_" + date}";
        }
        if(!Directory.Exists(pathDataFolder))
        {
            Directory.CreateDirectory(pathDataFolder);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
