using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMove : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Warp());
        
    }


    private IEnumerator Warp()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);

            //�����_���Ɉړ�������͈͎͂��R�ɕύX�\
            float posX = Random.Range(-5f, 5f);
            float posZ = Random.Range(-1f, 1f);

            transform.position = new Vector3(posX, 0, posZ);
        }
    }
}
