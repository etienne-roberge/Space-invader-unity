using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1f;
    Vector2 rawInput;

    [SerializeField] float paddingTop = 1;
    [SerializeField] float paddingBottom = 1;
    [SerializeField] float paddingLeft = 1;
    [SerializeField] float paddingRight = 1;
    Vector2 minBound;
    Vector2 maxBound;

    void Start()
    {
        InitBound();
    }

    void Update()
    {
        Move();
    }

    void InitBound()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector3 delta = rawInput * movementSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
