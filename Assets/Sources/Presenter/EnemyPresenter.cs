using Asteroids.Model;
using System.Collections;
using UnityEngine;

public class EnemyPresenter : Presenter
{
    private Transformable _transform;
    private Transformable _target;

    public void Init(Transformable transform, Transformable target)
    {
        _transform = transform;
        _target = target;
        StartCoroutine(CheckHit());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyCompose();
        }
    }

    private IEnumerator CheckHit()
    {
        while (true)
        {
            if (Vector3.SqrMagnitude(_target.Position - _transform.Position) < 0.001f)
            {
                DestroyCompose();
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
