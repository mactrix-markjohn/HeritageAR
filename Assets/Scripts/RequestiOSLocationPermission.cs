using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestiOSLocationPermission : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    public void OnEnable()
    {
#if !PLATFORM_ANDROID

    Input.location.Start();
        
#endif
        
        
        
    }

    public void OnDisable()
    {
        
#if !PLATFORM_ANDROID

    Input.location.Stop();
        
#endif
        
        
    }
}
