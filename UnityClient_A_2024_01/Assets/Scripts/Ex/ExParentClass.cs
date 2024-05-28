using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour
{
    protected int protectedValue;
}

public class ExChildClass : ExParentClass
{
    private void Start()
    {
        Debug.Log("Protected Value from Child Class : " + protectedValue);
    }
}
