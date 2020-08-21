﻿namespace AsteroidDodge
{
    partial class AsteroidDodge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsteroidDodge));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ast3 = new System.Windows.Forms.PictureBox();
            this.ast2 = new System.Windows.Forms.PictureBox();
            this.ast1 = new System.Windows.Forms.PictureBox();
            this.ship = new System.Windows.Forms.PictureBox();
            this.asteroid1 = new System.Windows.Forms.Timer(this.components);
            this.asteroid2 = new System.Windows.Forms.Timer(this.components);
            this.asteroid3 = new System.Windows.Forms.Timer(this.components);
            this.game = new System.Windows.Forms.Timer(this.components);
            this.pauseLabel = new System.Windows.Forms.Label();
            this.spawner = new System.Windows.Forms.Timer(this.components);
            this.score = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prevScore = new System.Windows.Forms.Label();
            this.Tutorial = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ast3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ast2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ast1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ast3);
            this.panel1.Controls.Add(this.ast2);
            this.panel1.Controls.Add(this.ast1);
            this.panel1.Controls.Add(this.ship);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 600);
            this.panel1.TabIndex = 0;
            // 
            // ast3
            // 
            this.ast3.Image = ((System.Drawing.Image)(resources.GetObject("ast3.Image")));
            this.ast3.Location = new System.Drawing.Point(178, 10);
            this.ast3.Margin = new System.Windows.Forms.Padding(10);
            this.ast3.Name = "ast3";
            this.ast3.Size = new System.Drawing.Size(75, 75);
            this.ast3.TabIndex = 3;
            this.ast3.TabStop = false;
            // 
            // ast2
            // 
            this.ast2.Image = ((System.Drawing.Image)(resources.GetObject("ast2.Image")));
            this.ast2.Location = new System.Drawing.Point(95, 10);
            this.ast2.Margin = new System.Windows.Forms.Padding(10);
            this.ast2.Name = "ast2";
            this.ast2.Size = new System.Drawing.Size(75, 75);
            this.ast2.TabIndex = 2;
            this.ast2.TabStop = false;
            // 
            // ast1
            // 
            this.ast1.Image = ((System.Drawing.Image)(resources.GetObject("ast1.Image")));
            this.ast1.Location = new System.Drawing.Point(10, 10);
            this.ast1.Margin = new System.Windows.Forms.Padding(10);
            this.ast1.Name = "ast1";
            this.ast1.Size = new System.Drawing.Size(75, 75);
            this.ast1.TabIndex = 1;
            this.ast1.TabStop = false;
            // 
            // ship
            // 
            this.ship.Image = ((System.Drawing.Image)(resources.GetObject("ship.Image")));
            this.ship.Location = new System.Drawing.Point(10, 468);
            this.ship.Margin = new System.Windows.Forms.Padding(10);
            this.ship.Name = "ship";
            this.ship.Size = new System.Drawing.Size(75, 120);
            this.ship.TabIndex = 0;
            this.ship.TabStop = false;
            // 
            // asteroid1
            // 
            this.asteroid1.Interval = 10;
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.BackColor = System.Drawing.SystemColors.InfoText;
            this.pauseLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.pauseLabel.Location = new System.Drawing.Point(307, 31);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(51, 13);
            this.pauseLabel.TabIndex = 1;
            this.pauseLabel.Text = "PAUSED";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.score.Location = new System.Drawing.Point(421, 522);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(13, 13);
            this.score.TabIndex = 2;
            this.score.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(307, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SCORE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(307, 548);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PREVIOUS SCORE: ";
            // 
            // prevScore
            // 
            this.prevScore.AutoSize = true;
            this.prevScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.prevScore.Location = new System.Drawing.Point(421, 548);
            this.prevScore.Name = "prevScore";
            this.prevScore.Size = new System.Drawing.Size(13, 13);
            this.prevScore.TabIndex = 5;
            this.prevScore.Text = "0";
            // 
            // Tutorial
            // 
            this.Tutorial.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Tutorial.Location = new System.Drawing.Point(310, 92);
            this.Tutorial.Name = "Tutorial";
            this.Tutorial.Size = new System.Drawing.Size(288, 47);
            this.Tutorial.TabIndex = 6;
            this.Tutorial.Text = "Tutorial: Use left and right keys to move the ship left and right. Press the \"P\" " +
    "button to toggle pause and/or start the game.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(307, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SPEED:";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.ForeColor = System.Drawing.SystemColors.Window;
            this.speed.Location = new System.Drawing.Point(421, 489);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(13, 13);
            this.speed.TabIndex = 8;
            this.speed.Text = "0";
            // 
            // AsteroidDodge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(610, 637);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tutorial);
            this.Controls.Add(this.prevScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.score);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "AsteroidDodge";
            this.Text = "AsteroidDodge";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ast3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ast2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ast1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ship)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ship;
        private System.Windows.Forms.Timer asteroid1;
        private System.Windows.Forms.Timer asteroid2;
        private System.Windows.Forms.Timer asteroid3;
        private System.Windows.Forms.PictureBox ast3;
        private System.Windows.Forms.PictureBox ast2;
        private System.Windows.Forms.PictureBox ast1;
        private System.Windows.Forms.Timer game;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Timer spawner;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label prevScore;
        private System.Windows.Forms.Label Tutorial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label speed;
    }
}

