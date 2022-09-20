using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PauseAndResumeSystem : MonoBehaviour
{
    public GameObject WinCamera;
    public GameObject spectateCamera;
    public GameObject panel;
    public GameObject winPanel;
    public GameObject LosePanel;
    public Text WinTime›sUp;
    public Text LoseTime›sUp;
    public Text WinHighScoreText;
    public Text LoseHighScoreText;
    public float Seconds = 30;
    public Text Seconds_Text;
    public EnemyPush[] LastEnemies;

    public int Highscore = 0;
    public GameObject Player;
    public GameObject WinPlayer;
    public GameObject SpectateButton;
    // Start is called before the first frame update
    void Start()
    {
        Seconds_Text.gameObject.SetActive(false);
        pause();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
       
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
        if (WinPlayer.gameObject.name=="karakter")
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
                if (LastEnemies[i].gameObject.name=="karakter")
                {
                    Win(); 
                    pause();
                    Debug.Log("winn" );
                } 
                else
                {
                    Lose(); 
                    pause();
                    Debug.Log("lose");
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
        StartCoroutine(time());
        



       } 
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Win() 
    {
        WinHighScoreText.text = Highscore.ToString();
        WinCamera.transform.position = WinCamera.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x , Player.gameObject.transform.position.y +1, -Player.gameObject.transform.position.z - 5);
        WinCamera.SetActive(true);
        winPanel.gameObject.SetActive(true);
    }

    public void Lose()
    {
        LoseHighScoreText.text = Highscore.ToString();
        LosePanel.gameObject.SetActive(true);
        WinCamera.SetActive(true);
        WinCamera.transform.position = Player.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x , Player.gameObject.transform.position.y + 1, -Player.gameObject.transform.position.z - 5);
        Player = null;
    }
    public void spectate() 
    {
        spectateCamera.SetActive(true);
        SpectateButton.SetActive(false);
    }
}
