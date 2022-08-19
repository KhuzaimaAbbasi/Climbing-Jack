using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Begin;

    void Start()
    {
        Begin.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Begin.onClick.RemoveListener(OnButtonClick);

        Begin.gameObject.SetActive(false);
    }
}

