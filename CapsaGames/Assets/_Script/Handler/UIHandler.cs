using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Canvas canvasSetup;

    [SerializeField]
    private Button completeSetupBtn;
    [SerializeField]
    private Text firstLineTxt;
    [SerializeField]
    private Text secondLineTxt;
    [SerializeField]
    private Text thirdLineTxt;

    public Button completeBtn()
    {
        return completeSetupBtn;
    }

    public void SetFirstText(string text)
    {
        firstLineTxt.text = text;
    }

    public void SetSecondText(string text)
    {
        secondLineTxt.text = text;
    }

    public void SetThirdText(string text)
    {
        thirdLineTxt.text = text;
    }
}
