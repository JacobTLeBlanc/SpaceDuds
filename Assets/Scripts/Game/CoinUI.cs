using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text coinAmount; // Get Text UI

    // Start is called before the first frame update
    void Start()
    {
        coinAmount.text = SaveLoad.data.totalCoins.ToString(); // Set Text to Highscore
    }

}
