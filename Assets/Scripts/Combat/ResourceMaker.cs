using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMaker : BaseCombat
{

    private CurrencyManager currencyManager;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(DetermineIfAttack(AttackInterval));
        currencyManager = GameObject.FindObjectOfType<CurrencyManager>();
    }

    protected override void Attack(float Damage)
    {
        currencyManager.AddCurrency((int)AttackDamage);
    }

    protected override bool CanAttack()
    {
        return true;
    }
}
