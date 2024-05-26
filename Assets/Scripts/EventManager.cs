using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<float> onEnemyBorn;
    public static event Action<float> onEnemyDeath;
}
