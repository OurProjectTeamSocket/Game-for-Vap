using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{

    public Button play;

    void Update()
    {
        play.onClick.AddListener(onClick);
    }

    void onClick(){
        SceneManager.LoadScene(1);
    }

}

// Script created by Emil Panecki
