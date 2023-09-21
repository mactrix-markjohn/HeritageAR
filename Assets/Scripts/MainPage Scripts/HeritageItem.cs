using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeritageItem : MonoBehaviour
{
    public TextMeshProUGUI heritageName;
    public TextMeshProUGUI distance;

    private HeritagePoint point;
    private MainPageController mainController;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(HeritagePoint pointer, float distanceNum, MainPageController controller)
    {

        heritageName.text = pointer.name;
        distance.text = $"{distanceNum} km";
        
        mainController = controller;
        point = pointer;


    }

    public void HandleClick()
    {
        mainController.HeritageItemClicked(point); 
    }
}
