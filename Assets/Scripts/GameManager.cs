using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
   
    [SerializeField] private Bamboo _bamboo;
    [SerializeField] private Transform _initalPosition;

    public void CreateBamboo()
    {
        Instantiate(_bamboo);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
       
    }
}
