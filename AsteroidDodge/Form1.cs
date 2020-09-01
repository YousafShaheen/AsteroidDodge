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

        int time = 0; //measure how long the game is being played

        int playerScore = 0; //score for the player

        int shipPos = 1; //ship position (1,2, or 3)
        int spawn = 0; // spawn pattern between [0,7)
        bool a1pos = false; //if asteroid 1 is in the collision area
        bool a2pos = false; //if asteroid 2 is in the collision area
        bool a3pos = false; //if asteroid 3 is in the collision area
        int gameSpeed = 1; //game tick speed
        int impactPoint = 400; //the impact area
        int resetPoint = 550; //reset the asteroid to its original position
        bool pause = true; //true if the game is paused

        int difficultyLevel = 500; //interval in ms of when the difficulty increases
        int maxAstSpeed = 20; // starting asteroid speed
        int astSpeed = 20; //interval for asteroid moving in ms (reduce to 1)
        int astSpeedInc = 1; //increase the asteroid speed by this amount in ms
        int astMove = 20; //pixels each asteroid move.
        int shipMove = 85; //distance the ship moves to left or right

        int maxSpawnSpeed = 2000; //initial spawn speed
        int spawnSpeed = 2000; //rate at which the ateroids spawn in ms
        int spawnSpeedInc = 200; //increase the spawn speed by this amount in ms
        int spawnSpeedLimit = 300; //spawn speed limit

        Random rnd = new Random(); //RNG for asteroid spawner


        public AsteroidDodge()
        {
            //run initializers
            InitializeComponent();
            InitializeTimer();
        }

        /*
         * intializes timers:
         * game intervals
         * asteroids
         * spawner
         */
        private void InitializeTimer()
        {
            
            //sets the game tick speed and enables timer
            game.Interval = gameSpeed;
            game.Enabled = true;

            //sets the spawn rate and enables the sapwner
            spawner.Interval = spawnSpeed;
            spawner.Enabled = true;


            //sets the speed at which the asteroids move timers enabled in spawner_Tick
            asteroid1.Interval = astSpeed;
            asteroid2.Interval = astSpeed;
            asteroid3.Interval = astSpeed;
            

            // Hook up timers tick event handler  
            this.asteroid1.Tick += new System.EventHandler(this.asteroid1_Tick);
            this.asteroid2.Tick += new System.EventHandler(this.asteroid2_Tick);
            this.asteroid3.Tick += new System.EventHandler(this.asteroid3_Tick);
            this.game.Tick += new System.EventHandler(this.game_Tick);
            this.spawner.Tick += new System.EventHandler(this.spawner_Tick);
        }

        
        /*
         * Spawns asteroids in one of 6 spawn patterns. does not run if game is paused.
         * there are 3 posiitons, 1 for each asteroid.
         * generate a random number from [1,6] inclusive.
         * 
         * possible spawn configs (0-dont spawn, 1-spawn):
         * a1 a2 a3
         * ----------
         * 0  0  1
         * 0  1  0
         * 0  1  1
         * 1  0  0
         * 1  0  1
         * 1  1  0
         * 
         */
        private void spawner_Tick(object Sender, EventArgs e)
        {
            //dont run if paused
            if (pause)
                return;

            //gennerate a random num fron [1,6] inclusive
            spawn = rnd.Next(1, 7);


            //spawns asteroid based on spawn config (enables asteroid timers)
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
                case 7:
                    asteroid1.Enabled = true;
                    asteroid2.Enabled = true;
                    asteroid3.Enabled = true;
                    break;
                default:
                    Console.WriteLine("error with spawn rnd var");
                    break;
            }
        }

        /*
         * main game engine. does basic tasks and synchronization.
         * handles:
         * score display
         * collisions (and resets the game)
         */
        private void game_Tick(object Sender, EventArgs e)
        {
            
            //if game is not paused, increase time count and score
            if (!pause)
            {
                time++;

                //score = game_ticks * (maxSpeed + 1 -astSpeed)
                playerScore += (maxAstSpeed+1 - astSpeed);
            }
            
            //displays speed
            speed.Text = (maxAstSpeed+1 - astSpeed).ToString();

            //displays score
            score.Text = (playerScore/100).ToString();

            

            //increase speed by 1ms per 0.2s until astSpeed == 1ms
            if(time == difficultyLevel && astSpeed>1)
            {
                astSpeed -= astSpeedInc;
                spawnSpeed -= spawnSpeedInc;
                time = time - difficultyLevel;
            }

            //enforce upper limit
            if (spawnSpeed < spawnSpeedLimit)
            {
                spawnSpeed = spawnSpeedLimit;
            }
            spawner.Interval = spawnSpeed;
            

            //checks if there is a collisison
            if ((shipPos == 1 && a1pos) || (shipPos == 2 && a2pos) || (shipPos == 3 && a3pos))
            {
                //moves current score to previous score and resets parameters
                prevScore.Text = (playerScore/100).ToString();
                playerScore = 0;
                spawnSpeed = maxSpawnSpeed;
                astSpeed = maxAstSpeed;

                //pause the game and get ready for next game
                SendKeys.Send("p");
                
                //reset asteroid locations
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

        /*
         * asteroid in left position.
         * handles movement of the asteroid
         * this runs until the asteroid goes from the top to the bottom,
         * and then resets and disables timer. waits til the spawner calls it agian.
         */
        private void asteroid1_Tick(object Sender, EventArgs e)
        {
            //if paused, do nothing else
            if (pause)
                return;

            //new location for asteroid
            ast1.Location = new Point(ast1.Location.X, ast1.Location.Y + astMove);

            //if asteroid reaches the bottom, reset location and disable
            if (ast1.Location.Y >= resetPoint)
            {
                ast1.Location = new Point(ast1.Location.X, 10);
                asteroid1.Enabled = false;
                a1pos = false;
            }
            
            //if asteroid is in between collision area, set a1pos to true
            if (ast1.Location.Y >= impactPoint)
                a1pos = true;
            else
                a1pos = false;

        }

        /*
         * asteroid in middle position.
         * handles movement of the asteroid
         * this runs until the asteroid goes from the top to the bottom,
         * and then resets and disables timer. waits til the spawner calls it agian.
         */
        private void asteroid2_Tick(object Sender, EventArgs e)
        {
            //if paused, do nothing else
            if (pause)
                return;

            //new location for asteroid
            ast2.Location = new Point(ast2.Location.X, ast2.Location.Y + astMove);

            //if asteroid reaches the bottom, reset location and disable
            if (ast2.Location.Y >= resetPoint)
            {
                ast2.Location = new Point(ast2.Location.X, 10);
                asteroid2.Enabled = false;
                a2pos = false;
            }

            //if asteroid is in between collision area, set a1pos to true
            if (ast2.Location.Y >= impactPoint)
                a2pos = true;
            else
                a2pos = false;
        }

        /*
         * asteroid in right position.
         * handles movement of the asteroid
         * this runs until the asteroid goes from the top to the bottom,
         * and then resets and disables timer. waits til the spawner calls it agian.
         */
        private void asteroid3_Tick(object Sender, EventArgs e)
        {
            //if paused, do nothing else
            if (pause)
                return;

            //new location for asteroid
            ast3.Location = new Point(ast3.Location.X, ast3.Location.Y + astMove);

            //if asteroid reaches the bottom, reset location and disable
            if (ast3.Location.Y >= resetPoint)
            {
                ast3.Location = new Point(ast3.Location.X, 10);
                asteroid3.Enabled = false;
                a3pos = false;
            }

            //if asteroid is in between collision area, set a1pos to true
            if (ast3.Location.Y >= impactPoint)
                a3pos = true;
            else
                a3pos = false;
        }

        /*
         * handles all keykoard input.
         * handles:
         * ship movement
         * pause function
         */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            /*
             * switch case depending on what key is pressed
             * left: move ship left. distance stored in var move
             * right: move ship right. distance stored in var move
             * p: pause the game
             */
            switch (keyData)
            {
                case Keys.Left:
                    //left

                    //dont move ship if game is paused
                    if (pause)
                        break;

                    //move ship and update position
                    if (shipPos != 1)
                    {
                        ship.Left = ship.Left - shipMove;
                        shipPos--;
                    }
                    break;
                case Keys.Right:
                    //right

                    //dont move ship if game is paused
                    if (pause)
                        break;

                    //move ship and update position
                    if (shipPos != 3)
                    {
                        ship.Left = ship.Left + shipMove;
                        shipPos++;
                    }
                    break;
                case Keys.P:
                    //pause the game

                    //toggle the pause label
                    pauseLabel.Visible = !pauseLabel.Visible;

                    //toggle pause var
                    pause = !pause;
                    break;
                default:
                    //return if other key is pressed
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            //return true
            return true;
        }
    }
}
