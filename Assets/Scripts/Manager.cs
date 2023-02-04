using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    public GameManager GameManager;
    private void Awake()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>().Instance;
    }

}
