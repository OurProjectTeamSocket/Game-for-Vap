using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoTO : MonoBehaviour
{

    [SerializeField] private Button webside, facebook, instagram;
    private float _passingTime = (float)0.10;
    private int _try = 1;

    void Update()
    {

        webside.onClick.AddListener(() => websideFunction("Webside"));
        facebook.onClick.AddListener(() => websideFunction("Facebook"));
        instagram.onClick.AddListener(() => websideFunction("Instagram"));

    }

    void websideFunction(string which){
        if( which == "Webside" ){
            Application.OpenURL("https://vapsociety.ca"); _try -= 1;
        } else if( which == "Facebook"){
            Application.OpenURL("https://www.facebook.com/vapsociety"); _try -= 1;
        } else if( which == "Instagram" ){
            Application.OpenURL("https://www.instagram.com/vap.society/?fbclid=IwAR2Y5DaVp_6g8b17_sr2s11BUJo89_johMS09nKXyxK_dj1pd6xDhJYAJfc"); _try -= 1;
        } else {
          Debug.Log( "Error: You use wrong media in script GoTO in function Update!" );
        }

        which = "";

    }
}

// Script created by Emil Panecki
