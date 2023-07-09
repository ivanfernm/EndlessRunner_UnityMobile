using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera MainCam;
    Animator _animator;
    Vector3 colliderPosition;
    private IMoveCommand _Movement;


    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
        _Movement = new ChangePosition(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (StaticVar.CanMove == true)
        {
           if (Input.touchCount > 0)
           {
                Touch touch = Input.GetTouch(0);
                Ray ray = MainCam.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    colliderPosition = hit.collider.transform.position;

                   gameObject.transform.position = new Vector3(colliderPosition.x,gameObject.transform.position.y,gameObject.transform.position.z);
                   //_Movement.SetTranform(hit.collider.transform).Execute();
                   if (transform.position.x < colliderPosition.x)
                   {
                       StartCoroutine(DoAnimation("TurnRight"));
                   }
                   else
                   {
                       StartCoroutine(DoAnimation("TurnLeft"));
                   }

                }
               
            }

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                
                // Debug.Log("Mouse");
                Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);  
                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    colliderPosition = hit.collider.transform.position;
                    if (transform.position.x < colliderPosition.x)
                    {
                        StartCoroutine(DoAnimation("TurnRight"));
                    }
                    else
                    {
                        StartCoroutine(DoAnimation("TurnLeft"));
                    }
                    gameObject.transform.position = new Vector3(colliderPosition.x,gameObject.transform.position.y,gameObject.transform.position.z);
                  
                }
            }
#endif     
          
        }

        IEnumerator DoAnimation(string animationName)
        {
            _animator.SetBool(animationName,true);   
            yield return new WaitForSeconds(1f);
            _animator.SetBool(animationName,false);
        }


    }

}