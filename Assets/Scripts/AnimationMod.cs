using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMod : MonoBehaviour
{
    public Animator animator;
    public Weapon weapon;

    private void Start()
    {
        weapon = GetComponent<Weapon>();

        weapon.onShoot.AddListener(RecoilAnim);
        weapon.onReload.AddListener(ReloadAnim);

        animator.SetFloat("ReloadTime", 1 / 2f);
        animator.SetFloat("FireRate", 1 / weapon.fireInterval);
    }

    void RecoilAnim()
    { 
        animator.Play("GunRecoilAnim");
    }

    void ReloadAnim()
    {
        animator.Play("GunReloadAnim");
    }
}