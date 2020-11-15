using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家单发枪控制
/// </summary>
[RequireComponent(typeof(Gun))]
public class PlayerSingleGunControl : MonoBehaviour
{
    private Gun gun;

    private void Start()
    {
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {//朝向枪口正前方发射子弹
            gun.Firing(gun.firePoint.forward);
        }
        if (Input.GetMouseButtonDown(1))
        {//朝向枪口正前方发射子弹
            gun.UpdateAmmo();
        }
    }
 
}
