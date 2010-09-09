using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tournamator
{
    public partial class RoundGenerator : Form
    {
        int tableX = 10;
        int labelX = 15;
        int startY = 10;
        int yIncrement = 25;
        int currentTable = 1;
        int totalPlayers = 0;

        bool isRandom = true;

        List<string> unMatchedPlayers;
        List<int> tableNums;
        Dictionary<string, int> matchedPlayers;

        //players is a sorted list with highest to lowest points
        public RoundGenerator(List<string> players, bool isRandom)
        {
            InitializeComponent();
            unMatchedPlayers = players;
            tableNums = new List<int>(players.Count);
            matchedPlayers = new Dictionary<string, int>();
            totalPlayers = players.Count;
            this.isRandom = isRandom;

            generateMatchups();
        }

        public void generateMatchups()
        {
            resetTables();
            int currentTableSeat = 1;
            string playerName = "";
            Random random = new Random();

            for (int i = 0; i < totalPlayers; i++)
            {
                if (isRandom)
                {
                    
                    playerName = unMatchedPlayers[random.Next(unMatchedPlayers.Count)];
                }
                else
                {
                    playerName = unMatchedPlayers.First().ToString();
                }

                unMatchedPlayers.Remove(playerName);
                matchedPlayers.Add(playerName, currentTable);

                if (currentTableSeat == 1)
                {
                    currentTableSeat = 2;
                }
                else
                {
                    currentTable++;
                    currentTableSeat = 1;
                }
            }

            createMatchupLayout();
            this.ShowDialog();
        }

        private void resetTables()
        {
            currentTable = 1;
        }

        private void createMatchupLayout()
        {
            int currentPlayer = 1;
            
            for (int i = 1; i <= matchedPlayers.Count; i++)
            {
                List<String> playersAtTable = findPlayersAtTable(matchedPlayers, i);

                if (playersAtTable.Count > 2)
                {
                    MessageBox.Show("Too many players at table: " + Convert.ToString(i));
                }
                else if (playersAtTable.Count == 2)
                {
                        Label table = new Label();
                        table.Text = "Table " + Convert.ToString(i);
                        table.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        table.Location = new Point(tableX, startY);
                        table.Parent = matchupPanel;

                        startY += yIncrement;

                        Label player1 = new Label();
                        player1.Text = "Player 1: " + playersAtTable[0];
                        player1.Location = new Point(labelX, startY);
                        player1.Parent = matchupPanel;

                        startY += yIncrement;

                        Label player2 = new Label();
                        player2.Text = "Player 2: " + playersAtTable[1];
                        player2.Location = new Point(labelX, startY);
                        player2.Parent = matchupPanel;

                        startY += yIncrement*2;

                }
            }
        }

        private List<String> findPlayersAtTable(Dictionary<string, int> lookup, int table)
        {
            List<String> keys = new List<string>();

            foreach (var pair in lookup)
            {
                if (Convert.ToInt32(pair.Value) == table)
                {
                    keys.Add(pair.Key.ToString());
                }
                    
            }
            return keys;
        }

    }
}
