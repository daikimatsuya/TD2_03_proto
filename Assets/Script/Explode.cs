using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    Transform tf;

    private Vector3 pos;
    public float limit;
    private void Explosion()
    {
        tf.position = pos;
        tf.localScale = new Vector3(tf.localScale.x + 0.2f, tf.localScale.y + 0.2f, tf.localScale.z + 0.2f);
        tf.rotation = Quaternion.Euler(tf.rotation.x, tf.rotation.y + 3, tf.rotation.z);
        limit--;
        if (limit < 0)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tf= GetComponent<Transform>();  
        pos = tf.position;
        limit *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        Explosion();
    }
}
