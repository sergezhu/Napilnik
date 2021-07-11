using System;
using System.Collections.Generic;

namespace Napilnik.Napilnik.P01_Encapculation_Task1
{
    internal class Weapon
    {
        private readonly int _damage;
        private readonly int _capacity;
        private readonly int _bulletsPerShot;
        private readonly List<FireResult> _fireResult;
        private int _bullets;

        public Weapon(int damage, int capacity, int bulletsPerShot)
        {
            _damage = damage;
            _capacity = capacity;
            _bulletsPerShot = bulletsPerShot;

            _fireResult = new List<FireResult>();
        }

        public bool TryFire(IDamageable damageable, out FireResult[] fireResult)
        {
            if(damageable is null)
                throw new NullReferenceException(nameof(damageable));

            var canFire = CanFire();

            fireResult = (new List<FireResult>(_fireResult)).ToArray();

            if (canFire)
                DoFire(damageable);

            return canFire;
        }

        public bool CanFire()
        {
            _fireResult.Clear();

            if (HasBullets() == false)
                _fireResult.Add(FireResult.NotEnoughBullets);

            if (IsNotBrocken() == false)
                _fireResult.Add(FireResult.IsBrocken);

            return _fireResult.Count == 0;
        }

        public bool HasBullets()
        {
            return _bullets >= _bulletsPerShot;
        }

        public bool IsNotBrocken()
        {
            //some implementation
            return true;
        }

        public void Reload()
        {
            _bullets = _capacity;
        }

        private void DoFire(IDamageable damageable)
        {
            damageable.AcceptDamage(_damage);
            _bullets -= _bulletsPerShot;
        }
    }
}