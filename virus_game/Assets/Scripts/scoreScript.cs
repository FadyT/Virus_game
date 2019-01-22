using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoreScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static int score;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        score = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text =  "score : " + score.ToString() ;
    }
}
