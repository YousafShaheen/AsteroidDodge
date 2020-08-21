using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidDodge
{
    
    public partial class AsteroidDodge : Form
    {

        int time = 0; //time since game started

        int playerScore = 0; //score for the player

        int shipPos = 1; //ship position (1,2, or 3)
        int spawn = 0; // spawn pattern between [0,7)
        bool a1pos = false; //if asteroid 1 is in the collision area
        bool a2pos = false; //if asteroid 2 is in the collision area
        bool a3pos = false; //if asteroid 3 is in the collision area
        int gameSpeed = 1; //game tick speed
        int impactPoint = 400; //the impact area
        int resetPoint = 500; //reset the asteroid to its original position
        bool pause = true; //true if the game is paused


        int astSpeed = 20;//20; //interval for asteroid moving in ms (reduce to 1)
        int astMove = 20; //pixels each asteroid move.

        int spawnSpeed = 490; //rate at which the ateroids spawn in ms

        Random rnd = new Random(); //RNG for spawn


        public AsteroidDodge()
        {
            InitializeComponent();
            InitializeTimer();

        }

        private void InitializeTimer()
        {
            // Run this procedure in an appropriate event.  

            game.Interval = gameSpeed;
            game.Enabled = true;

            spawner.Interval = spawnSpeed;
            spawner.Enabled = true;

            asteroid1.Interval = astSpeed;
            //asteroid1.Enabled = true;

            asteroid2.Interval = astSpeed;
            //asteroid2.Enabled = true;

            asteroid3.Interval = astSpeed;
            //asteroid3.Enabled = true;

            // Hook up timer's tick event handler.  
            this.asteroid1.Tick += new System.EventHandler(this.asteroid1_Tick);
            this.asteroid2.Tick += new System.EventHandler(this.asteroid2_Tick);
            this.asteroid3.Tick += new System.EventHandler(this.asteroid3_Tick);
            this.game.Tick += new System.EventHandler(this.game_Tick);
            this.spawner.Tick += new System.EventHandler(this.spawner_Tick);
        }

        

        private void spawner_Tick(object Sender, EventArgs e)
        {
            if (pause)
                return;

            spawn = rnd.Next(1, 7);

            switch (spawn)
            {
                case 0:
                    break;
                case 1:
                    asteroid3.Enabled = true;
                    break;
                case 2:
                    asteroid2.Enabled = true;
                    break;
                case 3:
                    asteroid2.Enabled = true;
                    asteroid3.Enabled = true;
                    break;
                case 4:
                    asteroid1.Enabled = true;
                    break;
                case 5:
                    asteroid1.Enabled = true;
                    asteroid3.Enabled = true;
                    break;
                case 6:
                    asteroid1.Enabled = true;
                    asteroid2.Enabled = true;
                    break;
                default:
                    Console.WriteLine("error with spawn rnd var");
                    break;
            }
        }


        private void game_Tick(object Sender, EventArgs e)
        {
            //Console.WriteLine("game tick");
            Console.WriteLine(astSpeed);
            if (!pause)
            {
                time++;
                playerScore += (20 - astSpeed);
            }
            //Console.WriteLine(astSpeed);

            speed.Text = (21 - astSpeed).ToString();
            score.Text = playerScore.ToString();

            

            //increase speed by 1ms per second until astSpeed == 1ms
            if(time == 200 && astSpeed>1)
            {
                astSpeed--;
                time = time - 200;
                Console.WriteLine("inc speed");
            }

                
            

            //if there is a collision
            if ((shipPos == 1 && a1pos) || (shipPos == 2 && a2pos) || (shipPos == 3 && a3pos))
            {
                Console.WriteLine("game over");
                prevScore.Text = playerScore.ToString();
                playerScore = 0;
                astSpeed = 20;
                //pause game
                SendKeys.Send("p");
                
                ast1.Location = new Point(ast1.Location.X, 10);
                asteroid1.Enabled = false;
                a1pos = false;

                ast2.Location = new Point(ast2.Location.X, 10);
                asteroid2.Enabled = false;
                a2pos = false;

                ast3.Location = new Point(ast3.Location.X, 10);
                asteroid3.Enabled = false;
                a3pos = false;

            }

        }

        private void asteroid1_Tick(object Sender, EventArgs e)
        {
            //Console.WriteLine("ast1");

            if (pause)
                return;

            ast1.Location = new Point(ast1.Location.X, ast1.Location.Y + astMove);

            if (ast1.Location.Y >= resetPoint)
            {
                ast1.Location = new Point(ast1.Location.X, 10);
                asteroid1.Enabled = false;
                a1pos = false;
            }
            

            if (ast1.Location.Y >= impactPoint)
                a1pos = true;
            else
                a1pos = false;

            
        }

        private void asteroid2_Tick(object Sender, EventArgs e)
        {
            //Console.WriteLine("ast2");
            if (pause)
                return;
            ast2.Location = new Point(ast2.Location.X, ast2.Location.Y + astMove);

            if (ast2.Location.Y >= resetPoint)
            {
                ast2.Location = new Point(ast2.Location.X, 10);
                asteroid2.Enabled = false;
                a2pos = false;
            }


            if (ast2.Location.Y >= impactPoint)
                a2pos = true;
            else
                a2pos = false;
        }

        private void asteroid3_Tick(object Sender, EventArgs e)
        {
            //Console.WriteLine("ast3");
            if (pause)
                return;
            ast3.Location = new Point(ast3.Location.X, ast3.Location.Y + astMove);

            if (ast3.Location.Y >= resetPoint)
            {
                ast3.Location = new Point(ast3.Location.X, 10);
                asteroid3.Enabled = false;
                a3pos = false;
            }


            if (ast3.Location.Y >= impactPoint)
                a3pos = true;
            else
                a3pos = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int move = 85;
            

            switch (keyData)
            {
                case Keys.Left:
                    //Console.WriteLine("LEFT");
                    if (pause)
                        break;
                    if (shipPos != 1)
                    {
                        ship.Left = ship.Left - move;
                        shipPos--;
                    }
                    break;
                case Keys.Right:
                    //Console.WriteLine("RIGHT");
                    if (pause)
                        break;
                    if (shipPos != 3)
                    {
                        ship.Left = ship.Left + move;
                        shipPos++;
                    }
                    break;
                case Keys.P:
                    //Console.WriteLine("PAUSE");
                    pauseLabel.Visible = !pauseLabel.Visible;
                    pause = !pause;
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        
    }

}
