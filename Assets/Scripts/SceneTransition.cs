using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name);

    }

    public void OpenTrackingStateMonitoring()
    {
        SceneManager.LoadScene("0-TrackingStateMonitoring");
    }
    
    public void OpenPlaceObject()
    {
        SceneManager.LoadScene("1-PlacingObjectAt_LatLngAlt");
    }
    
    public void OpenTapToPlace()
    {
        SceneManager.LoadScene("2-TapToPlace");
    }
    
    public void OpenIntroScene()
    {
        SceneManager.LoadScene("Scenes/IntroTest");
    }

}
