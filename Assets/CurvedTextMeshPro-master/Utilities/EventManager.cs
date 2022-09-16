using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnClick = new UnityEvent();
    public static UnityEvent OnFirstCountDownEnded = new UnityEvent();
    public static UnityEvent OnSecondCountDownEnded = new UnityEvent();
    public static UnityEvent OnMoneyEarned = new UnityEvent();

    
    
}
