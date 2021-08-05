using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;

    private void Start()
    {
        StartCoroutine(GeneEnemy());
    }

    IEnumerator GeneEnemy()
    {
        //‰½‰ñŒJ‚è•Ô‚·‚©İ’è
        for(int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                enemyRb.AddForce(transform.forward * speed);
                Destroy(enemy, 10f);

                //0.2•b‚²‚Æ‚É“®ì‚ğŒJ‚è•Ô‚·
                yield return new WaitForSeconds(0.2f);

            }

            //3•b‚²‚Æ‚É“®ì‚ğŒJ‚è•Ô‚·
            yield return new WaitForSeconds(3f);
        }
    }

}
