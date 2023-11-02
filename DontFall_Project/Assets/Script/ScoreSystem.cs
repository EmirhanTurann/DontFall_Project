using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
  
    public EnemyPush script;
    public TextMesh ScoreText;
    public int Playerscore=0;

   
    void Start()
    {
        script=GetComponent<EnemyPush>();
        
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        if (this.gameObject.name=="Player")
        {
            Playerscore = script.score;
        }
        
        ScoreText.text = script.score.ToString();


    }
}
