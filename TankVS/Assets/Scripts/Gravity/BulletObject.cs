using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : GavityObject
{
    [SerializeField, Tooltip("������")] private float floatingAmount = 1f;
    [SerializeField, Tooltip("�ړ����x")] private float speed = 10;

    [HideInInspector] public Vector3 direction = new Vector3(); // �ړ�����
    public string shooterName;
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;   // �ړ������ɑ΂��ړ����x�ňړ�����
    }

    protected override void Gravity()
    {
        float distance = Vector3.Distance(transform.position,GavityController.GetPos);  // ���g�Ƃ̏d�͔������Ƃ̋���

        if (distance < GavityController.GetRad + floatingAmount) return;                // �������������̔��a+�����ʂ�������Ă���Ȃ瑁�����^�[������(������x�����Ȃ���ړ����邽��)

        Vector3 direction = GavityController.GetPos - transform.position;               // �d�͔���������̎��g�̕����𓾂�
        direction.Normalize();                                                          // �����𐳋K������

        rb.AddForce(gavityPower * direction, ForceMode.Acceleration);                   // ���������ɑ΂��ďd�͒l���͂�������
    }
}
