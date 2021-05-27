using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mehroz;
using System.Threading;
using System.Globalization;

[RequireComponent(typeof(TMP_Text))]
public class GearRatioText : MonoBehaviour
{
    [SerializeField]
    private bool displayRatioAsFraction = true; 
    [SerializeField]
    private Gear gear = null;
    private TMP_Text text = null;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
    }

    private void Update()
    {
        if (displayRatioAsFraction)
        {
            if (Thread.CurrentThread.CurrentCulture.Name == "de-DE")
            {
                try
                {
                    // cheats
                    float roundedRelativeSpeed = Mathf.Round((gear.RelativeSpeed + .05f) * 5f) / 5f;
                    Fraction fraction = new Fraction(roundedRelativeSpeed);
                    text.text = fraction.ToString();
                }
                catch (FractionException)
                {
                    text.text = gear.RelativeSpeed.ToString("0.0");
                }
            }
        }
        else
        {
            text.text = gear.RelativeSpeed.ToString("0.0");
        }
    }
}
