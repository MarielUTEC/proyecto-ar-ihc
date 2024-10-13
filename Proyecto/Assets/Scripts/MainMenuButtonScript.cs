using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour
{

    public Button menuObjectButton;

    // Start is called before the first frame update
    void Start()
    {
        menuObjectButton.onClick.AddListener(changeScene);
    }

    void changeScene()
    {
        SceneManager.LoadScene(1);
    }
}
