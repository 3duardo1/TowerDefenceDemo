using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    private GameTimer gameTimer;
    private GameObject winLoseLabel;
    void Start()
    {
        SetWinLoseLabel();
        gameTimer = GameObject.FindObjectOfType<GameTimer>();
        if (gameTimer){
            gameTimer.OnTimeIsOver += TimeIsOver;
        }
    }

    void Update()
    {
        if (!gameTimer && AllEnemiesDead()){
            print("GAME OVER");
            GameWon();
            enabled = false;
        }
    }

    private void TimeIsOver(){
        gameTimer.OnTimeIsOver -= TimeIsOver;
        Destroy(gameTimer);
        EnemySpawner[] levelEnemySpawners = GameObject.FindObjectsOfType<EnemySpawner>() as EnemySpawner[];
        foreach (EnemySpawner enemySpawner in levelEnemySpawners){
            enemySpawner.StopSpawning();
        }
    }

    private bool AllEnemiesDead(){
        return GameObject.FindGameObjectWithTag(CharacterType.Attacker.ToString()) == null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == CharacterType.Attacker.ToString()){
            GameLose();
        }
    }

    private void GameWon(){
        winLoseLabel.SetActive(true);
        winLoseLabel.GetComponent<Text>().text = "You survived!";
    }

    private void GameLose(){
        winLoseLabel.SetActive(true);
        winLoseLabel.GetComponent<Text>().text = "Game Over!";
    }

    private void SetWinLoseLabel(){
        winLoseLabel = GameObject.Find("WinLoseLabel");

        if (!winLoseLabel){
            Debug.LogError("LevelState->SetWinLoseLabel: No Win/Lose Label was found, check scene hierarchy");
        }else{
            winLoseLabel.SetActive(false);
        }
    }
}
