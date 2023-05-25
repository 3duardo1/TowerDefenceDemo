using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCombat : BaseCombat
{
    private List <Health> collidingEnemyHealthList = new List<Health>();
    private Health currentEnemy;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(DetermineIfAttack(AttackInterval));
    }

    protected override void Attack(float Damage)
    {
        currentEnemy.DealDamage(AttackDamage);
    }

    protected override bool CanAttack()
    {
        if (collidingEnemyHealthList.Count <= 0) {return false;}

        currentEnemy = collidingEnemyHealthList[0];
        if (currentEnemy){
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out Health enemyHealthComponent) && StaticUtils.GetTypeFromTag(other.gameObject.tag) == StaticUtils.GetOppositeType(characterType)){
            collidingEnemyHealthList.Add(enemyHealthComponent);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out Health enemyHealthComponent) && StaticUtils.GetTypeFromTag(other.gameObject.tag) == StaticUtils.GetOppositeType(characterType)){
            collidingEnemyHealthList.Remove(enemyHealthComponent);
        }
    }


}
