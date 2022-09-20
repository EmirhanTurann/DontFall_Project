using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
  
    public EnemyPush script;
    public TextMesh ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        script=GetComponent<EnemyPush>();
        
    }

    // Update is called once per frame
    void Update()
    {

        ScoreText.text = script.score.ToString();


    }
}
