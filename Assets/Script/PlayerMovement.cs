using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //�ړ����x
    public float moveSpeed = 0.2f;

    private Vector3 pos;

    public bool isMouseMove;

    void Update()
    {
        float moveH = 0;

        float moveV = 0;

        if(isMouseMove == true)
        {
            moveH = Input.GetAxis("Mouse X") * moveSpeed;

            moveV = Input.GetAxis("Mouse Y") * moveSpeed;
        }
        else
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;

            moveV = Input.GetAxis("Vertical") * moveSpeed;
        }

        transform.Translate(moveH, 0, moveV);

        MoveClamp();

        if(isMouseMove == true)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                isMouseMove = false;
                Debug.Log(isMouseMove);
            
            }
        }


    }

/// <summary>
/// �ړ��͈�
/// </summary>
    void MoveClamp()
    {
        pos = transform.position;

        //���ꂼ����W����͂����ŏ��l�ƍő�l�̊Ԃɐ�������
        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -5, 5);

        transform.position = pos;
    }
}
