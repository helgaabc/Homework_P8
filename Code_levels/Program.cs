string[,] menu = {{"@","Начать игру"," "},
                  {" ","Выбор уровня"," "},
                  {" ","Выход"," "}};
string[,] level = {{"1","2","3","4","5","6","7","8","9","10"},
                   {"@"," "," "," "," "," "," "," "," "," "}};

string[,] matrix = {{" "," "," "," "," "},
                    {" ","|"," ","|"," "},
                    {" ","|","@","|"," "},
                    {" "," "," "," "," "},
                    {" "," "," ","$"," "},
                    {" "," "," "," "," "}};
Dictionary<int, string[,]> Lvls =  new Dictionary<int, string[,]>{{1, 
new string[,]{{"*"," "," "," ","*"},
              {" ","|"," ","|"," "},
              {" ","|","@","|"," "},
              {"+"," "," "," ","+"},
              {" ","- "," _","-"," "},
              {" "," ","$"," "," "}}},
              {2,
 new string[,]{{"$"," ","="," "," "},
              {" ","|"," ","|"," "},
              {" ","=","@","="," "},
              {" "," ","|"," "," "},
              {"-"," ","=","-"," "},
              {"="," "," "," "," "}}},
              {3,
 new string[,]{{" "," "," "," "," "},
              {" ","$"," ","*"," "},
              {" ","|","@","|"," "},
              {" ","=","-","="," "},
              {" ","* ","*","*"," "},
              {" ","+"," ","="," "}}},
              {4,
new string[,]{{" "," "," "," "," "},
              {" ","|"," ","|"," "},
              {" ","|","@","|"," "},
              {" "," ","$"," "," "},
              {" ","|"," ","|"," "},
              {"|"," "," "," ","|"}}},
              {5,
new string[,]{{" "," "," "," "," "},
              {" ","|"," ","|"," "},
              {" ","*","@","|"," "},
              {" "," ","*"," "," "},
              {" ","|"," ","*"," "},
              {" "," "," "," ","$"}}},
              {6,
new string[,]{{"+"," "," "," ","+"},
              {" ","|","@","|"," "},
              {" ","|","$","|"," "},
              {" "," ","|"," "," "},
              {" ","*"," ","*"," "},
              {"+"," "," "," ","+"}}},
              {7,
new string[,]{{"+"," "," "," ","+"},
              {"*","|","-","|","*"},
              {" ","|","@","|"," "},
              {" ","$","|"," "," "},
              {" ","*"," ","*"," "},
              {"+"," "," "," ","+"}}}, 
              {8,
new string[,]{{"+","-"," ","-","+"},
              {" ","|","$","|"," "},
              {" ","|","@","|"," "},
              {"/"," ","|"," ","/"},
              {" ","*"," ","*"," "},
              {"+"," "," "," ","+"}}},
              {9,
new string[,]{{"#"," "," "," ","$"},
              {" ","|","@","|"," "},
              {" ","|","=","|"," "},
              {" "," ","|"," "," "},
              {" ","*"," ","*"," "},
              {"+"," "," "," ","#"}}},
              {10,
new string[,]{{"+"," "," "," ","+"},
              {" ","|","@","|"," "},
              {" ","|","@","|"," "},
              {"+"," ","|"," ","+"},
              {" ","*"," ","*"," "},
              {"+"," "," "," ","+"}}}};

int coins = 0;
int MenuX= 0;
int MenuY = 0;
int LevelX = 0;
int LevelY = 0;



int SelectMenuPlayer()
{
    int IndexMenu = 0;
    MaxtrixWrite(menu);
    ConsoleKeyInfo User_keyTab = Console.ReadKey();
    while(User_keyTab.Key !=ConsoleKey.Enter)
    {

        Console.Clear();
        menu[MenuY,MenuX] = " ";
        if(User_keyTab.Key == ConsoleKey.W && IndexMenu > 0)
    {
        IndexMenu--;
        MenuY--;
    }
    if(User_keyTab.Key == ConsoleKey.S && IndexMenu < 2)
    {
        IndexMenu++;
        MenuY++; 
    }
  menu[MenuY,MenuX]= "@";
  MaxtrixWrite(menu);
  User_keyTab = Console.ReadKey();
    }
    return IndexMenu;
}

int SelectMenuLevel()
{
    int IndexLevel = 0;
    int LevelY =1;
    Console.WriteLine("Выберите уровень ");
    MaxtrixWrite(level);
    ConsoleKeyInfo User_keyTab = Console.ReadKey();
    while(User_keyTab.Key !=ConsoleKey.Enter)
    {

        Console.Clear();
        level[LevelY,LevelX] = " ";
        if(User_keyTab.Key == ConsoleKey.A && IndexLevel > 0)
    {
        IndexLevel--;
        LevelX--;
    }
    if(User_keyTab.Key == ConsoleKey.D && IndexLevel < 9)
    {
        IndexLevel++;
        LevelX++; 
    }
  level[LevelY,LevelX]= "@";
  MaxtrixWrite(level);
  User_keyTab = Console.ReadKey();
    }
    return IndexLevel;
}

void MaxtrixWrite(string[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("Кол-во очков " + coins );
}
string[,] ItemFoodMatrix(int x, int y, string[,] array)
{
    while(matrix[y,x] == "$")
    {
        matrix[y,x] = " ";
        int matX = new Random().Next(0, array.GetLength(1));
        int matY = new Random().Next(0, array.GetLength(0));
        while(matrix[matY,matX] == "|")
        {
            matX = new Random().Next(0, array.GetLength(1));
            matY = new Random().Next(0, array.GetLength(0));
        }
        array[matY,matX] = "$";
        coins++;
    }
    return array;
}
bool Barrier(int x, int y)
{
    if(matrix[y,x] == "|") return false;
    return true;
}
int x = 2;
int y = 2;
while (true)
{
switch (SelectMenuPlayer())
{
    case 0://начало игры
      Console.Clear();
     Game();
    break;
    case 1:// выбор уровня
      Console.Clear();
      level = Lvls[SelectMenuLevel()];
      Game();
      break;
case 2://выход
  Console.Clear();
 break;
    default:
    break;
}
}

void Game()
{
    while (true)
    {
        Console.Clear();
        MaxtrixWrite(matrix);
        matrix[y,x] = " ";
        ConsoleKeyInfo User_keyTab = Console.ReadKey();
        if(User_keyTab.Key == ConsoleKey.W) if(Barrier(x,y-1)) y--;
        if(User_keyTab.Key == ConsoleKey.S) if(Barrier(x,y+1)) y++;
        if(User_keyTab.Key == ConsoleKey.A) if(Barrier(x-1,y)) x--;
        if(User_keyTab.Key == ConsoleKey.D) if(Barrier(x+1,y)) x++;
    
         if(y >= matrix.GetLength(0)) y = 0;
         if(y <= 0) y = matrix.GetLength(0);

         if(x >= matrix.GetLength(1)) x = 0;
         if(x <= 0) x = matrix.GetLength(1);

        matrix = ItemFoodMatrix(x,y,matrix);
        matrix[y,x] = "@";
}

    }