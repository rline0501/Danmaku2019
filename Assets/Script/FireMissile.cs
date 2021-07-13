using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    
    //弾幕の速度
    public float missileSpeed;

    //弾幕の効果音
    public AudioClip fireSound;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Prefabからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

            Rigidbody missileRb = missile.GetComponent<Rigidbody>();

            missileRb.AddForce(transform.forward * missileSpeed);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);

            //発射したミサイルを２秒後に削除する
            Destroy(missile, 2.0f);
        }   
    }
}
