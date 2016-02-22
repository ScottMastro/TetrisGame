using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;  //used for font
using System.Media;         //used for sounds
using System.IO;            //used for highscore

//***************Global Variables and Classes****************
//Image[9] square = 8 coloured square************************
//Image[9] semitransparentsquare = 8 semitransparent squares*
//Image[9] smallsquares = 8 next block blocks****************
//Image background = background of the panel*****************
//Image nextblock = square showing the next block************
//Image gameoverbackground = panel gameover background*******
//Image formbackground = background of the form**************
//Image pausebackground = panel pause background*************
//Image logo = title image***********************************
//Image info = title for labels holding game info************
//Image startbutton = start button image*********************
//Image quitbutton = quit button image***********************
//SoundPlayer spin = turn sound effect***********************
//SoundPlayer stick = deactivate block sound effect**********
//SoundPlayer clear = clear line sound effect****************
//SoundPlayer gmover = gameover sound effect*****************
//int[11, 16] filled = type of square at every position******
//int[11, 16] colour = colour of square at every position****
//int[5] X = x location of active block's squares************
//int[5] Y = y location of active block's squares************
//int nexttype = stores the next block***********************
//int type = type of activated block*************************
//int activecolour = colour of activated block***************
//int numberofblocks = number of squares in activated block**
//int score = points in current game*************************
//int highscore = top score of all time**********************
//int seconds = seconds elapsed in current game**************
//int minutes = minutes elapsed in current game**************
//int lines = number of lines cleared in current game********
//int level = level of current game**************************
//int plusscore = points added for cleared line(s)***********
//int clearedposition = y position of cleared line(s)********
//int count = used for counting time on the lifting +score***
//bool paused = paused status of the game********************
//bool over = active status of the game**********************
//bool activated = active status of the active block*********
//bool music = whether or not the music is playing***********
//***********************************************************

//***************Local Variables and Classes*****************
//Font digital = font for score labels***********************
//StreamWriter write = writing into text files***************
//StreamReader reader = reading text files*******************
//string line = text received from text files****************
//Graphics g = drawing all images in the game****************
//bool start = is the method called at the start of the game*
//Random r = random number generator*************************
//int counter = finds the row of the highest fixed square****
//int movedown = # of rows the block must move down**********
//int direction = direction to move the block****************
//int[5] savedX = saves x location of active squares*********
//int[5] savedY = saves y location of active squares*********
//bool flag = if the new turn position is already filled*****
//int highxpos = how much the block goes off the panel (high)
//int lowxpos = how much the block goes off the panel (low)**
//bool flag2 = determines if sound should be played**********
//int linescleared = # of lines cleard with one block********
//int line = y location of cleared line(s)*******************
//int previouscolour = temp storage of colour value**********


namespace TetrisGame
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //declaring variables and classes
        //fonts
        PrivateFontCollection pfc = new PrivateFontCollection();

        //images
        Image[] square = new Image[9];
        Image[] semitransparentsquare = new Image[9];
        Image[] smallsquares = new Image[9];
        Image background;
        Image nextblock;
        Image gameoverbackground;
        Image formbackground;
        Image pausebackground;
        Image logo;
        Image info;
        Image startbutton;
        Image quitbutton;

        //sounds
        SoundPlayer spin = new SoundPlayer();
        SoundPlayer stick = new SoundPlayer();
        SoundPlayer clear = new SoundPlayer();
        SoundPlayer gmover = new SoundPlayer();

        //variables
        int[,] filled = new int[11, 16];
        int[,] colour = new int[11, 16];
        int[] X = new int[5];
        int[] Y = new int[5];

        int nexttype;
        int type;
        int activecolour;
        int numberofblocks;
        int score = 0;
        int highscore;
        int seconds;
        int minutes;
        int lines;
        int level = 1;
        int plusscore;
        int clearedposition;

        bool paused = false;
        bool over = true;
        bool activated = false;
        bool music = false;

        //load in resources
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //load in font and set label font
            pfc.AddFontFile(Application.StartupPath + @"\resources\digital.ttf");
            pfc.AddFontFile(Application.StartupPath + @"\resources\score+.ttf");
            Font digital = new Font(pfc.Families[0], 24);

            LblHighscore.Font = digital;
            LblLevel.Font = digital;
            LblLines.Font = digital;
            LblScore.Font = digital;
            LblTime.Font = digital;

            //load in background images
            background = Image.FromFile(Application.StartupPath + @"\resources\tetrisbackground.png");
            gameoverbackground = Image.FromFile(Application.StartupPath + @"\resources\gameover.png");
            formbackground = Image.FromFile(Application.StartupPath + @"\resources\framebackground.png");
            pausebackground = Image.FromFile(Application.StartupPath + @"\resources\pausebackground.png");

            //load in other images
            nextblock = Image.FromFile(Application.StartupPath + @"\resources\nextblock.png");
            logo = Image.FromFile(Application.StartupPath + @"\resources\logo.png");
            info = Image.FromFile(Application.StartupPath + @"\resources\label.png");
            startbutton = Image.FromFile(Application.StartupPath + @"\resources\startbutton.png");
            quitbutton = Image.FromFile(Application.StartupPath + @"\resources\quitbutton.png");

            //block1 = grey
            //block1 = orange
            //block2 = blue
            //block3 = lightblue
            //block4 = purple
            //block5 = green
            //block6 = red
            //block7 = yellow
            //block8 = pink
            for (int x = 0; x <= 8; x++)
            {
                square[x] = Image.FromFile(Application.StartupPath + @"\resources\block" + x.ToString() + ".png");
                smallsquares[x] = Image.FromFile(Application.StartupPath + @"\resources\smallblock" + x.ToString() + ".png");
                semitransparentsquare[x] = Image.FromFile(Application.StartupPath + @"\resources\stblock" + x.ToString() + ".png");
            }

            //load in sounds
            spin.SoundLocation = Application.StartupPath + @"\resources\spin.wav";
            stick.SoundLocation = Application.StartupPath + @"\resources\stick.wav";
            clear.SoundLocation = Application.StartupPath + @"\resources\clear.wav";
            gmover.SoundLocation = Application.StartupPath + @"\resources\gmover.wav";

            spin.LoadAsync();
            stick.LoadAsync();
            clear.LoadAsync();
            gmover.LoadAsync();

            //set images of PicClose and PicStart
            PicClose.Image = quitbutton;
            PicStart.Image = startbutton;
            Highscore();

            //play background song
            MediaPlayer.URL = Application.StartupPath + @"\resources\tetrissong.mp3";
            //set to max volume
            MediaPlayer.settings.volume = 30;
            //loop one million times
            MediaPlayer.settings.playCount = Convert.ToInt32(1 * Math.Pow(10, 6));
            MediaPlayer.Ctlcontrols.stop();
        }

        //manages highscore
        private void Highscore()
        {
            //if you currently have the highscore, write it
            //into the text file
            if (score > highscore)
            {
                highscore = score;
                StreamWriter write = new StreamWriter(Application.StartupPath + @"\highscores.txt");

                write.WriteLine(Convert.ToString(highscore));
                write.Close();
                write.Dispose();
            }
            //load the highscore from the text file
            else
            {
                string line;
                StreamReader read = new StreamReader(Application.StartupPath + @"\highscores.txt");

                line = read.ReadLine();
                LblHighscore.Text = "Highscore: " + line;
                highscore = Convert.ToInt32(line);
                read.Close();
                read.Dispose();
            }
        }

        //changes highscore mid-game
        private void HighscoreUpdate()
        {
            //if you currently have the highscore, this
            //changes the score shown in the highscore
            //as you play
            if (score > highscore)
                highscore = score;

            LblHighscore.Text = "Highscore: " + Convert.ToString(highscore);
        }

        //pauses and upauses all actions in the game
        private void PauseGame()
        {
            if (paused == true)
            {
                TimFrame.Enabled = false;
                TimTime.Enabled = false;
            }
            else if (paused == false && over == false)
            {
                TimFrame.Enabled = true;
                TimTime.Enabled = false;
            }

            pnlGame.Refresh();
        }

        //redraws everything in the panel
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Draw(g);
        }

        //draws from background to foreground
        private void Draw(Graphics g)
        {
            //0 = no block
            //1 = fixed block
            //2 = active block
            //3 = semitransparent block
            g.DrawImage(background, 0, 0, 500, 750);

            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 10; x++)
                {
                    if (filled[x, y] == 1 || filled[x, y] == 2)
                        g.DrawImage(square[colour[x, y]], x * 50, y * 50, 50, 50);
                    else if (filled[x, y] == 3)
                        g.DrawImage(semitransparentsquare[colour[x, y]], x * 50, y * 50, 50, 50);
                }
            }

            if (over)
                g.DrawImage(gameoverbackground, 0, 0, 500, 750);

            if (paused && !over)
                g.DrawImage(pausebackground, 0, 0, 500, 750);

            if (plusscore > 0)
            {
                TimLift.Enabled = true;
                g.DrawString(plusscore.ToString(), new Font(pfc.Families[1], 24), new SolidBrush(Color.Black), (pnlGame.Width / 2) - 2, clearedposition);
                g.DrawString(plusscore.ToString(), new Font(pfc.Families[1], 24), new SolidBrush(Color.DarkGoldenrod), pnlGame.Width / 2, clearedposition);
            }
        }

        //initiates a new block
        private void DetermineBlock(bool start)
        {
            //if the game just started, this sets a type before
            //nexttype is determined otherwise the current type
            //equals nexttype
            if (start)
            {
                Random r = new Random();
                type = r.Next(1, 8);
            }
            else
                type = nexttype;
            DetermineNextType();

            activated = true;
            SetBlock();
            UpdateGame();
            PaintForm();
            pnlGame.Refresh();
        }

        //choses next block
        private void DetermineNextType()
        {
            //randomly selects a block with block 8 being
            //twice as unlikely to get
            Random r = new Random();
            nexttype = r.Next(0, 9);

            if (nexttype == 8)
                nexttype = r.Next(0, 9);
        }

        //determines the location of the semitransparent block
        private void DetermineTransBlock()
        {
            int counter = 0;
            int movedown = 999;

            //removes old semitransparent block
            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 10; x++)
                {
                    if (filled[x, y] == 3)
                        filled[x, y] = 0;
                }
            }

            //finds proper location
            for (int t = 1; t <= numberofblocks; t++)
            {
                while (true)
                {
                    if (Y[t] + counter > 14 || filled[X[t], Y[t] + counter] == 1)
                    {
                        if (counter - 1 < movedown)
                            movedown = counter - 1;
                        break;
                    }
                    counter++;
                }
                counter = 0;
            }

            //fills position with semitransparent block
            for (int t = 1; t <= numberofblocks; t++)
            {
                if (filled[X[t], Y[t] + movedown] == 0)
                {
                    filled[X[t], Y[t] + movedown] = 3;
                    colour[X[t], Y[t] + movedown] = activecolour;
                }
            }
        }

        //reads the starting location of every type of block
        private void SetBlock()
        {
            //read from text file matching type
            StreamReader reader = new StreamReader(Application.StartupPath + @"\" + type.ToString() + ".txt");
            string line;

            activecolour = type;
            if (type == 0)
                numberofblocks = 3;
            else if (type == 8)
                numberofblocks = 1;
            else
                numberofblocks = 4;

            //store data into X[] and Y[]
            for (int i = 1; i <= 4; i++)
            {
                line = reader.ReadLine();
                X[i] = Convert.ToInt32(line);
                line = reader.ReadLine();
                Y[i] = Convert.ToInt32(line);
            }

            reader.Dispose();
        }

        //moves blocks down at a changing interval
        private void TimFrame_Tick(object sender, EventArgs e)
        {
            BlockFall();
            pnlGame.Refresh();
        }

        //determines and displayes time game has been played
        private void TimTime_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes <= 9 && seconds <= 9)
                LblTime.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
            else if (minutes > 9 && seconds <= 9)
                LblTime.Text = minutes.ToString() + ":0" + seconds.ToString();
            else if (minutes <= 9 && seconds > 9)
                LblTime.Text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }

        int count = 0;
        //moves up the +score
        private void TimLift_Tick(object sender, EventArgs e)
        {
            clearedposition -= 5;
            count++;

            if (count > 10)
            {
                count = 0;
                plusscore = 0;
                TimLift.Enabled = false;
            }

            pnlGame.Refresh();
        }

        //handles key input
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (activated && !over)
            {
                if (!paused)
                {
                    //moves blocks to the left
                    if (e.KeyCode == Keys.A)
                        ShiftBlock(1);

                    //moves blocks to the right
                    if (e.KeyCode == Keys.D)
                        ShiftBlock(2);

                    //turns block
                    if (e.KeyCode == Keys.W)
                    {
                        if (type < 7)
                            TurnBlock();
                        else
                            spin.Play();
                    }

                    //moves block down and increases score
                    if (e.KeyCode == Keys.S)
                    {
                        BlockFall();
                        score += 5;
                        UpdateScore();
                    }

                    //drops block
                    if (e.KeyCode == Keys.Space)
                        DropBlock();

                }

                //pauses and unpauses game
                if (e.KeyCode == Keys.P)
                {
                    paused = !paused;
                    PauseGame();
                }
            }
        }

        //moves block left and right
        private void ShiftBlock(int direction)
        {
            //moves block to the left
            if (direction == 1)
            {
                //checks if position is clear
                if (X[1] > 0 && X[2] > 0 && X[3] > 0 && X[4] > 0 && filled[X[1] - 1, Y[1]] != 1 && filled[X[2] - 1, Y[2]] != 1 && filled[X[3] - 1, Y[3]] != 1 && filled[X[4] - 1, Y[4]] != 1)
                {
                    for (int t = 1; t <= numberofblocks; t++)
                    {
                        filled[X[t], Y[t]] = 0;
                        X[t]--;
                    }
                }
            }
            //moves block to the right
            else
            {
                //checks if position is clear
                if (X[1] < 9 && X[2] < 9 && X[3] < 9 && X[4] < 9 && filled[X[1] + 1, Y[1]] != 1 && filled[X[2] + 1, Y[2]] != 1 && filled[X[3] + 1, Y[3]] != 1 && filled[X[4] + 1, Y[4]] != 1)
                {
                    for (int t = 1; t <= numberofblocks; t++)
                    {
                        filled[X[t], Y[t]] = 0;
                        X[t]++;
                    }
                }
            }
            UpdateGame();
        }

        //moves block down
        private void BlockFall()
        {
            //moves block down or deactivates block if 
            //there is a block under it
            if (filled[X[1], Y[1] + 1] != 1 && filled[X[2], Y[2] + 1] != 1 && filled[X[3], Y[3] + 1] != 1 && filled[X[4], Y[4] + 1] != 1 && Y[1] < 14 && Y[2] < 14 && Y[3] < 14 && Y[4] < 14)
            {
                for (int t = 1; t <= numberofblocks; t++)
                {
                    filled[X[t], Y[t]] = 0;
                    Y[t]++;
                }
                UpdateGame();
            }
            else
            {
                DeactivateBlock();
                LineCheck();
            }
        }

        //turns block clockwise
        private void TurnBlock()
        {
            Erase();

            int[] savedX = new int[5];
            int[] savedY = new int[5];
            bool flag = false;
            int highxpos = 0;
            int lowxpos = 10;

            //saves current position
            for (int s = 1; s <= numberofblocks; s++)
            {
                savedX[s] = X[s];
                savedY[s] = Y[s];
            }

            // turns each block clockwise relative to block 1
            for (int t = 1; t <= numberofblocks; t++)
            {
                int relativex = X[t] - X[1];
                int relativey = Y[t] - Y[1];

                Y[t] = Y[1] + relativex;
                X[t] = X[1] - relativey;

                //flag turns on if new position is not clear
                if (X[t] > 9 || X[t] < 0 || Y[t] > 14 || Y[t] < 0 || filled[X[t], Y[t]] == 1)
                {
                    if (X[t] > highxpos)
                        highxpos = X[t];
                    else if (X[t] < lowxpos)
                        lowxpos = X[t];

                    flag = true;
                }
            }

            //if wall is in the way, move block over so it
            //will fit, otherwise reload original postiion
            if (flag)
            {
                bool flag2 = true;

                for (int u = 1; u <= numberofblocks; u++)
                {
                    if (X[u] > 5)
                        X[u] -= highxpos - 9;
                    else
                        X[u] += Math.Abs(lowxpos);

                    if (X[u] > 9 || X[u] < 0 || Y[u] > 14 || Y[u] < 0 || filled[X[u], Y[u]] == 1)
                    {
                        flag2 = false;
                        u = numberofblocks + 1;

                        for (int s = 1; s <= numberofblocks; s++)
                        {
                            X[s] = savedX[s];
                            Y[s] = savedY[s];
                        }
                    }
                }
                if (flag2)
                    spin.Play();
            }
            else
                spin.Play();

            UpdateGame();
            pnlGame.Refresh();
        }

        //drops and deactivates block
        private void DropBlock()
        {
            int counter = 0;
            int movedown = 999;

            Erase();

            //find dropped position
            for (int t = 1; t <= numberofblocks; t++)
            {
                while (true)
                {
                    if (Y[t] + counter > 14 || filled[X[t], Y[t] + counter] == 1)
                    {
                        if (counter - 1 < movedown)
                            movedown = counter - 1;
                        break;
                    }
                    counter++;
                }
                counter = 0;
            }

            //move active block
            for (int t = 1; t <= numberofblocks; t++)
                Y[t] += movedown;

            //increases score
            score += movedown * 10;
            UpdateScore();
            UpdateGame();
            DeactivateBlock();
            LineCheck();
        }

        //deactivates currently active block
        private void DeactivateBlock()
        {
            //prevents gameover sound and stick sound from
            //playing at the same time
            if (!over)
                stick.Play();
            activated = false;

            //changes active block to a fixed block
            for (int t = 1; t <= numberofblocks; t++)
            {
                filled[X[t], Y[t]] = 1;
            }

            if (!over)
                DetermineBlock(false);
        }

        //checks to see if a line is cleared
        private void LineCheck()
        {
            //counts the amount of cleared lines
            int linescleared = 0;

            for (int y = 0; y <= 15; y++)
            {
                //if whole line is filled with fixed blocks
                //then clear the line and move lines on top
                //down
                if (filled[0, y] == 1 && filled[1, y] == 1 && filled[2, y] == 1 && filled[3, y] == 1 && filled[4, y] == 1 && filled[5, y] == 1)
                {
                    if (filled[6, y] == 1 && filled[7, y] == 1 && filled[8, y] == 1 && filled[9, y] == 1)
                    {
                        for (int x = 0; x <= 10; x++)
                        {
                            filled[x, y] = 0;
                        }
                        MoveLinesDown(y);
                        linescleared++;
                    }
                }
            }

            //if a line was cleared, add to score and update
            //current game info
            if (linescleared > 0)
            {
                clear.Play();
                plusscore = Convert.ToInt32(Math.Pow(linescleared, 2) * 1000);
                score += plusscore;
                UpdateScore();
                lines += linescleared;
                LblLines.Text = lines.ToString();
                LevelUp();
            }
        }

        //moves lines down to replace a cleared line
        private void MoveLinesDown(int line)
        {
            //takes entire row of blocks and moves down
            //one row for every row above the cleared
            //line
            for (int y = line - 1; y >= 0; y--)
            {
                for (int x = 0; x <= 10; x++)
                {
                    int previouscolour;

                    if (filled[x, y] == 1)
                    {
                        previouscolour = colour[x, y];
                        filled[x, y] = 0;
                        filled[x, y + 1] = 1;
                        colour[x, y + 1] = previouscolour;
                    }
                }
            }

            clearedposition = (line * 50) - 50;
            DetermineTransBlock();
        }

        //updates current game info
        private void UpdateScore()
        {
            LblScore.Text = score.ToString();
            HighscoreUpdate();
            LblLines.Text = lines.ToString();
            LblLevel.Text = level.ToString();
        }

        //adjusts game settings according to level
        private void LevelUp()
        {
            level = Convert.ToInt32(lines / 10 + 1);
            LblLevel.Text = level.ToString();
            TimFrame.Interval = 1000 - (45 * (level - 1));
        }

        //checks for game over
        private void GameOverCheck()
        {
            for (int t = 1; t <= numberofblocks; t++)
            {
                if (filled[X[t], Y[t]] == 1)
                    GameOver();
            }
        }

        //stops current game
        private void GameOver()
        {
            Highscore();
            gmover.Play();
            over = true;
            pnlGame.Refresh();
            TimTime.Enabled = false;
            TimFrame.Enabled = false;
        }

        //refills active block position
        private void UpdateGame()
        {
            GameOverCheck();

            for (int t = 1; t <= numberofblocks; t++)
            {
                filled[X[t], Y[t]] = 2;
                colour[X[t], Y[t]] = activecolour;
            }

            DetermineTransBlock();
            pnlGame.Refresh();
        }

        //clears active block position
        private void Erase()
        {
            for (int t = 1; t <= numberofblocks; t++)
            {
                filled[X[t], Y[t]] = 0;
            }
        }

        //sets the game to new game values
        private void Reset()
        {
            Highscore();
            for (int y = 0; y <= 15; y++)
            {
                for (int x = 0; x <= 10; x++)
                {
                    filled[x, y] = 0;
                    colour[x, y] = 0;
                }
            }

            paused = false;
            seconds = 0;
            minutes = 0;
            score = 0;
            level = 1;
            lines = 0;
            LblTime.Text = "00:00";
            UpdateScore();
            over = false;
        }

        //draws on the form
        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            //called only once; no double buffering necessary
            Graphics g;
            g = this.CreateGraphics();
            g.DrawImage(formbackground, 0, 0, 1024, 768);
            g.DrawImage(nextblock, 800, 275, 150, 150);
            g.DrawImage(logo, 497, 11, logo.Width, logo.Height);
            g.DrawImage(info, 663, 252, info.Width, info.Height);
            g.Dispose();
        }

        //draws next block
        private void PaintForm()
        {
            //called rarely no double buffering necessary
            Graphics g;
            g = this.CreateGraphics();

            g.DrawImage(nextblock, 800, 275, 150, 150);
            if (activated)
                g.DrawImage(smallsquares[nexttype], 875 - (smallsquares[nexttype].Width / 2), 350 - (smallsquares[nexttype].Height / 2), smallsquares[nexttype].Width, smallsquares[nexttype].Height);

            g.Dispose();
        }

        //starts a new game
        private void PicStart_Click(object sender, EventArgs e)
        {
            Reset();
            pnlGame.Refresh();
            DetermineBlock(true);
            TimFrame.Enabled = true;
            TimTime.Enabled = true;
        }

        //toggles music on/off
        private void LblMusictoggle_Click(object sender, EventArgs e)
        {
            music = !music;

            //music on
            if (music)
                MediaPlayer.Ctlcontrols.play();
            //music off
            else
                MediaPlayer.Ctlcontrols.pause();
        }

        //closes game
        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    //double buffered panel
    public class PnlGame : Panel
    {
        public PnlGame()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }
}