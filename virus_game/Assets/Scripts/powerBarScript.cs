using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBarScript : MonoBehaviour
{
    Image powerImage;
    float maxPower = 100;

    public static float power;
    
    // Start is called before the first frame update
    void Start()
    {
        powerImage = GetComponent<Image>();
        power = 0;
    }

    // Update is called once per frame
    void Update()
    {
        powerImage.fillAmount = power / maxPower;
        Debug.Log("power Bar" + power / maxPower);

    }
}
