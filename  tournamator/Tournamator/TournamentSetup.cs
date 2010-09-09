using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.SqlServerCe;
using System.Xml;
using System.IO;
using CrystalDecisions.Shared;
using System.Security.AccessControl;

namespace Tournamator
{
    public partial class TournamentSetup : Form
    {
        int round1Max = 0;
        int round2Max = 0;
        int round3Max = 0;
        int round4Max = 0;
        int round5Max = 0;
        int sportsmanshipScore = 0;
        int participationScore = 0;
        int paintingScore = 0;
        int onTime = 0;

        public TournamentSetup()
        {
            InitializeComponent();
        }

        public int getRound1Max() { return round1Max; }
        public void setRound1Max(int x) { round1Max = x; }

        public int getRound2Max() { return round2Max; }
        public void setRound2Max(int x) { round1Max = x; }

        public int getRound3Max() { return round3Max; }
        public void setRound3Max(int x) { round1Max = x; }

        public int getRound4Max() { return round4Max; }
        public void setRound4Max(int x) { round1Max = x; }

        public int getRound5Max() { return round5Max; }
        public void setRound5Max(int x) { round1Max = x; }

        public int getParticipationScore() { return participationScore; }
        public void setParticipationScore(int x) { participationScore = x; }

        public int getPaintingScore() { return paintingScore; }
        public void setPaintingScore(int x) { paintingScore = x; }

        public int getOnTimeScore() { return onTime; }
        public void setOnTimeScore(int x) { onTime = x; }

        public int getSportsmanshipScore() { return sportsmanshipScore; }
        public void setSportsmanshipScore(int x) { sportsmanshipScore = x; }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (round1MaxScore.Text.Equals(""))
            {
                MessageBox.Show("Round 1 score cannot be blank or negative");
                error = true;
            }
            else if (round2MaxScore.Text.Equals(""))
            {
                MessageBox.Show("Round 2 score cannot be blank or negative");
                error = true;
            }
            else if (round3MaxScore.Text.Equals(""))
            {
                MessageBox.Show("Round 3 score cannot be blank or negative");
                error = true;
            }
            else if (round4MaxScore.Text.Equals(""))
            {
                MessageBox.Show("Round 4 score cannot be blank or negative");
                error = true;
            }
            else if (round5MaxScore.Text.Equals(""))
            {
                MessageBox.Show("Round 5 score cannot be blank or negative");
                error = true;
            }
            else if (numPaintingScore.Text.Equals(""))
            {
                MessageBox.Show("Painting score cannot be blank or negative");
                error = true;
            }
            else if (numParticipationScore.Text.Equals(""))
            {
                MessageBox.Show("Participation score cannot be blank or negative");
                error = true;
            }
            else if (onTimeScore.Text.Equals(""))
            {
                MessageBox.Show("On time score cannot be blank or negative");
                error = true;
            }
            else if (numSportsmanshipScore.Text.Equals(""))
            {
                MessageBox.Show("Sportsmanship score cannot be blank or negative");
                error = true;
            }

            if (!error)
            {
                round1Max = Convert.ToInt32(round1MaxScore.Text);
                round2Max = Convert.ToInt32(round2MaxScore.Text);
                round3Max = Convert.ToInt32(round3MaxScore.Text);
                round4Max = Convert.ToInt32(round4MaxScore.Text);
                round5Max = Convert.ToInt32(round5MaxScore.Text);
                sportsmanshipScore = Convert.ToInt32(numSportsmanshipScore.Text);
                participationScore = Convert.ToInt32(numParticipationScore.Text);
                paintingScore = Convert.ToInt32(numPaintingScore.Text);
                onTime = Convert.ToInt32(onTimeScore.Text);
                
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

    }
}
