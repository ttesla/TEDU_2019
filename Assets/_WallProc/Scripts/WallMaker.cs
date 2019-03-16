using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    public GameObject BrickPrefab;
    public int Xcount;
    public int YCount;
    public Transform WallParent;
	
	void Start ()
    {
        GenerateWall();
	}
    
    private void GenerateWall()
    {
        float xScale = BrickPrefab.transform.localScale.x + 0.01f;
        float yScale = BrickPrefab.transform.localScale.y + 0.00f;

        for (int y = 0; y < YCount; y++)
        {
            for(int x = 0; x < Xcount; x++)
            {
                GameObject brick = GameObject.Instantiate(BrickPrefab, WallParent);

                //float offset = y % 2 == 0 ? 0 : xScale / 2.0f;

                float offset = 0;

                if(y % 2 == 0)
                {
                    offset = 0;
                }
                else
                {
                    offset = xScale / 2.0f;
                }

                brick.transform.localPosition = new Vector3(x * xScale + offset, y * yScale, 0.0f);
            }
        }
    }
}
