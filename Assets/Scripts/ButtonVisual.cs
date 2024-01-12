using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVisual : MonoBehaviour
{
    [SerializeField] private GameObject defaultVisual;
    [SerializeField] private GameObject pressedVisual;

    private void Start()
    {
        ShowDefault();
    }

    [ProButton]
    public void ShowDefault()
    {
        defaultVisual.SetActive(true);
        pressedVisual.SetActive(false);
    }

    [ProButton]
    public void ShowPressed()
    {
        defaultVisual.SetActive(false);
        pressedVisual.SetActive(true);
    }
}
