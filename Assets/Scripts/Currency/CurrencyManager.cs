using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField]
    private int currencyAmount = 100;
    public int CurrencyAmount {
        get => currencyAmount; 
        set {
            currencyAmount = value;
            gameObject.GetComponent<Text>().text = CurrencyAmount.ToString();
            OnResourcesChanged();
        } 
    }

    public delegate void ResourcesChanged();
    public event ResourcesChanged OnResourcesChanged;

    void Start(){
        gameObject.GetComponent<Text>().text = currencyAmount.ToString();
    }

    public void AddCurrency(int currencyToAdd){
        CurrencyAmount += currencyToAdd;
    }

    public void SubtractCurrency(int currencyToSubtract){
        CurrencyAmount -= currencyToSubtract;
    }
}
