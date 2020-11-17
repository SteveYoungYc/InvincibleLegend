using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// 玩家单发枪控制
/// </summary>
[RequireComponent(typeof(Gun))]
public class PlayerSingleGunControl : MonoBehaviour
{
    private Gun gun;
    private int burstCount;
    private const int burstGap = 5;
    private bool isBurst;
    private bool fireState;
    private bool lastFireState;

    private void Start()
    {
        gun = GetComponent<Gun>();
        burstCount = 0;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        burstCount = (burstCount + 1) % burstGap;

        if (Input.GetMouseButton(0))
        {//朝向枪口正前方发射子弹
            fireState = true;
            if (lastFireState != fireState)
            {
                burstCount = 0;
            }
            if (burstCount == 0) gun.Firing(gun.firePoint.forward);
        }
        else
        {
            fireState = false;
        }
        if (Input.GetMouseButtonDown(1))
        {//朝向枪口正前方发射子弹
            gun.UpdateAmmo();
        }

        lastFireState = fireState;
    }
}
