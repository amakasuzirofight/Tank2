using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavityController : MonoBehaviour
{
    [SerializeField, Tooltip("重力発生源")] private GameObject gavityCenter;

    private static GameObject gavityCenter_static;  // 重力発生源を静的領域に保存する変数

    // Start is called before the first frame update
    void Start()
    {
        gavityCenter_static = gavityCenter; // 重力発生源設定
    }

    public static Vector3 GetPos
    {
        get => gavityCenter_static.transform.position;
    }

    public static float GetRad
    {
        get => gavityCenter_static.transform.localScale.x * 0.5f;
    }
}
