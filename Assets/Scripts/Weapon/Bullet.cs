using UnityEngine;
using System.Collections;

/// <summary>
/// 子弹
/// </summary>
public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float atk;

    [HideInInspector]
    public RaycastHit hit;

    [HideInInspector]
    public float atkDistance;

    public LayerMask layer;

    public void Init(float atk,float distance)
    {
        this.atk = atk;
        atkDistance = distance;

        CalculateTargetPoint();
    }

    public Vector3 targetPos;
    //通过射线计算击中物体
    private void CalculateTargetPoint()
    { 
        if (Physics.Raycast(transform.position, transform.forward, out hit, atkDistance, layer))
        {
            targetPos = hit.point;
        }
        else
        {
            targetPos = transform.TransformPoint(0, 0, atkDistance);
        } 
    }

    private void Update()
    { 
        Movement(); 
        if ((transform.position - targetPos).sqrMagnitude < 0.1f)
        { //到达目标点
            //销毁子弹
            Destroy(gameObject);

            //生成特效
            GenerateContactEffect();
        }
    }

    private void Movement()
    { 
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }
    //生成接触特效
    private void GenerateContactEffect()
    { // Resources/ContactEffects/xxxx
        //根据 受击物体标签（ hit.collider.tag） 创建相应特效
        //规定：读取的资源必须放置在 Resources 文件夹内
        //GameObject go = Resources.Load<GameObject>("ContactEffects/xx");

        if (hit.collider == null) return;

        //特效命名规则：Effects+标签
        string prefabName = "ContactEffects/Effects" + hit.collider.tag;
        GameObject go = Resources.Load<GameObject>(prefabName);
        if (go)
        {
            Instantiate(go, targetPos + hit.normal *0.01f, Quaternion.LookRotation(hit.normal));
        }
    }

    public float moveSpeed = 100;
}
