using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTstrong : MonoBehaviour
{
    private GameObject _player;
    private int _hp = 6;
    private GameObject _blows;

    void Update()
    {
        if (transform.position.y <= -9)
        {
            Destroy(gameObject);
        }

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(_player.transform.position.x, transform.position.y, (float)-0.1);
        transform.position += Vector3.down * (Random.Range(1, 3)) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp--;
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
