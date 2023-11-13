using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerMovements PlayerMovements;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text HealthText;
    public TMP_Text BigBooletText;
    public TMP_Text KeysText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sets the text screen as (Score: ) + total score
        scoreText.text = "Score: " + PlayerMovements.totalScore.ToString();
        livesText.text = "Lives: " + PlayerMovements.Lives.ToString();
        HealthText.text = "Health: " + PlayerMovements.PHP.ToString();
        BigBooletText.text = "BigBoolets: " + PlayerMovements.BigBoolets.ToString();
        KeysText.text = "Keys: " + PlayerMovements.goldKeysCollected.ToString();
    }
}
