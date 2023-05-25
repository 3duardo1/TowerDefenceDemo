using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject characterPrefab;

    private CharacterPrice characterPrice;
    private CurrencyManager currencyManager;
    private DefenderSpawner defenderSpawner;
    private bool selected = false;
    void Start()
    {
        currencyManager = GameObject.FindObjectOfType<CurrencyManager>();
        if (currencyManager){
            currencyManager.OnResourcesChanged += CheckIfAffordable;
        }

        defenderSpawner = GameObject.FindObjectOfType<DefenderSpawner>();
        if (defenderSpawner){
            defenderSpawner.DefenderSuccesfullyInstanciated += SuccesfullyInstanciated;
        }

        if (TryGetComponent<CharacterPrice>(out CharacterPrice characterPrice)){
            this.characterPrice = characterPrice;
        }else{
            Debug.LogError("CharacterSelector->Start(): This button does not contain CharacterPrice component");
        }
        DisplayPrice();
        CheckIfAffordable();
    }

    void OnMouseDown(){
        if (!currencyManager && !defenderSpawner && !characterPrice) {
            Debug.LogError("CharacterSelector->OnMouseDown(): Some references are null, check if objects exists in scene");
            return;
        }

        if (!selected){
            if (currencyManager.CurrencyAmount >= characterPrice.PurchasePrice){
                ResetAllButtons();
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                defenderSpawner.Defender = characterPrefab;
                selected = true;
            }
        }else{
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            defenderSpawner.Defender = null;
            selected = false;
        }
    }

    void ResetAllButtons(){
        CharacterSelector[] buttons = GameObject.FindObjectsOfType<CharacterSelector>();
        foreach (CharacterSelector button in buttons){
            button.CheckIfAffordable();
            selected = false;
        }
    }

    void SuccesfullyInstanciated(GameObject defender){
        if (defender != characterPrefab) {return;}
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selected = false;
        currencyManager.SubtractCurrency(characterPrice.PurchasePrice);
    }

    void CheckIfAffordable(){
        if(selected) {return;}
        if (currencyManager.CurrencyAmount >= characterPrice.PurchasePrice){
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }else{
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    void DisplayPrice(){
        GetComponentInChildren<Text>().text = characterPrice.PurchasePrice.ToString();
    }
}
