﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermAnimation : MonoBehaviour
{

    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y - speed * Time.deltaTime);
    }
}
