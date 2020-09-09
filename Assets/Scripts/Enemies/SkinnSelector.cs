using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnSelector : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    void Start()
    {
        int x = Random.Range(0, 3);

        switch(x){

          case 0:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            break;

          case 1:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            break;

          case 2:
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            break;

        }

    }
}

// Script created by Emil Panecki
