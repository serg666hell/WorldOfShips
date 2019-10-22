using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using SeaWar.Domain;

namespace SeaWar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Label[] v;

        private Label[] h;


        private void GetLabels()
        {
            List<Label> labels = this.Controls.OfType<Label>().ToList();
            foreach (Label lbl in labels)
            {
                 lbl.Text = "X";
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            GetLabels();
            var game = new Game();
            game.initPlayers();
            var gamePlayer = game.Player;
            var board = gamePlayer.Board;
           h1.Text = board.HorizontalLabels[0];
            
        }
    }
}