using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiTextValue.text = soInt.Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soInt.Value.ToString();
    }
}
