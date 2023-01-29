using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : GavityObject
{
    [SerializeField, Tooltip("浮く量")] private float floatingAmount = 1f;
    [SerializeField, Tooltip("移動速度")] private float speed = 10;

    [HideInInspector] public Vector3 direction = new Vector3(); // 移動方向

    private Vector3 oldVec = new Vector3();

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;   // 移動方向に対し移動速度で移動する
    }

    protected override void Gavity()
    {
        float distance = Vector3.Distance(transform.position,GavityController.GetPos);  // 自身との重力発生源との距離

        if (distance < GavityController.GetRad + floatingAmount) return;                // 距離が発生源の半径+浮く量を下回っているなら早期リターンする(ある程度浮きながら移動するため)

        Vector3 direction = GavityController.GetPos - transform.position;               // 
        direction.Normalize();

        rb.AddForce(gavityPower * direction, ForceMode.Acceleration);
    }
}
