using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityObject : MonoBehaviour
{
    [SerializeField, Tooltip("重力値")] protected float gavityPower = 2f;

    protected Rigidbody rb; // コンポーネント取得用変数

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // コンポーネント取得
    }

    void FixedUpdate()
    {
        Gavity();   // 重力発生関数
    }

    protected virtual void Gavity()
    {
        Vector3 direction = GavityController.GetPos - transform.position;   // 重力発生源からの自身の方向を得る
        direction.Normalize();                                              // 方向を正規化する

        rb.AddForce(gavityPower * direction, ForceMode.Acceleration);       // 得た方向に対して重力値分力をかける
    }
}
