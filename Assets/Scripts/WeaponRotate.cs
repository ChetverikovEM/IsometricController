using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponRotate : MonoBehaviour
{
    [SerializeField] private Sprite [] mSprite;
    [SerializeField] private SpriteRenderer mSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {
            var mTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mDirection = mTarget - transform.position;
            var mAngle = Vector2.Angle(transform.up, mDirection);
            //Debug.Log(mAngle);
            if (mAngle >= 0 && mAngle < 10) mSpriteRenderer.sprite = mSprite[0];
            if (mAngle >= 10 && mAngle < 80) mSpriteRenderer.sprite = mSprite[1];
            if (mAngle >= 80 && mAngle < 110) mSpriteRenderer.sprite = mSprite[2];
            if (mAngle >= 110 && mAngle < 170) mSpriteRenderer.sprite = mSprite[3];
            if (mAngle >= 170 && mAngle < 180) mSpriteRenderer.sprite = mSprite[4];
            
            var x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x-transform.position.x;
            var localScale = transform.localScale;
            localScale = new Vector3(x<0?-1:1,localScale.y, localScale.z);
            transform.localScale = localScale;
        }
    }
}
