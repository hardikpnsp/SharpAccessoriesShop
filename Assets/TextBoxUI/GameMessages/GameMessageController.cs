using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameMessageController : MonoBehaviour
{
    public TextBoxUI text_preafb_red;
    public TextBoxUI text_preafb_blue;

    public string OnConfidenceUp;
    public string OnConfidenceDown;
    public string OnNotEnoughConfidence;

    public static GameMessageController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ConfidenceController.ConfidenceChanged += ConfidenceController_ConfidenceChanged;
    }

    private void ConfidenceController_ConfidenceChanged(int arg0)
    {
        if(arg0 > 0)
        {
            var text = Instantiate<TextBoxUI>(text_preafb_blue, transform);
            text.SetUp(null, OnConfidenceUp);
            return;
        }

        if(arg0 < 0)
        {
            var text = Instantiate<TextBoxUI>(text_preafb_red, transform);
            text.SetUp(null, OnConfidenceDown);
            return;
        }
    }

    public static void ShowMessage_NotEnoughConfidence()
    {
        if(Instance != null)
        {
           var text = Instantiate<TextBoxUI>(Instance.text_preafb_red, Instance.transform);
            text.SetUp(null, Instance.OnNotEnoughConfidence);
        }
    }


}
