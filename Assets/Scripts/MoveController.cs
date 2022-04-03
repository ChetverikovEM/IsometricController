using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private const float MoveSpeed = 1f;
    private Animator _mAnimController;
    private static readonly int PlayerMove = Animator.StringToHash("PlayerMove");

    // Start is called before the first frame update
    void Start()
    {
        _mAnimController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Camera.main != null)
        {
            var x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x-transform.position.x;
            var localScale = transform.localScale;
            localScale = new Vector3(x<0?-1:1,localScale.y, localScale.z);
            transform.localScale = localScale;
        }

    }

    private void MovePlayer()
    {
        var position = transform.position;
        var mVertical = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;
        var mHorizontal= Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
        _mAnimController.SetBool(PlayerMove, (mVertical != 0 || mHorizontal != 0)?true:false);
        position =new Vector2(position.x + mHorizontal, position.y + mVertical);
        
        transform.position = position;
    }
    
    private void FixedUpdate()
    {
        
    }
}
