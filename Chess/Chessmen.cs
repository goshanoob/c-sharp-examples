using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    internal abstract class Chessmen
    {
        public string Position { get; set; }
        public abstract void Move(string newPosition);
        public abstract bool СheckMovePossibility(string newPosition);

    }

    internal class Pawn: Chessmen
    {
        public Pawn()
        {
            Position = "a1";
        }
        public override void Move(string newPosition)
        {

            Position = newPosition;
        }

        public override bool СheckMovePossibility(string newPosition)
        {
            
            return true;
        }
    }
}
