using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敌人生成器
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    /// <summary>
    /// 开始时需要创建的敌人数量
    /// </summary>
    public int startCount = 2;

    private void Start()
    {
        CalculateWayLines();

        for (int i = 0; i < startCount; i++)
        {
            GenerateEnemy();
        }
    }

    //计算路线
    private WayLine[] lines;
    private void CalculateWayLines()
    { 
        //WayLine 路线  与 子物体   对应
        //lines[0].Points 该路线所有路点坐标   与  子物体的子物体.Position对应
        lines = new WayLine[transform.childCount];
        //创建路线
        for (int i = 0; i < lines.Length; i++)//0    1     2
        { 
            Transform waylineTF =  transform.GetChild(i);
            lines[i] = new WayLine(waylineTF.childCount);
            for (int pointIndex = 0; pointIndex < waylineTF.childCount; pointIndex++)
            {
                //获取每个路点坐标
                lines[i].Points[pointIndex] = waylineTF.GetChild(pointIndex).position;
            } 
        }
    }

    //当前产生的敌人数量
    private int spawnedCount;
    /// <summary>
    /// 可以产生敌人的最大值
    /// </summary>
    public int maxCount;

    /// <summary>
    /// 产生敌人的最大延迟时间
    /// </summary>
    public int maxDelay = 10;

    /// <summary>
    /// 敌人类型
    /// </summary>
    public GameObject[] enemyTypes;

    /// <summary>
    /// 生成一个敌人(一开始根据startCount生成敌人，敌人死亡时生成敌人)
    /// </summary>
    public void GenerateEnemy()
    {
        if (spawnedCount < maxCount)
        { 
            spawnedCount++;
            // 随机延迟时间 
            float delay = Random.Range(0, maxDelay);
            Invoke("CreateEnemy", delay); 
        }
        else
        {
            print("over");
           //生成任务结束……
            //如果所有敌人死亡，再启用下一个生成器
            if (IsEnemyAllDeath())
            {
                print("death");
                GetComponentInParent<SpawnSystem>().ActivateNextSpawn();
            }
        } 
    }

    private bool IsEnemyAllDeath()
    {
        //便利所有路线
        foreach (var item in lines)
        {
            if (!item.IsUsable)
                return false;
        }
        return true;
    }

    private void CreateEnemy()
    {
        //查找所有可用路线 
        var usableWaylines = SelectUsableWayLines();
        //随机选择一条
        WayLine wayLine = usableWaylines[Random.Range(0, usableWaylines.Length)];

        //创建一个敌人
        //GameObject enemyGO = Instantiate(敌人预制件, 第一个路点, Quaternion.identity) as GameObject;
        int enemyTypeIndex = Random.Range(0, enemyTypes.Length);
        GameObject enemyGO = Instantiate(enemyTypes[enemyTypeIndex], wayLine.Points[0], Quaternion.identity) as GameObject;
        //传递信息
        enemyGO.GetComponent<EnemyMotor>().wayline = wayLine;
        wayLine.IsUsable = false;//该路线不可用
        //传递当前生成器对象引用，便于敌人死亡时调用当前对象的生成敌人方法
        //[建议使用委托代替]
        enemyGO.GetComponent<EnemyStatusInfo>().spawn = this; 
    }

    private WayLine[] SelectUsableWayLines()
    {
        List<WayLine> result = new List<WayLine>(lines.Length);
        foreach (var item in lines)
        {
            if (item.IsUsable) result.Add(item);
        }
        return result.ToArray();
    }
}
