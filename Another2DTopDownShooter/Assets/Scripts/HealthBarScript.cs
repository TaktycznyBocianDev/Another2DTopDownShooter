using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    public Slider slider;

    // Function to set the maximum health value of the slider
    public void SetMAXHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealt(float health)
    {
        slider.value = health;
    }

    public void AddHealth(float health)
    {
        // If adding the given health value would cause the slider value to exceed the maximum value, set the value to the maximum
        // Otherwise, just add the given health value to the current value of the slider
        if ((slider.value += health) > slider.maxValue)
        {
            SetMAXHealth(slider.maxValue);
        }
        else
        {
            slider.value += health;
        }
    }

}
