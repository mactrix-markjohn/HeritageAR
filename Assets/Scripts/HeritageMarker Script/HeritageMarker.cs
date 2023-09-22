using System.Collections;
using System.Collections.Generic;
using MPUIKIT;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HeritageMarker : MonoBehaviour
{
    public Text PointName;
    public Text PointHistory;
    public Image PointIcon;


    private HeritagePoint point;
    private ARVPSController vpsController;

    public GameObject imageScrollerContainer;
    public GameObject oldPicturePrefab;

    public Sprite museum;
    public Sprite department;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setup(HeritagePoint heritagePoint, ARVPSController arvpsController)
    {

        PointName.text = heritagePoint.name;
        PointHistory.text = heritagePoint.history;

        if (heritagePoint.name.ToLower().Contains("museum"))
        {
            PointIcon.sprite = museum;
        }
        else
        {
            PointIcon.sprite = department;
        }
        
        // Fill up the images

        foreach (var imageUrl in heritagePoint.imageUrls)
        {
            FillOldImages(imageUrl);
        }


    }


    void FillOldImages(string imageurl)
    {
        StartCoroutine(LoadImageFromUrl(imageurl));

    }
    
    IEnumerator LoadImageFromUrl(string imageUrl)
    {
        // Create a UnityWebRequest to get the image data
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        // Check if the request was successful
        if (request.result == UnityWebRequest.Result.Success)
        {
            // Get the texture from the request
            Texture2D texture = DownloadHandlerTexture.GetContent(request);

            // Create a sprite from the texture
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // Set the sprite to the image UI element
            GameObject OldImageObject = Instantiate(oldPicturePrefab, imageScrollerContainer.transform);
            OldImageObject.GetComponent<MPImage>().sprite = sprite;
            
        }
        else
        {
            // Log an error message
            Debug.LogError("Failed to load image: " + request.error);
        }
    }
}
