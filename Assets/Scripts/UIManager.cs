using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Slider sldPlayerHealth;

    // Ensure the instance is set up as early as possible. 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != this) 
        {
            Debug.LogError("UIManager instance is not assigned correctly.");
        }
    }

    public void UpdatePlayerHealthSlider(float percentage) 
    {
        if (sldPlayerHealth != null)
        {
            sldPlayerHealth.value = percentage;
        }
        else 
        {
            Debug.LogError("Health slider is not assigned in the UIManager.");
        }   
    }
}
