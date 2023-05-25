using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour, IFireWeapon
{
    [SerializeField]
    private float muzzleVelocity = 5;
    public GameObject projectilePrefab, muzzlePosition;
    private GameObject parentObject;

    float IFireWeapon.muzzleVelocity{
        get => muzzleVelocity;
        set => muzzleVelocity = value;
    }

    void Start()
    {
        parentObject = GameObject.Find("Projectiles");
		if(!parentObject){
			parentObject = new GameObject("Projectiles");
		}
    }

    void IFireWeapon.Shoot(Vector2 direction, float damageAmount, CharacterType ownerTag)
    {
        GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
		newProjectile.transform.parent = parentObject.transform;
		newProjectile.transform.position = muzzlePosition.transform.position;
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        projectileComponent.SetProjectileParams(new ProjectileParams(muzzleVelocity*direction, damageAmount, ownerTag));
    }
}
