using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles displaying the bars of stamina and hp of player.
 * Not the best design, but it works.
 * TODO: Refactor this to be more generic and reusable.
 */
[RequireComponent(typeof(Slider))]
public class UI_EntityBarDisplayController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private StatsHandler statsHandler;
    [SerializeField] private BarType barType;

    [SerializeField] private bool shouldDisplayTextValues;
    [SerializeField] private TextMeshProUGUI textDisplay;


    // Determines whether the slider displays health or stamina values.
    protected enum BarType
    {
        Health,
        Stamina
    }

    private void Awake()
    {
        slider = GetComponent<Slider>();

        if (statsHandler == null)
        {
            Debug.LogWarning("Need to Assign a StatsHandler to " + gameObject.name + " in order to display health/stamina bars.");
        }
            
    }

    private void Start()
    {
        UpdateUI();
        statsHandler.OnStatChange += UpdateUI;
    }

    private void UpdateUI()
    {
        UpdateSlider();
        UpdateText();
    }

    private void UpdateSlider()
    {
        switch (barType)
        {
            case BarType.Health:
                slider.maxValue = statsHandler.GetStats().GetStatValue(Stats.Stat.maxHealth);
                slider.value = statsHandler.GetStats().GetStatValue(Stats.Stat.curHealth);
                break;
            case BarType.Stamina:
                slider.maxValue = statsHandler.GetStats().GetStatValue(Stats.Stat.maxStamina);
                slider.value = statsHandler.GetStats().GetStatValue(Stats.Stat.curStamina);
                break;
        }
    }

    private void UpdateText()
    {
        if (shouldDisplayTextValues)
        {
            textDisplay.gameObject.SetActive(true);
            textDisplay.text = slider.value + "/" + slider.maxValue;
        } else
        {
            textDisplay.gameObject.SetActive(false);
        }
       
    }
}


