using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueChange : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Slider slider2;
    [SerializeField] float protonVal;
    [SerializeField] float neutronVal;

    private void Start()
    {
        // Add a click event listener to the button.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeSliderValueTo);
    }

    private void ChangeSliderValueTo()
    {
     
        slider.value = protonVal;
        slider2.value = neutronVal;
    }
}

