using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Play_A_Game
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            

        }
    }
}


namespace Game
{
    public class Battleground {
        public char[,] fields = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        }


    public abstract class Player

    {
        public string name="";
        public int wins=0;



        public abstract void update_wins();
        public abstract void update_battleground(Battleground bg, int x, int y);

        public abstract void reset();
        


    }

    public class Player1 : Player
    {
        public Player1(string namep) 
        {
            this.name = namep;
        }

        public override void update_wins()
        {
            this.wins += 1;
        }

        public override void update_battleground(Battleground bg,int x,int y)
        {
            System.Diagnostics.Debug.WriteLine(bg);
            bg.fields[x, y] = 'X';
        }

        public override void reset() {
            this.wins = 0;
        }
    }

    public class Player2 : Player
    {
        public Player2(string namep)
        {
            this.name = namep;
        }
        public override  void update_wins()
        {
            this.wins += 1;
        }

        public override  void update_battleground(Battleground bg, int x, int y)
        {
  
            bg.fields[x, y] = 'O';
        }

        public override void reset()
        {
            this.wins = 0;
        }
    }


    public class Default : Player
    {
        public Default(string namep)
        {
            this.name = namep;
        }

        public override void update_battleground(Battleground bg,int x,int y)
        {
            for (int i=0;i<3;i++)
            {
                bg.fields[i, i] = ' ';
            }
        }

        public override void update_wins()
        {
            this.wins += 1;
        }

        public override void reset()
        {
            this.wins = 0;
        }

    }


    public class Battleground_manager
    {


        public Player State ;
        


        public void change_state(Player passed)
        {
            this.State = passed;
        }



        

        public string show_state()
        {
            return this.State.name;
        }
       

        public void update(Battleground bg,int x , int y)
        {
            if (this.evaluate_field(bg) == 0 ){
                if (bg.fields[x, y] == ' ') {
                    this.State.update_battleground(bg, x, y);
                }
                else
                {

                }
            }
                
        }

        public void initialize(Battleground bg)
        {
            for (int i=0 ; i<3;i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bg.fields[i, j] = ' ';
                }
            }
        }



        public int  evaluate_field(Battleground bg)
        {
          for (int i=0;i<3;i++)
            {
                if ((bg.fields[i, 0] ==  'X' && bg.fields[i, 1] == 'X' && bg.fields[i, 2] == 'X') || (bg.fields[0, i] == 'X' && bg.fields[1, i] == 'X' && bg.fields[2, i] == 'X') )
                {

                    return 1;

                }
                else if ((bg.fields[i, 0] == 'O' && bg.fields[i, 1] == 'O' && bg.fields[i, 2] == 'O') || (bg.fields[0, i] == 'O' && bg.fields[1, i] == 'O' && bg.fields[2, i] == 'O'))
                {

                    return 2;

                }
            }


            if ((bg.fields[0, 0] == 'X' && bg.fields[1, 1] == 'X' && bg.fields[2, 2] == 'X') || (bg.fields[0, 2] == 'X' && bg.fields[1, 1] == 'X' && bg.fields[2, 0] == 'X'))
            {

                return 1;

            }
            else if ((bg.fields[0, 0] == 'O' && bg.fields[1, 1] == 'O' && bg.fields[2, 2] == 'O') || (bg.fields[0, 2] == 'O' && bg.fields[1, 1] == 'O' && bg.fields[2, 2] == 'O'))
            {

                return 2;

            }

            else { return 0; } 

        }
    }

}