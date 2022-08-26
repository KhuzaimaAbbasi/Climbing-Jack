using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,130 , 300);
    }
}