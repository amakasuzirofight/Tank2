using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : GavityObject
{
    [SerializeField, Tooltip("浮く量")] private float floatingAmount = 1f;
    [SerializeField, Tooltip("移動速度")] private float speed = 10;

    [HideInInspector] public Vector3 direction = new Vector3(); // 移動方向
    public string shooterName;
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;   // 移動方向に対し移動速度で移動する
    }

    protected override void Gravity()
    {
        float distance = Vector3.Distance(transform.position,GavityController.GetPos);  // 自身との重力発生源との距離

        if (distance < GavityController.GetRad + floatingAmount) return;                // 距離が発生源の半径+浮く量を下回っているなら早期リターンする(ある程度浮きながら移動するため)

        Vector3 direction = GavityController.GetPos - transform.position;               // 重力発生源からの自身の方向を得る
        direction.Normalize();                                                          // 方向を正規化する

        rb.AddForce(gavityPower * direction, ForceMode.Acceleration);                   // 得た方向に対して重力値分力をかける
    }
}
