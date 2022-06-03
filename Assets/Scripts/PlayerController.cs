using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform first;

    [SerializeField]
    private Transform obj;

    private Vector3 second;
    public bool stop;

    private void Start()
    {
        second = new Vector3(obj.position.x, obj.position.y, obj.position.z);
    }

    private void Update()
    {     
        if(first.position.x != second.x)
        {
            Dist();
        }
        else
        {
            stop = true;
        }
    }

    public void Dist()
    {

        first.position = Vector3.MoveTowards(first.position, second, Time.deltaTime * 600f);

    }
}
