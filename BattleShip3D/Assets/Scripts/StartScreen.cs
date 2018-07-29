using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {

    // Use this for initialization
    public GameObject button;
    public TextMeshProUGUI text;
    public GameObject image;

    public void buttonpress()

    {
        button.GetComponentInChildren<Text>().text = "Ready!";
        button.SetActive(false);
        text.text = "";
        image.SetActive(false);

    }
}
