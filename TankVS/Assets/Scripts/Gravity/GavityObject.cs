using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityObject : MonoBehaviour
{
    [SerializeField, Tooltip("�d�͒l")] protected float gavityPower = 2f;

    protected Rigidbody rb; // �R���|�[�l���g�擾�p�ϐ�

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // �R���|�[�l���g�擾
    }

    void FixedUpdate()
    {
        Gavity();   // �d�͔����֐�
    }

    protected virtual void Gavity()
    {
        Vector3 direction = GavityController.GetPos - transform.position;   // �d�͔���������̎��g�̕����𓾂�
        direction.Normalize();                                              // �����𐳋K������

        rb.AddForce(gavityPower * direction, ForceMode.Acceleration);       // ���������ɑ΂��ďd�͒l���͂�������
    }
}
