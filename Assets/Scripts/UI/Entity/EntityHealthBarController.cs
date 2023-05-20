using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EntityHealthBarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private StatsHandler statsHandler;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        statsHandler = GetComponentInParent<StatsHandler>();
    }

    private void Start()
    {
        slider.maxValue = statsHandler.GetStats().GetStatValue(Stats.Stat.maxHealth);
        slider.value = statsHandler.GetStats().GetStatValue(Stats.Stat.curHealth);

        statsHandler.OnStatChange += UpdateSlider;
    }
    
    private void UpdateSlider()
    {
        slider.maxValue = statsHandler.GetStats().GetStatValue(Stats.Stat.maxHealth);
        slider.value = statsHandler.GetStats().GetStatValue(Stats.Stat.curHealth);
    }


}
