using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerControl : UISystem
{
    
    public EnemyPush[] allEnemies;
    public ScoreSystem script;
   
   // public PauseAndResumeSystem script;
    
    
    private void Start()
    {
        
            
        
    }
    private void Update()
    {
        allEnemies = GameObject.FindObjectsOfType<EnemyPush>();
    }
   
    // What will happen if the character falls down
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            LoseHighScoreText.text = script.Playerscore.ToString();
            LosePanel.gameObject.SetActive(true);
            spectateCamera.SetActive(true);
            Player = null;
           
            

        }
        //The part that adds points to the person who dropped the character.
        if (other.gameObject.tag=="Enemy")
        {
            for (int i = 0; i < allEnemies.Length-1; i++)
            {
             if (allEnemies[i].LastObjectName.ToString() == other.gameObject.name.ToString())
              {
                    allEnemies[i].score++;
                    break;

                }
                
            }
           

            
            
            
            Destroy(other.gameObject);
            

        }
    }
}
