using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    Health playerHealth;
    [SerializeField] Slider healthSlider;

    [Header("Score")]
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }
}
