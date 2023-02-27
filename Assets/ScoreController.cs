using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    public static ScoreController Instance;

    public TextMeshProUGUI ScoreText;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void OnCustomerServed(Customer customer)
    {
        score += 1;
        ScoreText.text = score.ToString();
    }
}
