using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float _backgroundPosition;
    [Range(1, 500)] public int speed;

    void Update() //Moving background
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= _backgroundPosition)
        {
            transform.position = new Vector3(0, 17, (float) 0.1);
        }
    }
}
