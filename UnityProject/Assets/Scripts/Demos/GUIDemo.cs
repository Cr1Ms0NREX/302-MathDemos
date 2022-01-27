using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIDemo : MonoBehaviour
{

    public TMP_Text textPlayerHealth;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if(slider) slider.value = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        textPlayerHealth.text = "hello????";
    }

    public void ButtonClicked()
    {
        print("BUTTON CLICKED!!!");
    }

    public void SliderUpdated(float value)
    {
        Time.timeScale = value;
    }
}
