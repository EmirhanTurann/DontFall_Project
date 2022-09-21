using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathTriggerControl : UISystem
{
    
    public EnemyPush[] allEnemies;
    public ScoreSystem script;
    public bool score›nc;
    public string deathName;
   

    // public PauseAndResumeSystem script;


    private void Start()
    {
        
            
        
    }
    private void FixedUpdate()
    {
        
        if (score›nc==true)
        {
            allEnemies = GameObject.FindObjectsOfType<EnemyPush>();
            for (int i = 0; i < allEnemies.Length; i++)
            {
                
                if (allEnemies[i].LastObjectName.ToString() == deathName.ToString())
                {
                   
                    allEnemies[i].score+=50;
                    score›nc = false;

                }

            }

        }
    }
   
    // What will happen if the character falls down
    private void OnTriggerEnter(Collider other)
    {
       
          Destroy(other.gameObject);
       

        //The part that adds points to the person who dropped the character.
        if (other.gameObject.tag=="Enemy")
        {
            score›nc = true;

            deathName = other.gameObject.name;
           
           

            if (other.gameObject.name == "Player")
        {
            
            LoseHighScoreText.text = script.Playerscore.ToString();
            LosePanel.gameObject.SetActive(true);
            spectateCamera.SetActive(true);
            Player = null;
        } 
            
            
            
            

        }
    }
}
