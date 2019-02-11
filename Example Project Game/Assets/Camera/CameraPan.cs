using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{


    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        print("Rhoriz" + Input.GetAxis("RHoriz"));
        print("RVert" + Input.GetAxis("RVert"));
    }
}
