using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Change_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public string Level;


    public void Menu()
    {

        SceneManager.LoadScene("Game_Over_Scene");


    }
    public void Change_Level()
    {
        SceneManager.LoadScene(Level);


    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
