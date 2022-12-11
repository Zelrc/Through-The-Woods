using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static DragLine;

public class TrackingBulletController : MonoBehaviour
{
    public TrackingProjectile script;
    public Transform shootingPos;
    public GameObject projectile;

    GameObject bullet;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(script.active)
        {
            if(ActionPhase)
            {
                if(bullet == null)
                {
                    bullet = Instantiate(projectile, shootingPos.position, shootingPos.rotation);
                    bullet.transform.DOMove(script.targetEnemy.transform.position, 0.4f);
                    script.active = false;
                }
                
            }
            
        }
    }
}
