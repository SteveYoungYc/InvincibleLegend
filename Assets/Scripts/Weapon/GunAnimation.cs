using UnityEngine;
using System.Collections;

/// <summary>
/// 枪动画
/// </summary>
public class GunAnimation : MonoBehaviour
{
    /// <summary>
    /// 开枪
    /// </summary> 
    public string fireAnimName="PlayerGun01_Fire"; 

    /// <summary>
    /// 更换弹匣 
    /// </summary> 
    public string updateAnimName="PlayerGun01_UpdateAmmo";

    /// <summary>
    /// 缺少子弹
    /// </summary> 
    public string lackBulletAnimName = "PlayerGun01_LackBullet";

    //建议：提取EnemyAnimation 与 当前类的共有行为。
    //播放动画
    private Animation anim;
    private void Start()
    {
        //查找动画组件
        anim = GetComponentInChildren<Animation>();
    }

    /// <summary>
    /// 播放指定名称的动画片段
    /// </summary>
    /// <param name="animName">动画名称</param>
    public void Play(string animName)
    { 
        if (anim != null && !string.IsNullOrEmpty(animName))
            anim.CrossFade(animName); 
    }

    public void PlayQueued(string animName)
    {
        if (anim != null && !string.IsNullOrEmpty(animName))
            anim.PlayQueued(animName);
    }

    /// <summary>
    /// 是否正在播放某个动画片段
    /// </summary>
    /// <param name="animName">动画名称</param>
    /// <returns></returns>
    public bool IsPlaying(string animName)
    {
        if (anim != null && !string.IsNullOrEmpty(animName))
            return anim.IsPlaying(animName);

        return false;
    }
}
