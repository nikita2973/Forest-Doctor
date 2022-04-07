using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _dir;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private float _lineDistance = 1;

    private int _lineToMove = 1;

    private const float MAXSPEED = 20;

    private void Start()
    {
        Time.timeScale = 1;
        _controller = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
    }

    #region Getting Bonuses
    public void ChangeSpeed(float minusProcent)
    {
        Debug.Log("old speed " + _speed);
        _speed =_speed-( _speed * (minusProcent / 100));
        Debug.Log("new speed " + _speed);
    }

    public void ChangeJumpForce(float plusProcent)
    {
        _jumpForce = _jumpForce+( _jumpForce * (plusProcent / 100));
    }
    #endregion

    #region Character Moving Controll
    private void Update()
    {if(Time.timeScale!=0)
        if (SwipeController.swipeRight)
        {
            if (_lineToMove < 2)
            {
                _lineToMove++;
            }
        }
        if (SwipeController.swipeLeft)
        {
            if (_lineToMove > 0)
            {
                _lineToMove--;
            }
        }
        if (SwipeController.swipeUp)
        {
            if (_controller.isGrounded)
            {
                Jump();
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (_lineToMove == 0)
        {
            targetPosition += Vector3.left * _lineDistance;

        }
        else if (_lineToMove == 2)
        {
            targetPosition += Vector3.right * _lineDistance;
        }
        if (transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            _controller.Move(moveDir);
        }
        else
        {
            _controller.Move(diff);
        }

    }

    private void Jump()
    {
        _dir.y = _jumpForce;
    }

    private void FixedUpdate()
    {
        _dir.z = _speed;
        _dir.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_dir * Time.fixedDeltaTime);
    }
    #endregion

    private IEnumerator SpeedIncrease()
    {
        while (_speed < MAXSPEED)
        {
            yield return new WaitForSeconds(4);
            _speed += 1f;
        }
    }
}
