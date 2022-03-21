using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    Text_ControlSchemeDependentDataSO text_schemeDependent;

    [Header("References")]
    [SerializeField] private TextDataSO text;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text bottomText;

    // Start is called before the first frame update
    void Awake()
    {
        bottomText.gameObject.SetActive(false);
    }

    public void SetTextScheme(Text_ControlSchemeDependentDataSO scheme)
    {
        Debug.Log("Updating text scheme: " + scheme.name);
        text_schemeDependent = scheme;
    }

    public void FlagEnterArea()
    {
        if (bottomText != null)
        {
            Debug.Log("Updating bottom text: " + text_schemeDependent.PickUpFlag_Text);
            bottomText.text = text_schemeDependent.PickUpFlag_Text;
        }
    }
}
