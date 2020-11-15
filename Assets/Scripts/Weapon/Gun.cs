using UnityEngine;
using System.Collections;

/// <summary>
/// 枪
/// </summary>
public class Gun : MonoBehaviour
{
    public float atk;

    public float atkDistance=200;

    /// <summary>
    /// 子弹预制件
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// 开火点
    /// </summary>
    public Transform firePoint;

    private AudioSource source;
    private GunAnimation anim;
    private MuzzleFlash flash;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<GunAnimation>();
        flash = firePoint.GetComponent<MuzzleFlash>();
    }
     
    //发射子弹
    //玩家枪发射的子弹，朝向枪口正方向
    //敌人发射的子弹，朝向玩家
    public bool Firing(Vector3 dir)
    {
        //判定能否发射子弹(弹匣子弹数     攻击动画是否播放)
        if (!Ready()) return false;

        //如果可以发射子弹
        //1.创建子弹（创建谁？在哪？旋转？）
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir)) as GameObject;
        //初始化，传递攻击力、攻击距离
        bulletGO.GetComponent<Bullet>().Init(atk, atkDistance); 

        //2.播放声音  
        source.Play();
        //3.播放动画
        //anim.Play(anim.fireAnimName); 因为录制的动画片段很短，所以使用PlayQueued播放
        anim.PlayQueued(anim.fireAnimName);
         
        //4.显示火花
        flash.DisplayFlash();

        return true;
    }
     
   public int ammoCapacity;//弹匣容量
   public int currentAmmoBullets; //当前弹匣内子弹数
   public int remainBullets;//剩余子弹数

    //准备发射子弹
    private bool Ready()
    {
        if (currentAmmoBullets <= 0 || anim.IsPlaying(anim.updateAnimName)) return false;

        currentAmmoBullets--;

        //如果弹匣没有子弹  则 播放缺少子弹动画
        if (currentAmmoBullets == 0)
            anim.PlayQueued(anim.lackBulletAnimName);

        return true;
    }

    //更换弹匣
    public void UpdateAmmo()
    {
        //能否更换(剩余子弹数    当前弹匣子弹数)
        if (remainBullets <= 0 || currentAmmoBullets == ammoCapacity) return;
         
        //播放更换弹匣动画
        anim.PlayQueued(anim.updateAnimName);

        //向当前弹匣内添加子弹
        currentAmmoBullets = remainBullets >= ammoCapacity ? ammoCapacity : remainBullets;

        //扣除剩余子弹
        remainBullets -= currentAmmoBullets;
    }
}
