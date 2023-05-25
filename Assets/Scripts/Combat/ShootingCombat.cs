using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCombat : BaseCombat
{
    [SerializeField]
    private GameObject weaponHolding;

    [SerializeField]
    private GameObject weaponPrefab;

    private EnemySpawner myLaneSpawner;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(DetermineIfAttack(AttackInterval));
        InstantiateWeapon(weaponPrefab);
        FindMyLane();
    }

    public void InstantiateWeapon(GameObject newWeapon){
        weaponPrefab = Instantiate(newWeapon) as GameObject;
        weaponPrefab.transform.parent = transform;
        weaponPrefab.transform.position = weaponHolding.transform.position;
    }

    protected override void Attack(float Damage)
    {
        if (weaponPrefab.gameObject.TryGetComponent(out IFireWeapon fireWeapon)){
            //TODO: set power up for muzzle velocity
            fireWeapon.Shoot(GetShootingDirection(), AttackDamage, characterType);
        }
    }

    protected override bool CanAttack()
    {
        CharacterType enemyType = StaticUtils.GetOppositeType(characterType);
        GameObject[] enemiesArr = GameObject.FindGameObjectsWithTag(enemyType.ToString());
        
        List<GameObject> enemiesList = new List<GameObject>(enemiesArr);
        return enemiesList.Find(i => i.transform.position.y == transform.position.y);
    }

     private void FindMyLane(){
		EnemySpawner[] spawnerArray = GameObject.FindObjectsOfType<EnemySpawner>();
		
		foreach (EnemySpawner spawner in spawnerArray){
			if(spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + ": can't find spawner in lane " + transform.position.y);
	}

    private Vector2 GetShootingDirection(){
        switch(characterType){
            case CharacterType.Attacker:
            {
                return Vector2.left;
            }
            case CharacterType.Defender:
            {
                return Vector2.right;
            }
            case CharacterType.Undefined:
            {
                return Vector2.zero;
            }
            default: return Vector2.zero;
        }
    }
}
