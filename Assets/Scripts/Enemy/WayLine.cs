using UnityEngine;
using System.Collections;

/// <summary>
/// 路线类
/// </summary>
public class WayLine 
{
    /// <summary>
    /// 所有路点坐标
    /// </summary>
    public Vector3[]  Points { get; set; }

    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsUsable { get; set; }

    //默认 IsUsable 为 false  
    //       Points  为 null
    public WayLine(int pointCount)
    {
        this.Points = new Vector3[pointCount];
        this.IsUsable = true;
    }
}
