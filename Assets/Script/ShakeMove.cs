using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMove : MonoBehaviour
{
    
    private void Update()
    {
        //三角関数の活用（Sin関数）
        transform.Translate(5.0f * Time.deltaTime * Mathf.Sin(Time.time * 2), -Time.deltaTime * Mathf.Sin(Time.time), 0);
    }
}
