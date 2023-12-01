using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpearCollision : MonoBehaviour
{
   
    // Declare a delegate type for the event
    public delegate void PlayerDeathEvent();
    public static event PlayerDeathEvent OnPlayerDeath;
    public SpawnGameOverScreen gameOverScreenScript;
    [SerializeField] private AudioSource Lose;
   
    private void start()
    {
        gameOverScreenScript = FindObjectOfType<SpawnGameOverScreen>();
    }
   
   
    // This function is called when the collider enters another collider marked as a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Trigger game over screen or perform other game over actions
            GameOver();
        }
    }


    public void GameOver()
    {
        Lose.Play();
        Debug.Log("Game Over!");
        gameOverScreenScript.ShowObject();
        Time.timeScale = 0;
    }
}