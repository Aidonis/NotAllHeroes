using UnityEngine;
using System.Collections;

namespace TDShooter
{
    public interface IDamageable
    {

        void TakeHit(float damage, RaycastHit hit);
        void TakeDamage(float damage);

    }
}