using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Transform kullanarak yapacağınız bir çok kullanım örneği burda mevcut.
/// </summary>
public class Movement : MonoBehaviour
{
    public float Speed;
    public float Duration;
    public Transform Target;
    public AnimationCurve AnimCurve;

    private Vector3 mStartPos;
    private float mTime = 0;

    private void Start()
    {
        mStartPos = transform.position;
    }

    void Update ()
    {
        //NormalMovement();
        //Interpolated();
        AnimCurved();
    }

    /// <summary>
    /// Bizim belirlediğimiz animasyon eğrisi kullanarak hareket.
    /// </summary>
    void AnimCurved()
    {
        var val = AnimCurve.Evaluate(mTime);
        transform.position = Vector3.Lerp(mStartPos, Target.position, val);

        mTime += Time.deltaTime / Duration;
    }

    /// <summary>
    /// Lineer interpolasyon (düz ve sabit eğrili) hareket kullanımı.
    /// </summary>
    void Interpolated()
    {
        //transform.position = Vector3.Lerp(transform.position, Target.position, Duration);
        transform.position = Vector3.Lerp(mStartPos, Target.position, mTime);

        // Her iki kullanım da makul. Birinde kaç Duration kaç saniyede gitmesi gerektiğini belirtiyor
        // diğerinde Hız çarpanı olarak işlev görüyor. 10 saniyede gitsin dersek = 1 / 10 veya  0.1 ile çarp gibi.

        //mTime += Time.deltaTime * Duration;
        mTime += Time.deltaTime / Duration;
    }

    /// <summary>
    /// Doğrudan transform'un pozisyon vektörünü değiştirerek hareket. 
    /// Bir de direction kullanmışız. Karışık geliyorsa, transform.position'u değiştiren küçük örnekler deneyip
    /// tam olarak nasıl çalıştığını anlayabilirsiniz. Burdaki position "World Position" 'dur. İsteğe göre "Local Position"'u da değiştirebilirsiniz.
    /// Unutmamak gerekir ki, bir nesne ağaç yapısı olarak en Root'da ise yani hiç bir şeyin Child'ı değilse, World Position ve Local Position aynı değeri gösterir. 
    /// </summary>
    void NormalMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //transform.position += new Vector3(x, 0, y) * Time.deltaTime * Speed;

        //Vector3.left
        transform.position += transform.right * x * Time.deltaTime * Speed;
        transform.position += transform.forward * y * Time.deltaTime * Speed;


        Vector3 dir = (Target.position - transform.position).normalized;

        transform.position += dir * Speed * Time.deltaTime;

        // += 'i bizim yerimize yapan Unity'i metodu.
        //transform.Translate()
    }
}
