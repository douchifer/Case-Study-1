using System.Collections;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private bool moveEnabled;
    private float moveSpeed;
    private Vector3 direction;

    void Start()
    {

    }

    void Update()
    {
        MoveBullet();
    }

    virtual public void ResetBullet()
    {
        // Resets bullet to disable its activity
        gameObject.SetActive(false);
        moveEnabled = false;
    }

    virtual public void FireBullet(Vector3 startPos,float speed, Vector3 dir)
    {
        gameObject.SetActive(true);
        moveEnabled = true;

        moveSpeed = speed;
        direction = dir;

        transform.position = startPos;
        transform.LookAt(startPos + dir);

    }

    private void MoveBullet()
    {
        if(!moveEnabled)
            return;

        var moveVec = direction * moveSpeed * Time.deltaTime;
        transform.position += moveVec;

    }

    public void PoolTheBullet(float time) => StartCoroutine(PoolIt(time));
  

    private IEnumerator PoolIt(float time)
    {
        yield return new WaitForSeconds(time);
        EventManager.putBulletToThePool(this);

    }
}
