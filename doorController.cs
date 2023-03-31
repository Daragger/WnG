using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public int id;
    private bool doorOpened = false;
    [SerializeField] private float speed;
    private Quaternion rotation = Quaternion.Euler(0, -60, 0);
    private float timeCount = 0;
    

 
    private void Start()
    {
        
        GameEvents.current.onButtonActivate += OpenDoor;
    }

    private void Update()
    {
        if(doorOpened == true)
        {
            
      
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeCount);
            timeCount += Time.deltaTime*speed;
            
        }

    }

    private void OpenDoor(int id)
    {
        if(id == this.id)
        {
            doorOpened = true;
        }
    }




}
