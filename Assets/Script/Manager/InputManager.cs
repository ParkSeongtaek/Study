using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    public void Init()
    {
        //�ʱ� ��
        //������ ������ ������ �ҷ����� ���
        //�� ���⼭ ���� Start ���� �ʴ°�?
        //: MonoBehaviour �� ����!
    
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
