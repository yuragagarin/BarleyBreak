using System.Collections.Generic;

namespace BOL
{
  public class Field
  {
    public byte Id { get; set; }
    public byte Token { get; set; }
    public Field[] Neighbors { get; set; }
    public Direction Direction { get; set; }
    public bool IsFree { get; set; }

    public Field(byte id)
    {
      Id = id;
    }
  }
}