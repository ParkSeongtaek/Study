using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    float speed = 0.3f;
    float JumpP = 500f;

    bool _W, _A, _S, _D;
    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();

    }

    public bool W { get { return _W; } 
        set {
            if (value) {
                Debug.Log("W = ture");
                _W = true;
                _A = _S = _D = false;
                
            } 
            else
            {
                Debug.Log("W = false");

                _W = false;

            }
        } 
    }
    public bool A
    {
        get { return _A; }
        set
        {
            if (value)
            {
                Debug.Log("A = ture");

                _A = true;
                _W = _S = _D = false;

            }
            else
            {
                Debug.Log("A = false");

                _A = false;

            }
        }
    }
    public bool S { 
        get { return _S; } 
        set {
            if (value) {

                Debug.Log("S = true");
                _S = true;
                _A = _W = _D = false;
                
            } 
            else
            {
                Debug.Log("S = false");

                _S = false;

            }
        } 
    }

    public bool D
    {
        get { return _D; }
        set
        {
            if (value)
            {
                _D = true;
                _A = _W = _S = false;

            }
            else
            {
                _D = false;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter With " + other.name);   
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit With " + other.name);

    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerStay With " + other.name);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter With " + collision.transform.name);

    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit With " + collision.transform.name);

    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("OnTriggerStay With " + collision.transform.name);

    }

    public void MoveUpdateKeyCode()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GameManager.instance.player.transform.position += new Vector3(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GameManager.instance.player.transform.position += new Vector3(-speed, 0, 0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            GameManager.instance.player.transform.position += new Vector3(0, 0, -speed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            GameManager.instance.player.transform.position += new Vector3(speed, 0, 0);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }


    public void MoveUpdateVelocity()
    {

        float XMove = Input.GetAxis("Horizontal");
        float ZMove = Input.GetAxis("Vertical");
        
        if (XMove !=0 || ZMove != 0)
        {
            Debug.Log("XMove " + XMove + "ZMove " + ZMove);
        }

        
        Vector3 getVel = new Vector3(XMove, 0, ZMove) * speed;
        if (getVel != Vector3.zero)
        {
            anim.SetFloat("Speed", 1f);

        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }
        GameManager.instance.player.transform.position += getVel;

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    public void MoveKeyW()
    {
        MoveW();
    }
    public void MoveKeyA()
    {
        MoveA();
    }
    public void MoveKeyS()
    {
        MoveS();

    }
    public void MoveKeyD()
    {
        MoveD();

    }

    public void Jump()
    {
        
        GameManager.instance.player.GetComponent<Rigidbody>().AddForce(transform.up * JumpP);

    }

    void MoveW()
    {
        GameManager.instance.player.transform.position += new Vector3(0, 0, speed);

    }
    void MoveA()
    {
        GameManager.instance.player.transform.position += new Vector3(-speed, 0, 0);

    }
    void MoveS()
    {
        GameManager.instance.player.transform.position += new Vector3(0, 0, -speed);

    }
    void MoveD()
    {
        GameManager.instance.player.transform.position += new Vector3(speed, 0, 0);

    }

    public void W_onoff(bool val)
    {
        W = val;
    }
    public void A_onoff(bool val)
    {
        A = val;
    }
    public void S_onoff(bool val)
    {
        S = val;
    }
    public void D_onoff(bool val)
    {
        D = val;
    }
}
