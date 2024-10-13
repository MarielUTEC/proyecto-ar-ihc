using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreenQuit : MonoBehaviour
{
    public Button helpQuitButton;
    public GameObject helpScreen;
    void Start()
    {
        helpQuitButton.onClick.AddListener(DisableHelpScreen);
    }

    void DisableHelpScreen()
    {
        helpScreen.SetActive(false);
    }
}
