using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour, ITick
{
    private void Awake()
    {
        ManagerUpdate.AddTo(this);
    }

    public void Tick()
    {
        float x = 2*Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.right* x * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {          
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*100);
        }

    }
}
