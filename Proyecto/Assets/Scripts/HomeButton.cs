using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    public Button homeButton;
    void Start()
    {
        homeButton.onClick.AddListener(changeToStart);
    }

    void changeToStart()
    {
        SceneManager.LoadScene(0);
    }
}
