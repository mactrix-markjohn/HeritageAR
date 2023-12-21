using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class MainPageController : MonoBehaviour
{

    public static HeritagePoint selectedLocation;
    public List<HeritagePoint> heritagePoints;

    // Search List and Near me List
    private List<HeritagePoint> nearMeHeritagePoints;
    private List<HeritagePoint> searchedHeritagePoints;
    
    // Visible List Gameobjects
    private List<GameObject> resultObjectList;
    
    public GameObject scrollerContent;
    public GameObject heritageListItem;

    
    

    



    // Start is called before the first frame update
    void Start()
    {
        nearMeHeritagePoints = new List<HeritagePoint>();
        searchedHeritagePoints = new List<HeritagePoint>();
        resultObjectList = new List<GameObject>();
        
        LoadHeritageNearMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnEnable()
    {
        StartCoroutine(StartLocationService());
    }

    public void HeritageItemClicked(HeritagePoint selectedPoint)
    {
        selectedLocation = selectedPoint;
        // TODO: We will launch a new Scene at this point
        Debug.Log("Heritage List Click");
        SceneManager.LoadScene("PreviewPage");
    }

    void LoadHeritageNearMe()
    {
        SpawnHeritageListItem(heritagePoints);
    }


    void SpawnHeritageListItem(List<HeritagePoint> HeritageList)
    {

        foreach (var heritage in HeritageList)
        {
            
            GameObject heritageObject = Instantiate(heritageListItem, scrollerContent.transform, false);

            heritageObject.GetComponent<HeritageItem>().Setup(heritage,100,this);
            
            resultObjectList.Add(heritageObject);
            
        }
        
        
        
    }











    private IEnumerator StartLocationService()
    {
        
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Debug.Log("Requesting the fine location permission.");
            Permission.RequestUserPermission(Permission.FineLocation);
            yield return new WaitForSeconds(3.0f);
        }
#endif

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location service is disabled by the user.");
            
            yield break;
        }

        Debug.Log("Starting location service.");
        Input.location.Start();

        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return null;
        }

        
        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.LogWarningFormat(
                "Location service ended with {0} status.", Input.location.status);
            Input.location.Stop();
        }
    }


    public void HelpDocClick() {

        SceneManager.LoadScene("HelpDocumentation");
    }
}
