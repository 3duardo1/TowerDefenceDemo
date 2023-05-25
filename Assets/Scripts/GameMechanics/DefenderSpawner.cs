using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
public Camera GameCamera;

private GameObject defender;
public GameObject Defender {
        get => defender; 
        set {
            defender = value;
        } 
    }

public delegate void DefenderInstantiated(GameObject defender);
public event DefenderInstantiated DefenderSuccesfullyInstanciated;

private GameObject parent;
	void Start () 
    {
		parent = GameObject.Find("Defenders");
		if(!parent){
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown()
    {
		if (!defender) {return;}
	
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
        SpawnDefender(roundedPos, defender);
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender)
	{
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDefender = Instantiate (defender, roundedPos, zeroRotation) as GameObject;
		newDefender.transform.parent = parent.transform;
		DefenderSuccesfullyInstanciated(Defender);
		Defender = null;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
	}
	
	Vector2 CalculateWorldPointOfMouseClick()
    {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
        float distanceFromCamera = Mathf.Abs(GameCamera.transform.position.z);
		Vector2 worldPos = GameCamera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, distanceFromCamera));
		return worldPos;
	}
}
