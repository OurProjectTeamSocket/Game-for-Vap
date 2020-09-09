using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTeasy : MonoBehaviour
{
    [Range(1, 10)] public int _speed = 5;
    [SerializeField] private GameObject _blows;

    void Update()
    {

        if(transform.position.y <= -9){
          Destroy(gameObject);
        }

        transform.position += Vector3.down * _speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(_blows, new Vector3(transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(_blows, new Vector3(transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
        }
    }
}

// Script created by Duc Anh ( Piekarski ) Nguyen
