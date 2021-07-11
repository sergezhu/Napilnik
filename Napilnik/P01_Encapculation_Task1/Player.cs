using System;

namespace Napilnik.Napilnik.P01_Encapculation_Task1
{
    internal class Player : IDamageable
    {
        public event Action Dead;
        
        private int _health;
        public Player(int health)
        {
            _health = health;
        }
        public void AcceptDamage(int damageValue)
        {
            if(IsDead())
                throw new Exception($"Player is dead already");
            
            if(damageValue < 0)
                throw new ArgumentOutOfRangeException($"Incoming damage must be greater than zero");
            
            
            _health -= damageValue;

            if (IsDead())
            {
                _health = 0;
                Dead?.Invoke();
            }
        }

        public bool IsDead()
        {
            return _health <= 0;
        }
    }
}