using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家状态信息
/// </summary>
public class PlayerStatusInfo : MonoBehaviour
{
    //静态 自身类型 (对外)只读属性
    public static PlayerStatusInfo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
     
    public float HP;
    public float maxHP;

    //玩家头部位置
    public Transform headTF;

    public void Damage(float amount)
    {
        HP -= amount;
    } 

}
