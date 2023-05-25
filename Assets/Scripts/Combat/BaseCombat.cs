using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCombat : MonoBehaviour
{
    [SerializeField]
    protected CharacterType characterType;
    [SerializeField]
    protected float AttackDamage = 50;
    [SerializeField]
    protected float AttackInterval = 1.5f;
     [SerializeField][Tooltip("In seconds. Will be used if set as an Attacker")]
    public float spawnRate = 5f;

    protected virtual void Start(){
        gameObject.tag = characterType.ToString();
    }

    protected abstract void Attack(float Damage);

    protected abstract bool CanAttack();
    
    protected IEnumerator DetermineIfAttack (float seconds) {
        while (true) {
        
            yield return new WaitForSeconds (seconds);
            if (CanAttack()){
                Attack(AttackDamage);
            }
        }
    }
}


