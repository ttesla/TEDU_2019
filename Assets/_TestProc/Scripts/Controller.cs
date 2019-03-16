using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Bu static Instance sayesinde Controller nesnesine başka Class (sınıf)'lar içinden 
    // zahmetsize erişebiliriz. Böyle bir kullanım yaparken dikkat etmeniz gereken şey
    // Awake içinde Instance'ı bu nesne 'ye eşitlemeniz gerekli. 
    // Birden fazla sahne içerek oyunlarda, eğer yeni açılan sahnede Controller nesnesi yoksa
    // bu Istance'ı kullanmanız hatalı olacaktır. Çünkü bu nesne artık yok ama statik değişkenler sistemden hiç silinmediği için olmayan bir nesneye erişmenizi sağlamaktadır.
    // C#'da static olarak tanımlanan değişkenler nasıl davranır, nasıl yaratılır
    // biraz araştırma yapmanız faydalı olacaktır. 
    public static Controller Instance;

    public Blue BlueManager;
    public Blue BlueManager2;
    public Red RedManager;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Q ve W 'ye basıldığında çeşitli objelerin Toggle fonksiyonları çağrılıyor
    /// TestController.cs içerisinde de gene aynı nesnelerin Toggle fonksiyonları çağrılıyor
    /// kullanım çeşitliliği olsun diye böyle bir örnek yaptık. 
    /// </summary>
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BlueManager.Toggle();
            BlueManager2.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            RedManager.Toggle();
        }
    }
}
