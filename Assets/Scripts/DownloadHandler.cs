using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadHandler : MonoBehaviour
{
    public RawImage marker;
    public Button downloadButton;
    public GameObject avvisoDownload;

    private void Start()
    {
        downloadButton.enabled = true;
        avvisoDownload.SetActive(false);
    }

    public void DownloadMarker()
    {
        StartCoroutine(TakeMarker());
    }

    private IEnumerator TakeMarker()
    {
        yield return new WaitForEndOfFrame();

        // Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Texture2D ss = new Texture2D(Screen.width, Screen.height * 3 / 4, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, Screen.height - (Screen.height * 3 / 4), Screen.width, Screen.height * 3 / 4), 0, 0);
        ss.Apply();

        // Texture2D ss = ToTexture2D(marker.texture);

        // Save the screenshot to Gallery/Photos
       NativeGallery.SaveImageToGallery(ss, "BattleTankAR", "Marker {0}.png");

        // To avoid memory leaks
        Destroy(ss);
    }

    public void UpdateButton()
    {
        downloadButton.enabled = false;
        avvisoDownload.SetActive(true);
    }

    private Texture2D ToTexture2D(Texture texture)
    {
        return Texture2D.CreateExternalTexture(
            texture.width,
            texture.height,
            TextureFormat.RGB24,
            false, false,
            texture.GetNativeTexturePtr());
    }

    public void TogliAvviso()
    {
        avvisoDownload.SetActive(false);
        downloadButton.enabled = true;
    }


}
