using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail_line : MonoBehaviour
{
    public GameObject player;
    public Material[] materials;

    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
        Movement();
    }

    void Movement()
    {
        transform.position = player.transform.position;
    }

    void ColorChange()
    {
        if(player.tag == "Red")
        {
            rend.sharedMaterial = materials[0];
        }
        else if (player.tag == "Blue")
        {
            rend.sharedMaterial = materials[1];
        }
        else if (player.tag == "Yellow")
        {
            rend.sharedMaterial = materials[2];
        }

    }
}
