using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace TestConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game();
      game.New();
      game.Moving += Game_Moving;

      while (true)
      {
        
        string res = Console.ReadLine();
        string[] resArray = res.Split(' ');
        switch (resArray[0])
        {
          case "e":
            return;
          case "n":
            game.New();
            break;
          case "r":
            Game_Moving(null, new MovingEventArgs(game.GetSquare()));
            break;
          case "g":
            switch (resArray[2])
            {
              case "u":
                game.Move(Convert.ToByte(resArray[1]), Direction.Up);
                break;
              case "d":
                game.Move(Convert.ToByte(resArray[1]), Direction.Down);
                break;
              case "l":
                game.Move(Convert.ToByte(resArray[1]), Direction.Left);
                break;
              case "r":
                game.Move(Convert.ToByte(resArray[1]), Direction.Right);
                break;
            }
            break;
        }
      }
      

    }

    private static void Game_Moving(object sender, MovingEventArgs e)
    {
      List<Field> fields = e.Square.GetFields();
      for (int i = 0; i < fields.Count; i++)
      {
        if (i == 3 || i == 7 || i == 11)
          Console.WriteLine(fields[i].Token);
        else
          Console.Write(fields[i].Token + " ");
      }
      Console.WriteLine();
    }
  }
}
