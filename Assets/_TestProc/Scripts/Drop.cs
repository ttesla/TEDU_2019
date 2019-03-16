using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject BallPrefab;

	/// <summary>
    /// Her space'e basıldığında bir BallPrefab yaratıyoruz. Drop.cs'in bağlı olduğu DropPosition nesnesi Editörde kapalı,
    /// bu script'in çalışabilmesi için önce onu Editör'den açmanız gerekli.
    /// </summary>
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(BallPrefab, transform.position, Quaternion.identity);
        }
	}
}
