using UnityEngine;
using UnityEngine.UI;

public class RelationBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateSliderValue(float value)
    {
        value = Mathf.Clamp01(value);
        slider.value = value;
    }
}