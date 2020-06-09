using System.Collections;
using System.Collections.Generic;

namespace Tfi
{
    public class Position
    {
        public readonly int x;
        public readonly int y;


        public Position(int absc, int ord) {
            this.x = absc;
            this.y = ord;
        }

        public override string ToString(){
            return "x: " + x + " y: " + y;
        }


    
        /*public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Position position = (Position) o;
            return x == position.x &&
                   y == position.y;
        }*/

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Position p = (Position) obj;
                return (x == p.x) && (y == p.y);
            }
        }
    }
}

