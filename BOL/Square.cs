using System;
using System.Collections.Generic;
using System.Linq;

namespace BOL
{
  public class Square
  {
    private List<Field> fields = new List<Field>();

    public Square()
    {
      Prepare();
    }

    public void RandomLayout()
    {
      List<byte> tokens = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
      foreach (var field in fields)
      {
        if (fields.LastOrDefault().Equals(field))
        {
          field.IsFree = true;
          break;
        }
        Random r = new Random();
        byte i = Convert.ToByte(r.Next(0, tokens.Count - 1));
        field.Token = tokens[i];
        tokens.RemoveAt(i);
      }
      int lastr = 15;
      fields[lastr].IsFree = true;
      fields.SelectMany(x => x.Neighbors).Where(x => x.Id == fields[lastr].Id).ToList().ForEach(x=>x.IsFree=true);
    }

    public List<Field> GetFields()
    {
      return fields;
    }

    public void MoveToken(byte id, Direction direction)
    {
      var curField = fields.FirstOrDefault(x => x.Id == id);
      var aimField = curField.Neighbors.FirstOrDefault(x => x.Direction == direction && x.IsFree);

      if (aimField == null)
      {
        Console.WriteLine("Неверный ход!");
        return;
      }
      fields.FirstOrDefault(x => x.IsFree).Token = curField.Token;
      fields.SelectMany(x => x.Neighbors).Where(x => x.Id == aimField.Id).ToList().ForEach(x => x.IsFree = false);
      fields.FirstOrDefault(x => x.IsFree).IsFree = false;
      curField.Token = 0;
      fields.SelectMany(x => x.Neighbors).Where(x => x.Id == curField.Id).ToList().ForEach(x => x.IsFree = true);
      fields.FirstOrDefault(x => x.Id == curField.Id).IsFree = true;
    }

    private void Prepare()
    {
      #region 1-ая линия
      fields.Add(new Field(1)
      {
        Neighbors = new[]
        {
          new Field(2) { Direction = Direction.Right },
          new Field(5) { Direction = Direction.Down }
        }
      });

      fields.Add(new Field(2)
      {
        Neighbors = new[]
        {
          new Field(3) { Direction = Direction.Right },
          new Field(6) { Direction = Direction.Down },
          new Field(1) { Direction = Direction.Left }
        }
      });

      fields.Add(new Field(3)
      {
        Neighbors = new[]
        {
          new Field(4) { Direction = Direction.Right },
          new Field(7) { Direction = Direction.Down },
          new Field(2) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(4)
      {
        Neighbors = new[]
        {
          new Field(8) { Direction = Direction.Down },
          new Field(3) { Direction = Direction.Left }
        }
      });
      #endregion

      #region 2-ая линия
      fields.Add(new Field(5)
      {
        Neighbors = new[]
        {
          new Field(1) { Direction = Direction.Up },
          new Field(6) { Direction = Direction.Right },
          new Field(9) { Direction = Direction.Down }
        }
      });
      fields.Add(new Field(6)
      {
        Neighbors = new[]
        {
          new Field(2) { Direction = Direction.Up },
          new Field(7) { Direction = Direction.Right },
          new Field(10) { Direction = Direction.Down },
          new Field(5) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(7)
      {
        Neighbors = new[]
        {
          new Field(3) { Direction = Direction.Up },
          new Field(8) { Direction = Direction.Right },
          new Field(11) { Direction = Direction.Down },
          new Field(6) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(8)
      {
        Neighbors = new[]
        {
          new Field(4) { Direction = Direction.Up },
          new Field(12) { Direction = Direction.Down },
          new Field(7) { Direction = Direction.Left }
        }
      });
      #endregion

      #region 3-ая линия
      fields.Add(new Field(9)
      {
        Neighbors = new[]
        {
          new Field(5) { Direction = Direction.Up },
          new Field(10) { Direction = Direction.Right },
          new Field(13) { Direction = Direction.Down }
        }
      });
      fields.Add(new Field(10)
      {
        Neighbors = new[]
        {
          new Field(6) { Direction = Direction.Up },
          new Field(11) { Direction = Direction.Right },
          new Field(14) { Direction = Direction.Down },
          new Field(9) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(11)
      {
        Neighbors = new[]
        {
          new Field(7) { Direction = Direction.Up },
          new Field(12) { Direction = Direction.Right },
          new Field(15) { Direction = Direction.Down },
          new Field(10) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(12)
      {
        Neighbors = new[]
        {
          new Field(8) { Direction = Direction.Up },
          new Field(16) { Direction = Direction.Down },
          new Field(11) { Direction = Direction.Left }
        }
      });
      #endregion

      #region 4-ая линия
      fields.Add(new Field(13)
      {
        Neighbors = new[]
        {
          new Field(9) { Direction = Direction.Up },
          new Field(14) { Direction = Direction.Right }
        }
      });

      fields.Add(new Field(14)
      {
        Neighbors = new[]
        {
          new Field(10) { Direction = Direction.Up },
          new Field(15) { Direction = Direction.Right },
          new Field(13) { Direction = Direction.Left }
        }
      });

      fields.Add(new Field(15)
      {
        Neighbors = new[]
        {
          new Field(11) { Direction = Direction.Up },
          new Field(16) { Direction = Direction.Right },
          new Field(14) { Direction = Direction.Left }
        }
      });
      fields.Add(new Field(16)
      {
        Neighbors = new[]
        {
          new Field(12) { Direction = Direction.Up },
          new Field(15) { Direction = Direction.Left }
        }
      });
      #endregion
   } 
  }
}