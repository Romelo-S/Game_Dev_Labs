using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public Text score; 

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + Main.S.score; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
