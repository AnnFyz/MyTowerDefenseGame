using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;

    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " Lives";
    }
}
