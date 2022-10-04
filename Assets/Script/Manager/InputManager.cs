using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    public void Init()
    {
        //초기 셋
        //보통은 저장한 데이터 불러오기 등등
        //왜 여기서 따로 Start 하지 않는가?
        //: MonoBehaviour 을 빼서!
    
    }


    public void InputUpdate()
    {
        if (GameManager.instance.player != null)
        {
            //GameManager.instance.player.GetComponent<PlayerController>().MoveUpdateKeyCode();
            GameManager.instance.player.GetComponent<PlayerController>().MoveUpdateVelocity();

        }
    }

}
