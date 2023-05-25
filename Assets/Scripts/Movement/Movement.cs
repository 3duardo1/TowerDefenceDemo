using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private MovementType movementType;

    [SerializeField][Tooltip("How many grid squares per second")]
    private float movementSpeed = 0.25f;

    [SerializeField]
    private bool stopOnEnemyContact = true;

    private Vector3 directionVector;

    void Start()
    {
        switch (movementType){
            case MovementType.RightToLeft:
            {
                directionVector = Vector3.left;
                break;
            }
            case MovementType.LeftToRight:
            {
                directionVector = Vector3.right;
                break;
            }
            default: directionVector = Vector3.left; break;
        }
    }

    void Update()
    {
        transform.Translate(directionVector * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!stopOnEnemyContact) {return;}
        if (other.gameObject.TryGetComponent(out Health enemyHealthComponent) && StaticUtils.GetTypeFromTag(other.gameObject.tag) == StaticUtils.GetOppositeType(gameObject.tag)){
            enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!stopOnEnemyContact) {return;}
        if (other.gameObject.TryGetComponent(out Health enemyHealthComponent) && StaticUtils.GetTypeFromTag(other.gameObject.tag) == StaticUtils.GetOppositeType(gameObject.tag)){
            enabled = true;
        }
    }
}
