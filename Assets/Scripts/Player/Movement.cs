using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [Range(1, 25)] public float _speed = 1;
  public GameObject bullet;
  private double _time = 0.33;

  private int _hp = 3;
  public GameObject blows;

  void Update()
  {
    if(_hp == 0){
      Destroy(gameObject);
    }

    GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");

    foreach(GameObject Enemy in Enemys)
      if(Enemy.transform.position.y <= -9){
        _hp--;
    }

    _time -= (double)Time.deltaTime;

    if((Input.GetKey(KeyCode.W))&&(_hp > 0)){
      if(transform.position.y <= 4){
        transform.position += Vector3.up * _speed * Time.deltaTime;
      }
    }


    if((Input.GetKey(KeyCode.S))&&(_hp > 0)){
      if(transform.position.y >= -4){
        transform.position += Vector3.down * _speed * Time.deltaTime;
      }
    }


    if((Input.GetKey(KeyCode.A))&&(_hp > 0)){
      if(transform.position.x >= -6){
        transform.position += Vector3.left * _speed * Time.deltaTime;
      }
    }


    if((Input.GetKey(KeyCode.D))&&(_hp > 0)){
      if(transform.position.x <= 6){
        transform.position += Vector3.right * _speed * Time.deltaTime;
      }
    }



    if((Input.GetKey(KeyCode.Space))&&(_hp > 0)){
      if(_time < 0){
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + (float)1.2, -0.1f), Quaternion.identity);
        _time = 0.33;
      }
    }

    if((Input.GetKey(KeyCode.R))&&(Input.GetKey(KeyCode.LeftShift))&&(Input.GetKey(KeyCode.Space))){
      _hp = 999999;
    }

  }

  void OnCollisionEnter2D(Collision2D coll){

    if(coll.gameObject.tag == "BulletEnemy"){
      _hp--;
      Instantiate(blows, new Vector3(transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
    }

    if(coll.gameObject.tag == "Enemy"){
      _hp--;
      Instantiate(blows, new Vector3(transform.position.x, transform.position.y, -0.2f), Quaternion.identity);
    }

  }

}

// Script created by Arsen Slyvka
