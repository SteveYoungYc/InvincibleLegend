﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 敌人状态信息类
/// </summary>
public class EnemyStatusInfo : MonoBehaviour
{
    /// <summary>
    /// 当前血量
    /// </summary>
    public float currentHP;
    /// <summary>
    /// 最大血量
    /// </summary>
    public float maxHP;

    public void Damage(float amount)
    {
        //如果敌人已经死亡 则退出(防止虐尸)
        if (currentHP <= 0) return;

        currentHP -= amount;

        if (currentHP <= 0)
            Death();
    }

    /// <summary>
    /// 死亡延迟时间
    /// </summary>
    public float deathDelay =10;

    //敌人生成器引用  敌人创建时由生成器传递
    public EnemySpawn spawn;
    /// <summary>
    /// 死亡
    /// </summary>
    public void Death()
    {
        //销毁当前游戏物体
        Destroy(gameObject, deathDelay);

        //播放动画
        var anim = GetComponent<EnemyAnimation>();
        anim.Play(anim.deathName);

        //修改状态
        GetComponent<EnemyAI>().state = EnemyAI.State.Death;

        //修改路线状态
        GetComponent<EnemyMotor>().wayline.IsUsable = true;

        //需要再生成一个敌人
        spawn.GenerateEnemy(); 
    }
}
