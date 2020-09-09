using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Range(1, 20)] public int SpeedOfBullet = 3;
    private Animator _anim;
    public double time = 5;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

      time -= (double)Time.deltaTime;

      if(time < 0){
        Destroy(gameObject);
      }

        transform.Translate(Vector3.up * SpeedOfBullet * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll){

      if(coll.gameObject.tag == "Enemy")
      {
        _anim.SetBool("Destructions", true);
        if((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlast"))||((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlastRed")))) {
          Destroy(gameObject);
        }
      } else if(coll.gameObject.tag == "Player")
      {
        _anim.SetBool("Destructions", true);
        if((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlast"))||((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlastRed")))) {
          Destroy(gameObject);
        }
      } else if(coll.gameObject.tag == "Bullet")
      {
        _anim.SetBool("Destructions", true);
        if((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlast"))||((_anim.GetCurrentAnimatorStateInfo(0).IsName("NewBlastRed")))) {
          Destroy(gameObject);
        }
      }

    }

}
