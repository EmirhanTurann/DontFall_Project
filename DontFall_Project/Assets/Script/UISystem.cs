using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class UISystem : MonoBehaviour
{
    public GameObject WinCamera;
    public GameObject spectateCamera;
    public GameObject panel;
    public GameObject winPanel;
    public GameObject LosePanel;

    public Text WinTime›sUp;
    public Text LoseTime›sUp;
    public Text Seconds_Text;
    public Text WinHighScoreText;
    public Text LoseHighScoreText;
    public Text SurvivorsCountText;

    public float Seconds = 30;
    public int Highscore = 0;
    
    public EnemyPush[] LastEnemies;
    public ScoreSystem script;
    public CollectObjectSpawn script2;
    
    public GameObject Player;
    public GameObject WinPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        Seconds_Text.gameObject.SetActive(false);
        SurvivorsCountText.gameObject.SetActive(false);
        pause();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyPush[] LastEnemies = GameObject.FindObjectsOfType<EnemyPush>();
        SurvivorsCountText.text = LastEnemies.Length.ToString();
      
       
        LastOne();
      
        if (Seconds <= -1)
        {
            Time›sUp();
            pause();
            
          
        }
    }
    IEnumerator time()
    {
        while (true)
        {
            int s = (int)Seconds--;

            Seconds_Text.text = s.ToString();

            yield return new WaitForSeconds(1);
        }

    }
    public void Time›sUp()
    {
        
    EnemyPush[] LastEnemies = GameObject.FindObjectsOfType<EnemyPush>();
        
        for (int i = 0; i < LastEnemies.Length ; i++)
        {
            
           
            if (i == 0)
            {
                Highscore = LastEnemies[i].score;
              
               
            }

             if (Highscore <= LastEnemies[i].score)
            {
                Highscore = LastEnemies[i].score;

                WinPlayer = LastEnemies[i].gameObject;

            }
          
        }
        if (WinPlayer.gameObject.name== "Player")
        {
            Win();
            pause();
            WinTime›sUp.gameObject.SetActive(true);
        
        }
        else
        {
           
            
            Lose();
            pause();
            LoseTime›sUp.gameObject.SetActive(true);
        }
 
        
    }
    void LastOne()
    {
        EnemyPush[] LastEnemies = GameObject.FindObjectsOfType<EnemyPush>();
        if (LastEnemies.Length == 1)
        {
            Debug.Log("SON" + LastEnemies.Length);
            for (int i = 0; i < LastEnemies.Length; i++)
            {
               Highscore= LastEnemies[i].score;
                if (LastEnemies[i].gameObject.name=="Player")
                {
                    
                    Win(); 
                    pause();
                    Debug.Log("winn" );
                } 
               
            }
           
        }
       

    }
    public void pause() 
    {
        Time.timeScale = 0;

    }
   public void resume()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
        Seconds_Text.gameObject.SetActive(true);
        SurvivorsCountText.gameObject.SetActive(true);
        StartCoroutine(time());
        StartCoroutine(script2.SpawnCollectObject()); 

        



       } 
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Win() 
    {
        WinHighScoreText.text = Highscore.ToString();
        WinCamera.transform.position = WinCamera.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x , Player.gameObject.transform.position.y +1, -Player.gameObject.transform.position.z - 3);
        WinCamera.transform.LookAt(Player.transform);
        WinCamera.SetActive(true);
        winPanel.gameObject.SetActive(true);
    }

    public void Lose()
    {
       
        
        LoseHighScoreText.text = script.Playerscore.ToString();
        LosePanel.gameObject.SetActive(true);
        spectateCamera.SetActive(true);
        Player = null;
    }
  
}
