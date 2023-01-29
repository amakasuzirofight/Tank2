using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : GavityObject
{
    [SerializeField, Tooltip("�C���X�^���X����e")] private BulletObject bullet;

    [SerializeField, Tooltip("�ړ����x")] private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        bool input = false; // �������͖h�~�p�ϐ�

        if (Input.GetKeyDown(KeyCode.Return))           // Enter�L�[����
        {
            // �e���C���X�^���X����
            BulletObject instance = Instantiate(bullet, transform.position + transform.forward + Vector3.up, Quaternion.identity);
            instance.direction = transform.forward;                             // �C���X�^���X�����e�̕��������g�Ɠ������̂ɂ���
            input = true;                                                       // ���͍ς݂ɕύX
        }

        if (Input.GetKey(KeyCode.UpArrow) && !input)    // �����
        {
            transform.position += transform.forward * speed * Time.deltaTime;   // �����ɑ��x���������ʈړ�����
            input = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !input)  // ������
        {
            transform.position -= transform.forward * speed * Time.deltaTime;   // �t�����ɑ��x���������ʈړ�����
            input = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !input)  // ������
        {
            transform.Rotate(0, -1f, 0);                                        // y���ɋt��]
            input = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !input) // �E����
        {
            this.transform.Rotate(0, 1f, 0);                                    // y���ɉ�]
        }
    }
}
