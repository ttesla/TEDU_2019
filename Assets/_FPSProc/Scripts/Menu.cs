using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Sahne üzerine yerleştirilmiş, çeşitli Button ve dinamik içeriği kullanmak için örnekler içerir. 
/// </summary>
public class Menu : MonoBehaviour
{
    public Button TestButton;
    public AudioClip ButtonSfx;

    public DynamicPanel Panel;

    private AudioSource mSource;

    private void Awake()
    {
        mSource = GetComponent<AudioSource>();
        TestButton.onClick.AddListener(OnButtonClick);

        //TestButton.onClick.AddListener(()=> 
        //{
        //    Debug.Log("On Button Pressed");
        //    int a = 0;
        //    a++;

        //});
    }

    //private void OnDestroy()
    //{
    //    TestButton.onClick.RemoveAllListeners();
    //}

    public void OnButtonClick()
    {
        Panel.Open();
        Debug.Log("Button clicked");

        mSource.PlayOneShot(ButtonSfx);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
