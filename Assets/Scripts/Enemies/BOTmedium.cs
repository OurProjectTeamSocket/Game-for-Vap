using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BOTmedium : MonoBehaviour
{
    [Range(1, 10)] public float _speed;
    public float lenght;
    private bool _sides = true;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _blows;

    private double _randomTime = (double)Random.Range(1, 3);

    void Update()
    {

        _randomTime -= (double)Time.deltaTime;

        if(transform.position.y <= -9){
          Destroy(gameObject);
        }

        transform.position += Vector3.down * _speed * Time.deltaTime;

        if(transform.position.y <= 3)
        {
            transform.position = new Vector3(transform.position.x, (float) 3, (float) -0.1);
            if(_sides)
            {
                transform.position += Vector3.right * _speed * Time.deltaTime;
                if(transform.position.x >= lenght)
                {
                    _sides = false;
                }
            }

            if (!_sides)
            {
                transform.position += Vector3.left * _speed * Time.deltaTime;
                if (transform.position.x <= -lenght)
                {
                    _sides = true;
                }
            }

            if(_randomTime < 0){

              Instantiate(_bullet, new Vector3(transform.position.x, transform.position.y - (float)2, -0.1f), Quaternion.Euler(180, 0, 0));

              _randomTime = (double)Random.Range(1, 3);

            }

        }

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

// Script created by Kacper Socha
