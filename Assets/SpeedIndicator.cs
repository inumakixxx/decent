using System.IO;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class SpeedIndicator : MonoBehaviour
{
    TextMeshProUGUI text;
    public Car car;
    int displaySpeed = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int speed = (int)car.speedKmh;
        if(displaySpeed != speed){
            text.text = $"{speed} km/h";
            displaySpeed = speed;
        }
    }
}
