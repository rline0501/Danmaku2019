using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiremissileB : MonoBehaviour
{
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount;

    void Update()
    {
        timeCount += 1;

        //”­ËŠ´Šo‚ğ’Z‚­‚·‚é
        if(timeCount % 5 == 0)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();
            missileRb.AddForce(transform.forward * speed);

            //‚P‚O•bŒã‚É“G‚Ìƒ~ƒTƒCƒ‹‚ğíœ‚·‚é
            Destroy(missile, 10f);
        }

        ///timeCount‚ª‚O‚İ‚É‚È‚Á‚½‚Æ‚«A‚±‚ÌƒIƒuƒWƒFƒNƒg‚ÉRotate‚ğ•t—^‚·‚é
        ///“¯‚Érotation Y‚É‚X‚O‚ğİ’è‚·‚é
        if(timeCount == 500)
        {
            this.gameObject.AddComponent<Rotate>().pos = new Vector3(0, 90, 0);
        }
        
    }
}
