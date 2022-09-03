using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collecting : MonoBehaviour
{
    // Start is called before the first frame update

    string Coinkey;

    public int Current_Score { get; set; }

    private void Awake()
    {
        Current_Score = PlayerPrefs.GetInt(Coinkey);
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(Coinkey, score);


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
