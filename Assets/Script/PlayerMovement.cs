using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //�ړ����x
    public float moveSpeed = 0.2f;

    private Vector3 pos;

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal") * moveSpeed;

        float moveV = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(moveH, 0, moveV);

        MoveClamp();

    }

/// <summary>
/// �ړ��͈�
/// </summary>
    void MoveClamp()
    {
        pos = transform.position;

        //���ꂼ����W����͂����ŏ��l�ƍő�l�̊Ԃɐ�������
        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -10, 10);

        transform.position = pos;
    }
}
