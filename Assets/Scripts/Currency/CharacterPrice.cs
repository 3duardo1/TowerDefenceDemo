using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPrice : MonoBehaviour
{
    [SerializeField]
    private int purchasePrice = 100;
    public int PurchasePrice {
        get => purchasePrice; 
        set {
            purchasePrice = value;
        } 
    }
}
