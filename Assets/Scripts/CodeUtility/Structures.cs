using UnityEngine;

public enum CharacterType
{
    Defender,
    Attacker,
    Undefined
}

public enum MovementType
{
    RightToLeft,
    LeftToRight
}

public struct ProjectileParams{
    public Vector2 velocity;
    public float damage;
    public CharacterType ownerType;

    public ProjectileParams(Vector2 velocity, float damage, CharacterType ownerType){
        this.velocity = velocity;
        this.damage = damage;
        this.ownerType = ownerType;
    }
}

