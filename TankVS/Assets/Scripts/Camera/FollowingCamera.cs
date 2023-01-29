using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class FollowingCamera : MonoBehaviour
{
    [SerializeField] GameObject followObj;
    private Vector3 offset;

    private void Start()
    {
        offset = (transform.position - followObj.transform.position);
        offset = new Vector3(-0.13f, 3.75f, -6.60f);
    }
    private void Update()
    {
        //対象のオブジェクトの回転をカメラに与える
        Quaternion q = followObj.gameObject.transform.rotation;
        gameObject.transform.rotation = q;

        //行列を使って対象から一定の位置にカメラを移動させる
        Matrix4x4 addPos = Matrix4x4.identity;
        addPos.SetTRS(offset, transform.rotation, transform.localScale);
        Matrix4x4 mat = Matrix4x4.identity;
        mat.SetTRS(followObj.transform.position, followObj.gameObject.transform.rotation, transform.localScale);
        mat *= addPos;
        transform.position = new Vector3(mat.m03, mat.m13, mat.m23);
    }
    /// <summary>
    /// カメラを揺らす
    /// </summary>
    /// <param name="duration">揺れる時間</param>
    /// <param name="magnitude">強度</param>
    public void ShakeCamera(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }
    private IEnumerator DoShake(float duration, float magnitude)
    {
        var pos = transform.localPosition;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            var x = pos.x + UnityEngine.Random.Range(-1f, 1f) * magnitude;
            var y = pos.y + UnityEngine.Random.Range(-1f, 1f) * magnitude;
            var z = pos.z + UnityEngine.Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = pos;
    }
}
//if (RotateChase)
//{
//}
//else
//{
//    Vector3 vector3 = followObj.transform.position - this.transform.position;
//    Quaternion quaternion = Quaternion.LookRotation(vector3);
//    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, 1);
//}
//Vector3 vec = new Vector3(offset.x * player.transform.forward.x,
//    offset.y * player.transform.forward.y,
//    offset.z * player.transform.forward.z);
//vec += player.transform.position;
//Debug.Log($"pos={player.transform.position}+ forword{player.transform.forward}* offset{offset}={vec}");
//transform.position = vec;
//クォータニオン取得
//transform.position = player.transform.position + (offset*transform.forward);
//offset = player.transform.position + player.transform.forward.normalized;
//transform.position = player.transform.position - offset;

