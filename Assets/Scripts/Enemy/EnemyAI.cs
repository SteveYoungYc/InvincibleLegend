using UnityEngine;
using System.Collections;

/// <summary>
/// 人工智能
/// </summary>
[RequireComponent(typeof(EnemyAnimation),typeof(EnemyMotor),typeof(EnemyStatusInfo))]
public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// 敌人状态
    /// </summary>
    public enum State
    { 
        /// <summary>
        /// 攻击状态
        /// </summary>
        Attack,
        /// <summary>
        /// 死亡状态
        /// </summary>
        Death,
        /// <summary>
        /// 寻路状态
        /// </summary>
        Pathfinding
    }

    private EnemyAnimation animAction;
    private EnemyMotor motor;
    private Gun gun;
    private GunAnimation gunAnim;
    private void Start()
    {
        animAction = GetComponent<EnemyAnimation>();
        motor = GetComponent<EnemyMotor>();
        gun = GetComponent<Gun>();
        gunAnim = GetComponent<GunAnimation>();
    }

    /// <summary>
    /// 敌人状态
    /// </summary>
    public State state = State.Pathfinding;

    private void Update()
    {
        switch (state)
        { 
            case State.Pathfinding:
                Pathfinding(); 
                break;
            case State.Attack:
                Attack();  
                break;
        }
    }

    private float atkTime;
    /// <summary>
    /// 攻击间隔
    /// </summary>
    public float atkInterval = 3;

    /// <summary>
    /// 攻击延迟时间
    /// </summary>
    public float delay = 0.3f;

    private void Attack()
    {
        motor.LookRotation(PlayerStatusInfo.Instance.transform.position);

        //限制攻击频率
        //播放攻动画
        if (atkTime <= Time.time &&  !gunAnim.IsPlaying(gunAnim.updateAnimName))
        { 
            animAction.Play(animAction.atkName);
            //希望动画播放到某一时刻再执行攻击行为
            //建议使用动画事件
            Invoke("Shoot", delay); 

            atkTime = Time.time + atkInterval;
        }

        if (!animAction.IsPlaying(animAction.atkName) && !gunAnim.IsPlaying(gunAnim.updateAnimName))
        {
            //如果攻击动画没有播放  再  播放闲置动画
            animAction.Play(animAction.idleName);
        }
    }

    private void Pathfinding()
    {
        //播放跑步动画
        animAction.Play(animAction.runName);
        //调用马达寻路功能  如果到达终点，修改状态为 state 攻击
        if (!motor.Pathfinding()) state = State.Attack; 
    }

    private void Shoot()
    {
        if (!gun.Firing(PlayerStatusInfo.Instance.headTF.position - gun.firePoint.position))
        {
            //如果发射子弹失败
            gun.UpdateAmmo();
        }
    }
}
