using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowScript : MonoBehaviour
{
    private double _time = 0.60;

    void Update() //This function counts time to destroy bullet
    {
        _time -= Time.deltaTime;

        if(_time <= 0){
          Destroy(gameObject);
        }
    }
}
