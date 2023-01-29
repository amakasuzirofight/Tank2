using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    [SerializeField] Image[] bulletImages = new Image[10];
    [SerializeField] int firstBulletCount;
    [SerializeField] Sprite nonImage;
    [SerializeField] Sprite energyImage;
    [SerializeField] float energyChargeTime;
    float chargeTimeCount;
    int bulletCount;
    int BulletCount
    {
        get => bulletCount;
        set
        {
            //�e�̏����10��
            int changedValue = Mathf.Clamp(value, 0, 10);
            ChangeBulletCount(changedValue);
            bulletCount = changedValue;
        }
    }
    private void Start()
    {
        BulletCount = firstBulletCount;
    }
    private void Update()
    {
      �@
    }
    private void ChargeEnergy()
    {

    }
    public void AddBullets(int num)
    {
        BulletCount += num;
    }
    public int GetBulletsCount() => BulletCount;

    private void ChangeBulletCount(int num)
    {
        for (int i = 0; i < bulletImages.Length; i++)
        {
            bulletImages[i].sprite = num > i ? energyImage : nonImage;
        }
    }
}
//private void ChangeBulletCount(int beforeCount, int afterCount)
//{
//    int countDifference = afterCount - beforeCount;
//    Debug.Log($"diff={countDifference}");
//    Debug.Log($"before={beforeCount} after={afterCount}");
//    //UI�ɔ��f�@���ꂾ������MVP�ł��΂悩����
//    for (int i = 0; i < Mathf.Abs(countDifference); i++)
//    {
//        Debug.LogError($"num={beforeCount + i }");
//        bulletImages[beforeCount + i].sprite = countDifference > 0 ? energyImage : nonImage;
//    }
//}