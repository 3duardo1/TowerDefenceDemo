using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectileParams projectileParams = new ProjectileParams(Vector2.right, 50f, CharacterType.Undefined);

    void Update()
    {
        transform.Translate(projectileParams.velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == projectileParams.ownerType.ToString()) {return;}

        if (collider.gameObject.TryGetComponent(out Health healthComponent)){
            healthComponent.DealDamage(projectileParams.damage);
            Destroy(gameObject);
        }
        
    }

    public void SetProjectileParams(ProjectileParams projectileParams){
        this.projectileParams = projectileParams;
    }

}


