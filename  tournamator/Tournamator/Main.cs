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
    public partial class Main : Form
    {
        private const int NAME_COLUMN = 1;
        private const int ROUND1_COLUMN = 3;
        private const int ROUND2_COLUMN = 4;
        private const int ROUND3_COLUMN = 5;
        private const int ROUND4_COLUMN = 6;
        private const int ROUND5_COLUMN = 7;
        private const int SPORTSMANSHIP_COLUMN = 8;
        private const int PAINTING_COLUMN = 9;
        private const int COMP_COLUMN = 10;

        private DataTable playerInfoTable;
        private DataTable maxScores;

        public string currentTournamentName = "";
        int round1Max = 0;
        int round2Max = 0;
        int round3Max = 0;
        int round4Max = 0;
        int round5Max = 0;
        int participationMaxScore = 0;
        int paintingMaxScore = 0;
        int compMaxScore = 0;
        int onTimeScore = 0;
        int sportsmanshipMaxScore = 0;
        public bool needToSave = false;
        public bool bypass = false;
        public bool opening = false;

        private readonly string path = "C:\\Tournamator\\";
        private readonly string maxScoresPath = "C:\\Tournamator\\MaxScores.xml";

        public Main()
        {
            InitializeComponent();

            //create new playerInfoTable
            playerInfoTable = new PlayerInfoDataSet.PlayerPointsDataTable();
            playerInfoTable.Clear();

            //create new maxScores table
            maxScores = new PlayerInfoDataSet.MaxScoresDataTable();
            maxScores.Clear();

            //bind the playerStatsView to the newly created playerInfoTable
            playerStatsView.DataSource = playerInfoTable;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            TournamentSetup setupWindow = new TournamentSetup();
            if (setupWindow.ShowDialog() == DialogResult.OK)
            {
                round1Max = setupWindow.getRound1Max();
                round2Max = setupWindow.getRound2Max();
                round3Max = setupWindow.getRound3Max();
                round4Max = setupWindow.getRound4Max();
                round5Max = setupWindow.getRound5Max();
                sportsmanshipMaxScore = setupWindow.getSportsmanshipScore();
                participationMaxScore = setupWindow.getParticipationScore();
                paintingMaxScore = setupWindow.getPaintingScore();
                onTimeScore = setupWindow.getOnTimeScore();

                
                //add the maxScores row to the MaxScores table
                DataRow row = maxScores.NewRow();
                row["MaxRound1"] = round1Max;
                row["MaxRound2"] = round2Max;
                row["MaxRound3"] = round3Max;
                row["MaxRound4"] = round4Max;
                row["MaxRound5"] = round5Max;
                row["MaxParticipation"] = paintingMaxScore;
                row["MaxPainting"] = paintingMaxScore;
                row["MaxSportsmanship"] = sportsmanshipMaxScore;

                maxScores.Rows.Add(row);
               
            }

            //setAvailableGridView();

            //updateButtons();
        }


        public DirectorySecurity getDirectorySecurity(string dir)
        {
            DirectoryInfo info = new DirectoryInfo(dir);
            DirectorySecurity ds = info.GetAccessControl();
            ds.AddAccessRule(new FileSystemAccessRule(@"BUILTIN\Users",
                                 FileSystemRights.FullControl,
                                 InheritanceFlags.ContainerInherit,
                                 PropagationFlags.None,
                                 AccessControlType.Allow));

            //info.SetAccessControl(ds);
            return ds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'playerInfoDataSet.PlayerPoints' table. You can move, or remove it, as needed.
            //this.playerPointsTableAdapter.Fill(this.playerInfoDataSet.PlayerPoints);
        }

        //public void addCharacter_Click(object sender, EventArgs e)
        //{
        //    DataView view;
        //    DataRow row;

        //    //if the current list is not set then create a new list
        //    if (currentTournamentName == "")
        //    {
        //        this.newList();
        //    }

        //    if (availableGridView.Rows.Count > 1)
        //    {
        //        //add the selected row to the playerInfoTable
        //        row = playerInfoTable.NewRow();
        //        row["Race"] = availableGridView.SelectedCells[0].Value;
        //        row["CharacterName"] = availableGridView.SelectedCells[1].Value;
        //        row["Movement"] = availableGridView.SelectedCells[2].Value;
        //        row["WeaponSkill"] = availableGridView.SelectedCells[3].Value;
        //        row["BalisticSkill"] = availableGridView.SelectedCells[4].Value;
        //        row["Strength"] = availableGridView.SelectedCells[5].Value;
        //        row["Toughness"] = availableGridView.SelectedCells[6].Value;
        //        row["Wounds"] = availableGridView.SelectedCells[7].Value;
        //        row["Initiative"] = availableGridView.SelectedCells[8].Value;
        //        row["Attacks"] = availableGridView.SelectedCells[9].Value;
        //        row["Leadership"] = availableGridView.SelectedCells[10].Value;
        //        row["Save"] = availableGridView.SelectedCells[11].Value;
        //        row["Skills"] = availableGridView.SelectedCells[12].Value;
        //        row["Equipment"] = availableGridView.SelectedCells[13].Value;
        //        row["Notes"] = availableGridView.SelectedCells[14].Value;
        //        row["Cost"] = availableGridView.SelectedCells[15].Value;

        //        playerInfoTable.Rows.Add(row);

        //        //Set the playerStatsView to the table so the view is updated
        //        view = new DataView(playerInfoTable);

        //        //Update the points spent
        //        updatePointsSpent();

        //        needToSave = true;
        //    }

        //    updateButtons();
        //}

        //public void setAvailableGridView()
        //{
        //    charactersBindingSource.Filter = "Race = '" + currentRace + "'";
        //    weaponsBindingSource.Filter = "Race = '" + currentRace + "'" + " OR Race = 'All'";
        //    availableGridView.Columns[0].Visible = false;
        //}

        private void newFile()
        {
            if (needToSave)
            {
                showSaveWarning();
            }

            if (!needToSave)
            {
                CurrentTournamentNameForm FileNameForm = new CurrentTournamentNameForm();
                DialogResult result = FileNameForm.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    currentTournamentName = FileNameForm.getFileName();

                    //create new playerInfo table
                    playerInfoTable = new PlayerInfoDataSet.PlayerPointsDataTable();
                    playerInfoTable.Clear();

                    //create new maxScores table
                    maxScores = new PlayerInfoDataSet.MaxScoresDataTable();
                    maxScores.Clear();
                    
                    //bind the playerStatsView to the newly created playerInfoTable
                    playerStatsView.DataSource = playerInfoTable;

                    //Update the points spent
                    //updatePointsSpent();

                    needToSave = false;

                    //setAvailableGridView();

                    //update the current list name in the database
                    setFileName();
                }
            }

            //updateButtons();
        }

        private void setFileName()
        {
            playerInfoDataSet.FileDetails.Clear();

            //need to set the text of the main window so need to strip out path from filename.
            if (currentTournamentName.Contains(".xml"))
            {
                int startIndex = currentTournamentName.LastIndexOf("\\") + 1;
                int endIndex = currentTournamentName.LastIndexOf(".");
                int len = endIndex - startIndex;
                currentTournamentName = currentTournamentName.Substring(startIndex, len);
            }
            playerInfoDataSet.FileDetails.AddFileDetailsRow(currentTournamentName);

            this.Text = "Tournamator - " + currentTournamentName;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        public void LoadData()
        {
            string fileName = currentTournamentName;

            //read in the selected XML file and load it into the database
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.CloseInput = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.IgnoreWhitespace = true;
            XmlReader reader = XmlReader.Create(fileName, settings);

            playerInfoTable.Clear();
            maxScores.Clear();

            try
            {
                playerInfoTable.ReadXml(fileName);
                maxScores.ReadXml(maxScoresPath);
                reader.Close();
            }
            catch
            {
                reader.Close();
                newFile();
            }

            //update the current list name in the database
            setFileName();

            //Update the points spent
            //updatePointsSpent();

            needToSave = false;

            //updateButtons();
        }

        /// <summary>
        /// Saves the data to the XML file
        /// </summary>
        public void SaveData(string fileName)
        {
            //if (currentTournamentName == "")
            //{
            //    saveFileDialog.Filter = "Tournamator|*.xml";
            //    saveFileDialog.InitialDirectory = path;
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
                    
            //        SaveData(currentTournamentName);
            //    }
            //}
            //write the datatables out to an XML file 
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CloseOutput = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Encoding = System.Text.Encoding.UTF8;
            settings.Indent = true;
            
            //write playerInfoTable to file
            XmlWriter playerInfoWriter = XmlWriter.Create(fileName, settings);
            playerInfoTable.WriteXml(playerInfoWriter, XmlWriteMode.WriteSchema);
            playerInfoWriter.Flush();
            playerInfoWriter.Close();

            //write maxScores table to file
            XmlWriter maxScoresWriter = XmlWriter.Create(fileName.Substring(0, fileName.LastIndexOf('\\') + 1) + "MaxScores.xml", settings);
            maxScores.WriteXml(maxScoresWriter, XmlWriteMode.WriteSchema);
            maxScoresWriter.Flush();
            maxScoresWriter.Close();

            needToSave = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentTournamentName == "")
            {
                saveFileDialog.Filter = "Tournamator|*.xml";
                saveFileDialog.InitialDirectory = path;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveData(currentTournamentName);
                }
            }
            else if (!currentTournamentName.Contains(".xml"))
            {
                SaveData(path + currentTournamentName + ".xml");
            }
            else
            {
                SaveData(currentTournamentName);
            } 
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            currentTournamentName = saveFileDialog.FileName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Tournamator|*.xml";
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.ShowDialog();

            SaveData(currentTournamentName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (needToSave)
            {
                showSaveWarning();
            }

            opening = true;
            openFileDialog.InitialDirectory = "C:\\Tournamator\\";
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //get the file name of the selected file to open and then load the data
            currentTournamentName = openFileDialog.FileName;
            resetValues();
            LoadData();
            opening = false;
        }

        private void resetValues()
        {
            round1Max = 0;
            round2Max = 0;
            round3Max = 0;
            round4Max = 0;
            round5Max = 0;
            participationMaxScore = 0;
            paintingMaxScore = 0;
            compMaxScore = 0;
            sportsmanshipMaxScore = 0;
        }

        //private void removeCharacter_Click(object sender, EventArgs e)
        //{
        //    if (playerInfoTable.Rows.Count > 0)
        //    {
        //        //get the selected index and remove it from the table
        //        int selectedID = playerStatsView.CurrentRow.Index;
        //        playerInfoTable.Rows[selectedID].Delete();

        //        //Update the points spent
        //        updatePointsSpent();

        //        needToSave = true;
        //    }

        //    updateButtons();
        //}

        //private void selectWeapon_Click(object sender, EventArgs e)
        //{
        //    int cost;

        //    if (playerInfoTable.Rows.Count > 0)
        //    {
        //        int location = playerStatsView.SelectedRows[0].Index;
        //        DataRow selRow = playerInfoTable.Rows[location];
        //        string selRace = selRow["Race"].ToString();

        //        if (selRace != "Hired Swords" && selRace != "Dramatis Personae")
        //        {
        //            //Append the weapon into the equipment of the selected character
        //            if (playerStatsView.SelectedCells[14].Value.ToString() == "" || playerStatsView.SelectedCells[14].Value.ToString() == " ")
        //            {
        //                playerStatsView.SelectedCells[14].Value = weaponsGridView.SelectedCells[0].Value.ToString();
        //            }
        //            else
        //            {
        //                playerStatsView.SelectedCells[14].Value = playerStatsView.SelectedCells[14].Value.ToString() + ", " + weaponsGridView.SelectedCells[0].Value.ToString();
        //            }
        //            //Add the cost of the weapon to the cost of the character
        //            if (playerStatsView.SelectedCells[16].Value.ToString() == " ")
        //            {
        //                cost = 0 + System.Convert.ToInt32(weaponsGridView.SelectedCells[1].Value);
        //            }
        //            else
        //            {
        //                cost = System.Convert.ToInt32(playerStatsView.SelectedCells[16].Value) + System.Convert.ToInt32(weaponsGridView.SelectedCells[1].Value);
        //            }
        //            playerStatsView.SelectedCells[16].Value = cost.ToString();

        //            //Update the points spent
        //            updatePointsSpent();

        //            needToSave = true;
        //        }
        //    }
        //}

        //private void updatePointsSpent()
        //{
        //    totalSpent = 0;

        //    foreach (DataRow theRow in playerInfoTable.Rows)//playerInfoDataSet.Tables["SelectedCharacters"].Rows)
        //    {
        //        if (theRow["Cost"].ToString() == " ")
        //        {
        //            totalSpent = totalSpent + 0;
        //        }
        //        else
        //        {
        //            totalSpent = totalSpent + System.Convert.ToInt32(theRow["Cost"]);
        //        }
        //        lblPointsSpent.Text = totalSpent.ToString();
        //    }

        //    if (playerInfoTable.Rows.Count == 0)
        //    {
        //        totalSpent = 0;
        //        lblPointsSpent.Text = totalSpent.ToString();
        //    }

        //    if (totalSpent > maxPoints)
        //    {
        //        pnlPoints.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        pnlPoints.ForeColor = Color.White;
        //    }
        //}

        public void showSaveWarning()
        {
            SaveWarning saveWarning = new SaveWarning();
            saveWarning.ShowDialog();

            if (saveWarning.DialogResult == DialogResult.OK)
            {
                needToSave = false;
            }

            saveWarning.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void armyRaceMenuItem_Click(object sender, EventArgs e)
        //{
        //    cmbRace.SelectedItem = sender.ToString();

        //    if (availableGridView.Rows.Count > 1)
        //    {

        //        setAvailableGridView();
        //    }
        //    else
        //    {
        //        cmbRace.Text = "Select Race...";
        //    }
        //}

        //private void cmbRace_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (needToSave && !bypass)
        //    {
        //        showSaveWarning();
        //    }

        //    if (!needToSave)
        //    {
        //        currentRace = cmbRace.Text;

        //        if ((availableGridView.Rows.Count > 1) || (currentTournamentName == ""))
        //        {
        //            newList();
        //        }

        //        if (availableGridView.Rows.Count > 1 || currentTournamentName != "")
        //        {
        //            setAvailableGridView();
        //            bypass = false;
        //        }
        //    }
        //    else
        //    {
        //        //needed to bypass the saveWarning because it would get called again
        //        //when changing the selected item or text
        //        bypass = true;
        //        cmbRace.SelectedItem = currentRace;
        //        bypass = false;
        //    }
        //}

        private void fakeEnterPressed()
        {
            SendKeys.Send("{ENTER}");
            SendKeys.Flush();
        }

        private void printList()
        {

            //fake the enter key pressed so the row changes get committed.  The changes wouldnt
            //print if the enter key wasnt pressed on the current edited row.
            fakeEnterPressed();

            //create the reportList
            ListReport list = new ListReport();

            //Open the PrintDialog
            PrintDialog printDlg = new PrintDialog();
            DialogResult dr = printDlg.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = printDlg.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = printDlg.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = printDlg.PrinterSettings.ToPage;
                //Get the printer name
                string PrinterName = printDlg.PrinterSettings.PrinterName;

                try
                {
                    //Set the printer name to print the report to. By default the sample
                    //report does not have a defult printer specified. This will tell the
                    //engine to use the specified printer to print the report. Print out 
                    //a test page (from Printer properties) to get the correct value.
                    list.PrintOptions.PrinterName = PrinterName;

                    //need to set the datasource or it wont work
                    list.SetDataSource(playerInfoTable);

                    //refresh the data
                    list.Refresh();

                    //get the list name and send it as a parameter to print
                    DataRow theRow = playerInfoDataSet.FileDetails.Rows[0];
                    list.SetParameterValue("nameOfList", theRow["FileName"]);

                    //Start the printing process. Provide details of the print job
                    //using the arguments.
                    list.PrintToPrinter(nCopy, false, sPage, ePage);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void printToFile(string fileName)
        {
            ListReport list = new ListReport();

            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = fileName;
                CrExportOptions = list.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }

                //need to set the datasource or it wont work
                list.SetDataSource(playerInfoTable);

                //refresh the data
                list.Refresh();

                DataRow theRow = playerInfoDataSet.FileDetails.Rows[0];
                list.SetParameterValue("nameOfList", theRow["FileName"]);

                list.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //private void updateButtons()
        //{
        //    //removeCharacter.Enabled = playerStatsView.Rows.Count > 1;
        //    //addCharacter.Enabled = availableGridView.Rows.Count > 1;
        //    //addWeapon.Enabled = playerStatsView.Rows.Count > 1;            
        //}

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printList();
        }

        //private void hiredSwordsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    charactersBindingSource.Filter = "Race = 'Hired Swords'";
        //}

        //private void dramatisPersonaeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    charactersBindingSource.Filter = "Race = 'Dramatis Personae'";
        //}

        //private void playerStatsView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //need to update the cost if you remove weapons and change the cost value.
        //    if (playerInfoTable != null)
        //    {
        //        updatePointsSpent();
        //    }
        //}

        private void toolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            ToolStripMenuItem test = (ToolStripMenuItem)sender;
            Font highlightFont = new Font("Tahoma", (float)8.25, FontStyle.Bold);

            if (test.Selected)
            {
                e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
                Rectangle rect = e.ClipRectangle;
                rect.X += 34;
                rect.Width -= 34;
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString(test.ToString(), highlightFont, Brushes.Black, rect, sf);
                test.ShowShortcutKeys = true;
                test.ShortcutKeyDisplayString = "Ctrl+N";
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //About aboutWindow = new About();
            //aboutWindow.ShowDialog();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (playerInfoTable.Rows.Count > 1)
            {
                int location = playerStatsView.SelectedRows[0].Index;

                if (location > 0)
                {
                    DataRow currentRow = playerInfoTable.NewRow();

                    try
                    {
                        currentRow.ItemArray = playerInfoTable.Rows[location].ItemArray;

                        DataRow previousRow = playerInfoTable.Rows[location - 1];

                        //set the current row values with the values of the previous one
                        DataRow cr = playerInfoTable.Rows[location];

                        cr["PlayerName"] = previousRow["PlayerName"];
                        cr["Round1"] = previousRow["Round1"];
                        cr["Round2"] = previousRow["Round2"];
                        cr["Round3"] = previousRow["Round3"];
                        cr["Round4"] = previousRow["Round4"];
                        cr["Round5"] = previousRow["Round5"];
                        cr["Sportsmanship"] = previousRow["Sportsmanship"];
                        cr["Painting"] = previousRow["Painting"];
                        cr["Comp"] = previousRow["Comp"];
                        
                        //set the previous row values with the values of the current one
                        DataRow pr = playerInfoTable.Rows[location - 1];

                        pr["PlayerName"] = currentRow["PlayerName"];
                        pr["Round1"] = currentRow["Round1"];
                        pr["Round2"] = currentRow["Round2"];
                        pr["Round3"] = currentRow["Round3"];
                        pr["Round4"] = currentRow["Round4"];
                        pr["Round5"] = currentRow["Round5"];
                        pr["Sportsmanship"] = currentRow["Sportsmanship"];
                        pr["Painting"] = currentRow["Painting"];
                        pr["Comp"] = currentRow["Comp"];
                        
                        playerStatsView.Rows[location - 1].Selected = true;
                    }
                    catch
                    {
                        //do nothing. 
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {

            int location = playerStatsView.SelectedRows[0].Index;

            if (playerInfoTable.Rows.Count > location)
            {
                DataRow currentRow = playerInfoTable.NewRow();

                try
                {
                    currentRow.ItemArray = playerInfoTable.Rows[location].ItemArray;

                    DataRow nextRow = playerInfoTable.Rows[location + 1];

                    //set the current row values with the values of the next row
                    DataRow cr = playerInfoTable.Rows[location];

                    cr["PlayerName"] = nextRow["PlayerName"];
                    cr["Round1"] = nextRow["Round1"];
                    cr["Round2"] = nextRow["Round2"];
                    cr["Round3"] = nextRow["Round3"];
                    cr["Round4"] = nextRow["Round4"];
                    cr["Round5"] = nextRow["Round5"];
                    cr["Sportsmanship"] = nextRow["Sportsmanship"];
                    cr["Painting"] = nextRow["Painting"];
                    cr["Comp"] = nextRow["Comp"];

                   
                    //set the values of the next row with the values of the current one
                    DataRow pr = playerInfoTable.Rows[location + 1];

                    pr["PlayerName"] = currentRow["PlayerName"];
                    pr["Round1"] = currentRow["Round1"];
                    pr["Round2"] = currentRow["Round2"];
                    pr["Round3"] = currentRow["Round3"];
                    pr["Round4"] = currentRow["Round4"];
                    pr["Round5"] = currentRow["Round5"];
                    pr["Sportsmanship"] = currentRow["Sportsmanship"];
                    pr["Painting"] = currentRow["Painting"];
                    pr["Comp"] = currentRow["Comp"];

                    playerStatsView.Rows[location + 1].Selected = true;
                }
                catch
                {
                    //do nothing. 
                }
            }
        }

        //private void editCharacter_Click(object sender, EventArgs e)
        //{
        //    int location = playerStatsView.SelectedRows[0].Index;

        //    if (playerStatsView.Rows.Count > 1 && location < playerInfoTable.Rows.Count)
        //    {
        //        EditCharacter edtChar = new EditCharacter((Array)playerInfoTable.Rows[location].ItemArray);
        //        DialogResult dr = edtChar.ShowDialog();
        //        if (dr == DialogResult.OK)
        //        {
        //            Array edtItemsArray = edtChar.getEditItemArray();
        //            DataRow cr = playerInfoTable.Rows[location];

        //            cr["CharacterName"] = edtItemsArray.GetValue(2).ToString();
        //            cr["WeaponSkill"] = edtItemsArray.GetValue(3).ToString();
        //            cr["BalisticSkill"] = edtItemsArray.GetValue(4).ToString();
        //            cr["Strength"] = edtItemsArray.GetValue(5).ToString();
        //            cr["Toughness"] = edtItemsArray.GetValue(6).ToString();
        //            cr["Attacks"] = edtItemsArray.GetValue(7).ToString();
        //            cr["Initiative"] = edtItemsArray.GetValue(8).ToString();
        //            cr["Leadership"] = edtItemsArray.GetValue(9).ToString();
        //            cr["Save"] = edtItemsArray.GetValue(10).ToString();
        //            cr["Skills"] = edtItemsArray.GetValue(11).ToString();
        //            cr["Notes"] = edtItemsArray.GetValue(12).ToString();
        //            cr["Cost"] = edtItemsArray.GetValue(13).ToString();
        //            cr["Equipment"] = edtItemsArray.GetValue(14).ToString();
        //            cr["Movement"] = edtItemsArray.GetValue(15).ToString();
        //            cr["Wounds"] = edtItemsArray.GetValue(16).ToString();

        //            updatePointsSpent();
        //        }
        //    }
        //}

        //private void addWeapon_Click(object sender, EventArgs e)
        //{
        //    AddWeapon weapon = new AddWeapon();
        //    string weaponRace;
        //    string weaponName;
        //    string weaponCost;
        //    string weaponRarity;

        //    if (weapon.ShowDialog() == DialogResult.OK)
        //    {
        //        weaponRace = weapon.getRace();
        //        weaponName = weapon.getWeaponName();
        //        weaponCost = weapon.getWeaponCost();
        //        weaponRarity = weapon.getRarity();

        //        // Add the row to the Weapons table
        //        int index = this.playerInfoDataSet.Weapons.Rows.Count + 1;
        //        string[] newRow = new string[5];
        //        newRow.SetValue(index.ToString(), 0);
        //        newRow.SetValue(weaponName, 1);
        //        newRow.SetValue(weaponCost, 2);
        //        newRow.SetValue(weaponRarity, 3);
        //        newRow.SetValue(weaponRace, 4);

        //        this.playerInfoDataSet.Weapons.Rows.Add(newRow);

        //        // Save the new row to the database
        //        this.weaponsTableAdapter.Update(this.playerInfoDataSet.Weapons);
        //        this.playerInfoDataSet.AcceptChanges();
        //    }
        //}

        private void printToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "PDF|*.pdf";
            saveDlg.InitialDirectory = path;
            saveDlg.FileName = currentTournamentName;

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                printToFile(saveDlg.FileName);
            }
        }

        private void playerStatsView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            bool error = false;
            int cellValue = 0;

            if (e.ColumnIndex > 2)
            {
                playerStatsView.EndEdit();
                string temp = playerStatsView[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (temp != "")
                {
                    try
                    {
                        cellValue = int.Parse(temp);
                    }
                    catch (Exception ex)
                    {
                        playerStatsView.Rows[e.RowIndex].ErrorText = "Value must be a non-negative integer.";
                    }
                }
            }

            //if (e.ColumnIndex = ROUND1_COLUMN)
            switch (e.ColumnIndex)
            {
                case ROUND1_COLUMN:
                    if (cellValue > round1Max)
                    {
                        error = true;
                    }
                    break;
                case ROUND2_COLUMN:
                    if (cellValue > round2Max)
                    {
                        error = true;
                    }
                    break;
                case ROUND3_COLUMN:
                    if (cellValue > round3Max)
                    {
                        error = true;
                    }
                    break;
                case ROUND4_COLUMN:
                    if (cellValue > round4Max)
                    {
                        error = true;
                    }
                    break;
                case ROUND5_COLUMN:
                    if (cellValue > round5Max)
                    {
                        error = true;
                    }
                    break;
                case PAINTING_COLUMN:
                    if (cellValue > paintingMaxScore)
                    {
                        error = true;
                    }
                    break;
                case SPORTSMANSHIP_COLUMN:
                    if (cellValue > sportsmanshipMaxScore)
                    {
                        error = true;
                    }
                    break;
                case COMP_COLUMN:
                    if (cellValue > compMaxScore)
                    {
                        error = true;
                    }
                    break;                
            }


            if (!error && !opening)
            {
                saveToolStripMenuItem_Click(sender, (EventArgs)e);
            }
            else
            {
                MessageBox.Show("Value entered is greater than maximum allowed value.");
                playerStatsView.Rows[e.RowIndex].ErrorText = "Value entered is greater than maximum allowed value.";
            }
            
        }

        private void playerStatsView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            playerStatsView.Rows[e.RowIndex].ErrorText = "";
            int newInteger;

            if (e.ColumnIndex > 1)
            {
                // Don't try to validate the 'new row' until finished 
                // editing since there
                // is not any point in validating its initial value.
                if (playerStatsView.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    playerStatsView.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
                }
            }
        }

        private void btnGenerateRound_Click(object sender, EventArgs e)
        {
            List<string> players = new List<string>();
            ListSortDirection currSortDirection;

            //get the current sorted column so it can be set back after sorting by the total
            DataGridViewColumn currSortedColumn = playerStatsView.SortedColumn;
            if (playerStatsView.SortOrder == SortOrder.Ascending)
            {
                currSortDirection = ListSortDirection.Ascending;
            }
            else
            {
                currSortDirection = ListSortDirection.Descending;
            }

            //sort the list from total to least points so correct matchups will be generated
            playerStatsView.Sort(playerStatsView.Columns["Total"], ListSortDirection.Descending);

            foreach (DataGridViewRow row in playerStatsView.Rows)
            {
                string playerName = "";

                if (row.Cells[NAME_COLUMN].Value != null)
                {
                    playerName = row.Cells[NAME_COLUMN].Value.ToString();
                }
                
                if (!String.IsNullOrEmpty(playerName))
                {
                    players.Add(playerName);
                }
            }

            //sort the table back the way the user had it before sorting on the total
            if (currSortedColumn != null)
            {
                playerStatsView.Sort(currSortedColumn, currSortDirection);
            }

            RoundGenerator roundGenerator = new RoundGenerator(players, ckRandom.Checked);
        }
    }
}
