using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Gamer
    {
      Square square;

      public Gamer(Square square)
      {
        this.square = square;
      }
      public void Move(byte id, Direction direction)
      {
        square.MoveToken(id, direction);
      }
    }
}
