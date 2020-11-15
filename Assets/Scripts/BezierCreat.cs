using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class BezierCreat : MonoBehaviour
{

    public Transform start;
    public Transform ctrl01;
    public Transform ctrl02;
    public Transform end;
    
    
    private  static Vector3 CreatBezier(Vector3 start,Vector3 ctrl01,Vector3 ctrl02,Vector3 end,float t)
    {
        return start * Mathf.Pow(1 - t, 3) + 3 * ctrl01 * t * Mathf.Pow(1 - t, 2) + 3 * ctrl02 * Mathf.Pow(t, 2) * (1 - t) + end * Mathf.Pow(t, 3);
    }
    public List<Vector3> zhuangDianDeJiHe;
    public int jieDian = 30;
    
    private void CreatPoints()
    {
        float jianJu = 1.0f / (jieDian - 1);
        float t = 0;
          for (int i = 0; i < jieDian; i++)
        {

            Vector3 shengChengDeDian = CreatBezier(start.position, ctrl01.position, ctrl02.position, end.position, t);
            zhuangDianDeJiHe.Add(shengChengDeDian);
            t += jianJu;
        }

    }


    private void DrawLine()
    {
        var renderer = GetComponent<LineRenderer>();
        renderer.SetVertexCount(zhuangDianDeJiHe.Count);
        renderer.SetPositions(zhuangDianDeJiHe.ToArray());

    }


    void Start()
    {
        zhuangDianDeJiHe = new List<Vector3>(jieDian);
        CreatPoints();
        DrawLine();
    }
}
