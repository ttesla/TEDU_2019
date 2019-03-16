using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPanel : MonoBehaviour
{
    public Transform ContentParent;
    public GameObject ContentPrefab;

    public void Open()
    {
        gameObject.SetActive(true);
        GenerateContent();
    }

    private void GenerateContent()
    {
        for(int i = 0; i < 9; i++)
        {
            GameObject.Instantiate(ContentPrefab, ContentParent);
        }
    }

    private void ClearContent()
    {
        //ContentParent.childCount
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

}
