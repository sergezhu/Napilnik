using System;

namespace Napilnik.Napilnik.P01_Encapculation_Task1
{
    internal class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if(player is null)
                throw new NullReferenceException(nameof(player));
            
            _weapon.TryFire(player, out var fireResult);

            //handle a fireResult
        }
    }
}