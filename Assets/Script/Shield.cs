using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip sound1;
    public AudioClip sound2;

    void Start()
    {
        Invoke("DestroyShield", 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyMissile")
        {

            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position);
            GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }

    void DestroyShield()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(sound2, Camera.main.transform.position);
    }
}
