using System;

namespace BOL
{
  public class MovingEventArgs : EventArgs
  {
    public Square Square { get; private set; }

    public MovingEventArgs(Square square)
    {
      Square = square;
    } 
  }
}