using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class buttonInteract : MonoBehaviour
{
    public int id;
    private Vector3 button;
    private bool pressed = false;
    private float maxPosY;
    private float minPosY;
    [SerializeField] private float speed;



    [SerializeField] private float maxDeltaY;

    [SerializeField] private float pressTime = 3f;
    private float pressTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        maxPosY = transform.position.y;
        minPosY = transform.position.y - maxDeltaY;
    }

    // Update is called once per frame
    void Update()
    {

        button = transform.position;
        animateButton();
        
    }

    public void animateButton()
    {
        if (pressed)
        {
            if (pressTimer >= pressTime)
            {
                pressed = false;
                pressTimer = 0;
            }
            else
            {
                pressTimer += Time.deltaTime;
            }
            button.y -= speed * Time.deltaTime;

            if (button.y < minPosY)
            {
                button.y = minPosY;

            }

            transform.position = button;

        }
        else
        {
            button.y += speed * Time.deltaTime;

            if (button.y > maxPosY)
            {
                button.y = maxPosY;

            }

            transform.position = button;

        }
    }

    public void Pressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            pressed = true;
            GameEvents.current.ButtonActivate(id);
        }        
    }
   
}
