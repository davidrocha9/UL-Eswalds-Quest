using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Vector3 startPos, targetPos;
    
    public ParticleSystem ps1;

    public float speed;
    public Vector3 target;
    public float arcHeight;

    Vector3 _startPosition;
    float _stepScale;
    float _progress;


    // start function
    void Start()
    {
        // target is start ten units forward
        target = transform.position + transform.forward * 10;

        _startPosition = transform.position;

        float distance = Vector3.Distance(_startPosition, target);

        // This is one divided by the total flight duration, to help convert it to 0-1 progress.
        _stepScale = speed / distance;

        ps1 = GetComponent<ParticleSystem>();
        ps1.Stop();
    }
    void Update()
    {
        _progress = Mathf.Min(_progress + Time.deltaTime * _stepScale, 1.0f);

        // Turn this 0-1 value into a parabola that goes from 0 to 1, then back to 0.
        float parabola = 1.0f - 4.0f * (_progress - 0.5f) * (_progress - 0.5f);

        // Travel in a straight line from our start position to the target.        
        Vector3 nextPos = Vector3.Lerp(_startPosition, target, _progress);

        // Then add a vertical arc in excess of this.
        nextPos.y += parabola * arcHeight;

        // Continue as before.
        transform.LookAt(nextPos, transform.forward);
        transform.position = nextPos;

        if(_progress == 1.0f)
        {
            // make mesh renderer disappear
            GetComponent<MeshRenderer>().enabled = false;
            // make particle system appear
            ps1.Play();
            // destroy game object after 2 seconds
            Destroy(gameObject, 2);

            // if there is any enemy inside a 5 unit radius of the bomb, destroy it
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "Enemy")
                {
                    Destroy(hitColliders[i].gameObject);
                }
                i++;
            }

            
        }
    }
}
