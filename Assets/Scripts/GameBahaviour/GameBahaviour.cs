using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameBahaviour : MonoBehaviour
{
    [Range(1, 10)] public int Xpos = 0;
    [Range(1, 10)] public int Ypos = 7;

    public GameObject canvas;
    public GameObject enemyEasy;
    public GameObject enemyMedium;
    public GameObject enemyHard;
    public GameObject player;
    public GameObject black;
    public GameObject tip;

    public Button buttonMenu;
    public Button buttonRetry;

    public Text scoreText;

    private int _intEnemy = 3;
    private float _wavesTime = 0;
    private int _score = 0;
    private float _scoreTime = 0;

    void Start()
    {

        black.SetActive(false);

        Instantiate(player, new Vector3(0, -4, (float)-0.1), Quaternion.identity);

        if( GameObject.FindGameObjectsWithTag("Enemy").Length < _intEnemy ) {
            spawnEnemy();
        }
    }

    void Update()
    {
        _wavesTime += Time.deltaTime; //Time of wave

        if(_score % 2000 == 0){

          GameObject[] Enem = GameObject.FindGameObjectsWithTag("Enemy");

          foreach(GameObject gi in Enem)
            Destroy(gi);

          tip.SetActive(true);

          if(_scoreTime < 0){
              _score += 50;
              _scoreTime = 10;
          }

          _scoreTime -= Time.deltaTime;

        } else {

          tip.SetActive(false);

          if(( GameObject.FindGameObjectsWithTag("Enemy").Length < _intEnemy )&&( GameObject.FindGameObjectsWithTag("Player").Length == 1 ))
          {
              _score += 50;
              spawnEnemy();
          }

        }

        if( GameObject.FindGameObjectsWithTag("Player").Length == 0 ){

          scoreText.text = ("Score: " + _score).ToString();

          black.SetActive(true);
          canvas.SetActive(true);

          buttonMenu.onClick.AddListener(buttonOneFunction);
          buttonRetry.onClick.AddListener(buttonTwoFunction);
        }

        if((_wavesTime > 60)&&(GameObject.FindGameObjectsWithTag("Enemy").Length == 3)){
          _intEnemy = 6;
        }

        if((_wavesTime > 120)&&(GameObject.FindGameObjectsWithTag("Enemy").Length == 6)){
          _intEnemy = 9;
        }

        if((_wavesTime > 180)&&(GameObject.FindGameObjectsWithTag("Enemy").Length == 9)){
          _intEnemy = 12;
        }

        if((_wavesTime > 240)&&(GameObject.FindGameObjectsWithTag("Enemy").Length == 12)){
          _intEnemy = 15;
        }
    }

    void spawnEnemy(){

      int _randomEnemy = (Random.Range(0, 100));

      if(_randomEnemy <= 90){
        Instantiate(enemyEasy, new Vector3(Random.Range(-Xpos, Xpos), Ypos, 2), Quaternion.identity);
      }

      if(_randomEnemy <= 40){
        Instantiate(enemyMedium, new Vector3(Random.Range(-Xpos, Xpos), Ypos, 2), Quaternion.identity);
      }

      if(_randomEnemy <= 0){
        Instantiate(enemyHard, new Vector3(Random.Range(-Xpos, Xpos), Ypos, 2), Quaternion.identity);
      }

    }

    void buttonOneFunction(){
        SceneManager.LoadScene(0);
    }

    void buttonTwoFunction(){

        GameObject[] Enem = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject go in Enem)
          Destroy(go);

        GameObject[] Bull = GameObject.FindGameObjectsWithTag("Bullet");

        foreach(GameObject gi in Bull)
          Destroy(gi);

        black.SetActive(false);
        canvas.SetActive(false);

        if( GameObject.FindGameObjectsWithTag("Player").Length == 0){
            Instantiate(player, new Vector3(0, -4, (float)2), Quaternion.identity);
        }

        _score = 0;

    }

    /*int getScore(){
      return score;
    }*/

}

// Script created by Emil Panecki, Duc Anh ( Piekarski ) Nguyen, Kacper Socha, Arsen Slyvka
