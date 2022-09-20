using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerControl : PauseAndResumeSystem
{
    
    public EnemyPush[] allEnemies;
   
   // public PauseAndResumeSystem script;
    
    
    private void Start()
    {
        
            
        
    }
    private void Update()
    {
        allEnemies = GameObject.FindObjectsOfType<EnemyPush>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "karakter")
        {
            LoseHighScoreText.text = Highscore.ToString();
            LosePanel.gameObject.SetActive(true);
            WinCamera.SetActive(true);
            WinCamera.transform.position = Player.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x, Player.gameObject.transform.position.y + 1, -Player.gameObject.transform.position.z - 5);
            Player = null;
            SpectateButton.gameObject.SetActive(true);
            

        }
        if (other.gameObject.tag=="Enemy")
        {
            
           

            
            for (int i = 0; i < allEnemies.Length-1; i++)
            {
             if (allEnemies[i].LastObjectName.ToString() == other.gameObject.name.ToString())
              {
                    allEnemies[i].score++;
                    

                }
                
            }
            
            Destroy(other.gameObject);
            

        }
    }
}
