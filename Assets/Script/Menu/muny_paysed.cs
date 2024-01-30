using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class muny_paysed : MonoBehaviour
{
    public GameObject menu;
    public GameObject sensivitySlider;
    public GameObject graficSlider;
    public GameObject lightSlider;
    public GameObject audioSlider;
    public Light lightControler;
    public cameraPlayer cameraPlayer;
    public TMP_Dropdown dropdown;
    public AudioSource music;
    Resolution[] res;
    [SerializeField] KeyCode keyMenu;
    [SerializeField] TextMeshProUGUI _textslider;
    [SerializeField] TextMeshProUGUI _textgrafic;
    [SerializeField] TextMeshProUGUI _textlight;
    [SerializeField] TextMeshProUGUI _textaudio;
    [SerializeField] TextMeshProUGUI _textaudioon;
    bool ismenu = false;
    public string fileName;
    public UserData _userData = new UserData();

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            var userData = SaveData.LoadUserData(fileName);
            cameraPlayer.sensivity = userData.sensivityvalue;
            QualitySettings.SetQualityLevel(userData.graficvalue, true);
            lightControler.intensity = userData.lightvalue;
            music.volume = userData.musicvalue;
            sensivitySlider.GetComponent<Slider>().value = userData.sensivityvalue;
            _textslider.text = userData.sensivityvalue.ToString("0.00");
            lightSlider.GetComponent<Slider>().value = userData.lightvalue;
            _textgrafic.text = userData.graficvalue.ToString().Replace("1", "Низкая").Replace("2", "Средняя").Replace("3", "Высокая");
            graficSlider.GetComponent<Slider>().value = userData.graficvalue;
            _textlight.text = userData.lightvalue.ToString("0.00");
            audioSlider.GetComponent<Slider>().value = userData.musicvalue * 1f;
            _textaudio.text = (userData.musicvalue * 1f).ToString("0.00");
        }
        else
        {
            _userData.sensivityvalue = 5f;
            _userData.lightvalue = 1f;
            _userData.graficvalue = Convert.ToInt32(graficSlider.GetComponent<Slider>().value);
            _userData.musicvalue = 0.16f;
            SaveData.SaveUserData(_userData, fileName);
        }
    }

    void Start()
    {
        menu.SetActive(false);
        Screen.fullScreen = true;
        getResolutionMas();
    }

    void Update()
    {
        activeMenu();
    }

    void activeMenu()
    {
        if (Input.GetKeyDown(keyMenu))
        {
            ismenu = !ismenu;
            if (ismenu)
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }
    }
    public void menuCoitry()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        ismenu = !ismenu;
    }
    public void menuExit()
    {
        Application.Quit();
        Debug.Log("ВЫХОД ИЗ ИГРЫ");
    }

    public void sensivitySet()
    {
        _textslider.text = sensivitySlider.GetComponent<Slider>().value.ToString("0.00");
        cameraPlayer.sensivity = sensivitySlider.GetComponent<Slider>().value;
    }

    void getResolutionMas()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + " x " + res[i].height.ToString();
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, true);
        dropdown.value = res.Length - 1;
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            var userData = SaveData.LoadUserData(fileName);
            Screen.SetResolution(res[userData.dropdownvalue].width, res[userData.dropdownvalue].height, true);
            dropdown.value = userData.dropdownvalue;
        }
    }

    public void graficControler()
    {
        _textgrafic.text = graficSlider.GetComponent<Slider>().value.ToString().Replace("1", "Низкая").Replace("2", "Средняя").Replace("3", "Высокая");
        QualitySettings.SetQualityLevel(Convert.ToInt32(graficSlider.GetComponent<Slider>().value), true);
    }

    public void fullscreenSet()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void lightSetting()
    {
        _textlight.text = lightSlider.GetComponent<Slider>().value.ToString("0.00");
        lightControler.intensity = lightSlider.GetComponent<Slider>().value;
    }

    public void resolutionSet()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, false);
    }

    public void musicSet()
    {
        music.volume = audioSlider.GetComponent<Slider>().value * 1f;
        _textaudio.text = audioSlider.GetComponent<Slider>().value.ToString("0.00");
    }

    public void musicSetOn()
    {
        music.mute = !music.mute;
        if (music.mute)
        {
            music.pitch = 0;
        }
        else
        {
            music.pitch = 1f;
        }
        _textaudioon.text = music.mute.ToString().Replace("True", "off").Replace("False", "on");
    }

    public void saveButton()
    {
        _userData.sensivityvalue = sensivitySlider.GetComponent<Slider>().value;
        _userData.lightvalue = lightSlider.GetComponent<Slider>().value;
        _userData.graficvalue = Convert.ToInt32(graficSlider.GetComponent<Slider>().value);
        _userData.dropdownvalue = dropdown.value;
        _userData.musicvalue = music.volume;
        SaveData.SaveUserData(_userData, fileName);
    }
}
