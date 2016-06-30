using System;
using System.Collections.Generic;

namespace BOL
{
  public class Game
  {
    Square square;
    Gamer gamer;

    public event EventHandler<MovingEventArgs> Moving;
    public void New()
    {
      square = new Square();
      square.RandomLayout();
      gamer = new Gamer(square);
    }

    public void Move(byte id, Direction direction)
    {
      gamer.Move(id, direction);
      if (Moving != null)
        Moving(this, new MovingEventArgs(square));
    }

    public Square GetSquare()
    {
      return square;
    }
  }
}