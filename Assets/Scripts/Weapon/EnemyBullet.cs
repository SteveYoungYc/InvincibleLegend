using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人子弹
/// </summary>
public class EnemyBullet : Bullet
{
    //通过碰撞检测攻击玩家(调用玩家受伤方法  atk) 
    //PlayerStatusInfo.Instance.Damage(atk);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStatusInfo.Instance.Damage(atk);
            Destroy(gameObject);
        }
    }
}
