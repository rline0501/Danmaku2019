using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //移動速度
    public float moveSpeed = 0.2f;

    private Vector3 pos;

    void Update()
    {
        //float moveH = Input.GetAxis("Horizontal") * moveSpeed;

        //float moveV = Input.GetAxis("Vertical") * moveSpeed;

        float MoveH = Input.GetAxis("Mouse X") * moveSpeed;

        float MoveV = Input.GetAxis("Mouse Y") * moveSpeed;

        transform.Translate(MoveH, 0, MoveV);

        MoveClamp();

    }

/// <summary>
/// 移動範囲
/// </summary>
    void MoveClamp()
    {
        pos = transform.position;

        //ぞれぞれ座標を入力した最小値と最大値の間に制限する
        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -5, 5);

        transform.position = pos;
    }
}
