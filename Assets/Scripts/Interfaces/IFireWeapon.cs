using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireWeapon
{
    float muzzleVelocity {set; get;}
    void Shoot(Vector2 direction, float damageAmount, CharacterType ownerType);

}
