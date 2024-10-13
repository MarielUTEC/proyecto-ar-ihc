using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpButtonScript : MonoBehaviour
{
    public Button helpButton;
    public GameObject helpScreenTemplate;
    void Start()
    {
        helpButton.onClick.AddListener(GenerateHelpScreen);
    }

    void GenerateHelpScreen()
    {
        helpScreenTemplate.SetActive(true);
    }
}
