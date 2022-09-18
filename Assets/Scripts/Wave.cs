using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wave : MonoBehaviour
{
    [SerializeField] private Animator _animator;



    private Character_Animation_Controller _animationcontroller;

    void Start()
    {

        _animationcontroller = new Character_Animation_Controller(_animator);

        PlayWaveAnimation();



        Invoke("Load_Scene_GameOver", 10f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayWaveAnimation() => _animationcontroller.PlayAnimation(Types.Wave);


    private void Load_Scene_GameOver()
    {
        SceneManager.LoadScene("Game_Over_Scene");





    }

}
