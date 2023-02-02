

using Game;

namespace Play_A_Game
{
    public partial class Form1 : Form
    {

        public Game.Battleground bg = new Game.Battleground();
        public Game.Player1 Player1 = new Game.Player1("son");
        public Game.Player2 Player2 = new Game.Player2("jhon");
        public Game.Default Default = new Game.Default("none");
        public Game.Battleground_manager Manager = new Game.Battleground_manager();
        

        public void update_frontend(Battleground_manager Manager)
        {
            button2.Text = bg.fields[0, 0].ToString();
            button3.Text = bg.fields[0, 1].ToString();
            button4.Text = bg.fields[0, 2].ToString();

            button5.Text = bg.fields[1, 0].ToString();
            button6.Text = bg.fields[1, 1].ToString();
            button7.Text = bg.fields[1, 2].ToString();

            button8.Text = bg.fields[2, 0].ToString();
            button9.Text = bg.fields[2, 1].ToString();
            button10.Text = bg.fields[2, 2].ToString();

            if (Manager.State == Player1 && Manager.evaluate_field(bg)==0) 
            {
                button11.Visible = true;
                button12.Visible = false;

                label3.BackColor = Color.Green;
                label4.BackColor = Color.White;

                textBox1.Text = "Player 1 Turn !";
            }
            else if (Manager.State == Player2 && Manager.evaluate_field(bg) == 0)
            {
                button11.Visible = false;
                button12.Visible = true;
                label4.BackColor = Color.Green;
                label3.BackColor = Color.White;

                textBox1.Text = "Player 2 Turn !";
            }
            else if ( Manager.evaluate_field(bg) == 1)
            {
                button11.Visible = false;
                button12.Visible = false;
                label4.BackColor = Color.White;
                label3.BackColor = Color.White;

                textBox1.Text = "Player 1 Won !";
            }
            else if (Manager.evaluate_field(bg) == 2)
            {
                button11.Visible = false;
                button12.Visible = false;
                label4.BackColor = Color.White;
                label3.BackColor = Color.White;

                textBox1.Text = "Player 2 Won !";
            }

            else
            {
                button11.Visible = false;
                button12.Visible = false;
            }

        }

        public void complete(Battleground_manager Manager)
        {
            if (Manager.State == Player1 )
            {
                Manager.change_state(Player2);
            }
            else if (Manager.State == Player2)
            {
                Manager.change_state(Player1);
            }
        }


        
        public Form1()
        {
            InitializeComponent();
            Manager.State = Default;
            update_frontend(Manager);




        }



         private void button1_Click(object sender, EventArgs e)
        {
            Manager.initialize(bg);
            Manager.change_state(Player1);
            update_frontend(Manager);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (bg.fields[0, 0] == ' ')
            {
                Manager.update(bg,0,0);
                this.complete(Manager);
            }
            this.update_frontend(Manager);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (bg.fields[0, 1] == ' ')
            {
                Manager.update(bg, 0, 1);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (bg.fields[0, 2] == ' ')
            {
                Manager.update(bg, 0, 2);

                this.complete(Manager);
            }
            update_frontend(Manager);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bg.fields[1, 0] == ' ')
            {
                Manager.update(bg, 1, 0);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (bg.fields[1, 1] == ' ')
            {
                Manager.update(bg, 1, 1);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (bg.fields[1, 2] == ' ')
            {
                Manager.update(bg, 1, 2);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (bg.fields[2, 0] == ' ')
            {
                Manager.update(bg, 2, 0);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (bg.fields[2, 1] == ' ')
            {
                Manager.update(bg, 2, 1);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (bg.fields[2, 2] == ' ')
            {
                Manager.update(bg, 2, 2);
                this.complete(Manager);
            }
            update_frontend(Manager);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Manager.change_state(Player2);
            update_frontend(Manager);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Manager.change_state(Player1);
            update_frontend(Manager);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }



}
