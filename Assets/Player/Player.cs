using System;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Player : MonoBehaviour
{
    public int score = 0;
    public int health = 100;


    void Start()
    {
        // Reset score and health on game start
        score = 0;
        health = 100;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took " + damage + " damage. Health left: " + health);

        if (health <= 0)
        {
            Debug.Log("Player has Died! You Lose!");
            RestartCurrentScene();
        }
    }

    void Win()
        {
            if (score == 10)
            {
                Debug.Log("Player has won the game!");
                RestartCurrentScene();
            }
        }

    public void RestartCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Get the current scene
        SceneManager.LoadScene(currentScene.name); // Reload the scene by its name
    }

    internal void TakeDamage()
    {
        throw new NotImplementedException();
    }
}    






