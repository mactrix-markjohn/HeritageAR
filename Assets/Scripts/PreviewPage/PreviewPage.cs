using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreviewPage : MonoBehaviour
{

    private HeritagePoint heritagePoint;

    public TextMeshProUGUI locationName;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI historyDetail;
    public Image previewImage;
    





    // Start is called before the first frame update
    void Start()
    {
        heritagePoint = MainPageController.selectedLocation;
        locationName.text = heritagePoint.name;
        historyDetail.text = heritagePoint.history;

        StartCoroutine(LoadImageFromUrl(heritagePoint.imageUrls[0]));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackHomeButton()
    {
        SceneManager.LoadScene("MainPage");
    }

    public void OpenARViewClicked() {

        // TODO: We will launch a new Scene at this point
        Debug.Log("Heritage List Click");
        SceneManager.LoadScene("HeritageAR");
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
            previewImage.sprite = sprite;
           

        }
        else
        {
            // Log an error message
            Debug.LogError("Failed to load image: " + request.error);
        }
    }

}
