using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Player player;
   public Text scoreText;
   public GameObject playButton;
   public GameObject gameOver;
   public AudioSource HubMusic;
   public AudioSource GameplayMusic;

   private int score;

   private void Awake()
   {
       Application.targetFrameRate = 60;    

      HubMusic.Play();  
      GameplayMusic.Stop();
      
      Pause();
   }
   
   public void Play()
   {
      score = 0;
      scoreText.text = score.ToString();

      playButton.SetActive(false);
      gameOver.SetActive(false);

      Time.timeScale = 1f;
      player.enabled = true;

      Pipes[] pipes = FindObjectsOfType<Pipes>();

      for(int i = 0; i <pipes.Length; i++)
      {
         Destroy(pipes[i].gameObject);
      }        
      HubMusic.Stop();
      GameplayMusic.Play();
   }

   public void Pause()
   {
         Time.timeScale = 0f;
         player.enabled = false;

         GameplayMusic.Stop();

   }

   public void GameOver()
   {

     gameOver.SetActive(true);
     playButton.SetActive(true);

     Pause();

   }

   public void IncreaseScore()
   {
      score++;
      scoreText.text = score.ToString();
   }
}
