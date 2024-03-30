using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKillMePls : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
