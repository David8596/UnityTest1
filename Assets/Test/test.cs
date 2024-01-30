using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField] public Slider slider;
    public float sliderValue;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("save", sliderValue);
    }
    public void SaveSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }
}