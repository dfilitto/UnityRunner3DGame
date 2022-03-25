using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;//pos inicial do fundo
    private float repeatWitdh; //largura da tela
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWitdh)
        {
            transform.position = startPos;
        }
    }
}
