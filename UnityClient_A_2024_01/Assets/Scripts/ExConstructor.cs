using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExConstructor : MonoBehaviour
{
    private int value;
    
    public ExConstructor(int _value)
    {
        value = _value;
        Debug.Log("객체가 생성 되었습니다 . 초기값 : " + value);
    }

    void Start()
    {
        ExConstructor ex = new ExConstructor(10);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        Debug.Log("객체가 파괴되었습니다."); 
    }

}
