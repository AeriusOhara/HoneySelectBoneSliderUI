using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace HoneySelectBoneSliderUI
{
    public partial class mainForm : Form
    {
        public List<sliderEntry> boneSliderDatabase = new List<sliderEntry>();
        string fileName;
        ToolTip numberDisplay;
        DBLayoutPanel slidersTable = new DBLayoutPanel();

        public mainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        private void loadBoneInfoFile_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        public void loadFile()
        {
            // Disable the button during the processing
            loadBoneInfoFile.Enabled = false;

            OpenFileDialog fileDialog = new OpenFileDialog();
            StreamReader fileHandle;

            this.Controls.Remove(slidersTable);
            slidersTable = new DBLayoutPanel();
            slidersTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top)));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            slidersTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            slidersTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            slidersTable.ColumnCount = 6;
            slidersTable.Location = new Point(0, 65);
            slidersTable.Size = new Size(600, 35);
            slidersTable.Padding = new Padding(15, 0, 15, 0);
            slidersTable.Margin = new Padding(0, 0, 0, 0);

            // Hide table while it's being populated to its performance hog
            slidersTable.Visible = false;
            slidersTable.Controls.Clear();
            slidersTable.SuspendLayout();

            bool sliderValueOutOfBounds = false;
            fileDialog.InitialDirectory = Properties.Settings.Default.HoneySelectFolderPath;
            fileDialog.Filter = "bonemod txt files (*.bonemod.txt)|*.bonemod.txt;*.png";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
            }

            string line;
            int counter = 0;
            try
            {
                fileHandle = new StreamReader(fileName);
                while ((line = fileHandle.ReadLine()) != null)
                {
                    double tmpValue;
                    string[] values = line.Split(',');

                    // Build a database of entries
                    sliderEntry tmpEntry = new sliderEntry();
                    tmpEntry.boneID = Int32.Parse(values[0]);
                    tmpEntry.boneName = values[1];
                    tmpEntry.boneEnabled = (values[2] == "True") ? true : false;
                    tmpEntry.boneXValue = Double.Parse(values[3]);
                    tmpEntry.boneYValue = Double.Parse(values[4]);
                    tmpEntry.boneZValue = Double.Parse(values[5]);
                    tmpEntry.boneScale = Double.Parse(values[6]);
                    tmpEntry.textFilePos = (counter + 1);
                    boneSliderDatabase.Add(tmpEntry);

                    // Populate the table with the below controls
                    // [Label, checkbox, slider, slider, slider, slider]
                    Label tmpLabel = new Label();
                    tmpLabel.Font = new Font(FontFamily.GenericSansSerif, 7);
                    tmpLabel.Text = values[1] + "\n";
                    tmpLabel.Tag = counter;

                    CheckBox tmpCheckBox = new CheckBox();
                    tmpCheckBox.Checked = (values[2] == "True") ? true : false;
                    tmpCheckBox.Tag = counter;
                    tmpCheckBox.CheckedChanged += checkBoxChanged;

                    TrackBar tmpXTrackBar = new TrackBar();
                    tmpXTrackBar.Minimum = (int)(minSliderValue.Value * 10);
                    tmpXTrackBar.Maximum = (int)(maxSliderValue.Value * 10);
                    tmpValue = (Double.Parse(values[3]) * 10);
                    try { tmpXTrackBar.Value = (int)tmpValue; }
                    catch
                    {
                        tmpXTrackBar.Value = (tmpValue > tmpXTrackBar.Maximum) ? tmpXTrackBar.Maximum : tmpXTrackBar.Minimum;
                        sliderValueOutOfBounds = true;
                    }
                    tmpXTrackBar.Tag = "x," + counter;
                    tmpXTrackBar.LargeChange = 1;
                    tmpXTrackBar.ValueChanged += sliderChanged;
                    tmpXTrackBar.MouseEnter += sliderMouseEnter;
                    tmpXTrackBar.AutoSize = true;

                    TrackBar tmpYTrackBar = new TrackBar();
                    tmpYTrackBar.Minimum = (int)(minSliderValue.Value * 10);
                    tmpYTrackBar.Maximum = (int)(maxSliderValue.Value * 10);
                    tmpValue = (Double.Parse(values[4]) * 10);
                    try { tmpYTrackBar.Value = (int)tmpValue; }
                    catch {
                        tmpYTrackBar.Value = (tmpValue > tmpYTrackBar.Maximum) ? tmpYTrackBar.Maximum : tmpYTrackBar.Minimum;
                        sliderValueOutOfBounds = true;
                    }
                    tmpYTrackBar.Tag = "y," + counter;
                    tmpYTrackBar.LargeChange = 1;
                    tmpYTrackBar.ValueChanged += sliderChanged;
                    tmpYTrackBar.MouseEnter += sliderMouseEnter;
                    tmpYTrackBar.AutoSize = true;

                    TrackBar tmpZTrackBar = new TrackBar();
                    tmpZTrackBar.Minimum = (int)(minSliderValue.Value * 10);
                    tmpZTrackBar.Maximum = (int)(maxSliderValue.Value * 10);
                    tmpValue = (Double.Parse(values[5]) * 10);
                    try { tmpZTrackBar.Value = (int)tmpValue; }
                    catch {
                        tmpZTrackBar.Value = (tmpValue > tmpZTrackBar.Maximum) ? tmpZTrackBar.Maximum : tmpZTrackBar.Minimum;
                        sliderValueOutOfBounds = true;
                    }
                    tmpZTrackBar.Tag = "z," + counter;
                    tmpZTrackBar.LargeChange = 1;
                    tmpZTrackBar.ValueChanged += sliderChanged;
                    tmpZTrackBar.MouseEnter += sliderMouseEnter;
                    tmpZTrackBar.AutoSize = true;

                    TrackBar tmpBoneScaleTrackBar = new TrackBar();
                    tmpBoneScaleTrackBar.Minimum = (int)(minSliderValue.Value * 10);
                    tmpBoneScaleTrackBar.Maximum = (int)(maxSliderValue.Value * 10);
                    tmpValue = (Double.Parse(values[6]) * 10);
                    try { tmpBoneScaleTrackBar.Value = (int)tmpValue; }
                    catch {
                        tmpBoneScaleTrackBar.Value = (tmpValue > tmpBoneScaleTrackBar.Maximum) ? tmpBoneScaleTrackBar.Maximum : tmpBoneScaleTrackBar.Minimum;
                        sliderValueOutOfBounds = true;
                    }
                    tmpBoneScaleTrackBar.Tag = "b," + counter;
                    tmpBoneScaleTrackBar.LargeChange = 1;
                    tmpBoneScaleTrackBar.ValueChanged += sliderChanged;
                    tmpBoneScaleTrackBar.MouseEnter += sliderMouseEnter;
                    tmpBoneScaleTrackBar.AutoSize = true;

                    slidersTable.Controls.Add(tmpLabel, 0, counter);
                    slidersTable.Controls.Add(tmpCheckBox, 1, counter);
                    slidersTable.Controls.Add(tmpXTrackBar, 2, counter);
                    slidersTable.Controls.Add(tmpYTrackBar, 3, counter);
                    slidersTable.Controls.Add(tmpZTrackBar, 4, counter);
                    slidersTable.Controls.Add(tmpBoneScaleTrackBar, 5, counter);

                    slidersTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    slidersTable.RowCount++;

                    counter++;
                }

                slidersTable.Height = (counter * 31);
                Controls.Add(slidersTable);

                // Resize the table to the window's width
                changeTableSize();

                // Show the table again
                slidersTable.ResumeLayout();
                slidersTable.Visible = true;

                fileHandle.Close();

                // Since the file was handled properly it's safe to assume this is
                // the correct path to the HoneySelect's chara folder, so lets save
                // it to easily reopen it next time.
                Properties.Settings.Default.HoneySelectFolderPath = Path.GetDirectoryName(fileName);
                Properties.Settings.Default.Save();

                if (sliderValueOutOfBounds)
                {
                    string msg = "One or more of the sliders were either lower than the minimum\n" +
                                    "value, or higher than the maximum value. They have been set\n" +
                                    "to the lowest or highest value depending on the above.\n\n" +
                                    "If you move any sliders, the file will be saved with values\n" +
                                    "that had to be adjusted. If you wish to retain the values \n" +
                                    "in the bonemod file then change the minimum or maximum\n" +
                                    "values at the top of this application and reload the text file.";
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (System.ArgumentNullException)
            {
                // Canceled the file select dialogue
            }
            catch
            {
                string msg = "The file you selected was not a bonemod file, or is corrupted.";
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadBoneInfoFile.Enabled = true;
        }

        private void sliderChanged(object sender, EventArgs e)
        {
            string tag = ((TrackBar)sender).Tag.ToString();
            string[] values = tag.Split(',');
            char[] action = values[0].ToCharArray();

            double value = (Double.Parse(((TrackBar)sender).Value.ToString()) / 10);

            if (numberDisplay != null) numberDisplay.Dispose();
            components = new System.ComponentModel.Container();
            numberDisplay = new System.Windows.Forms.ToolTip(components);
            numberDisplay.SetToolTip((TrackBar)sender, value.ToString());

            showToolTipValue((TrackBar)sender, value.ToString());

            changeSlider(action[0], value, Int32.Parse(values[1]));
        }
        
        private void sliderMouseEnter(object sender, EventArgs e)
        {
            double value = Double.Parse(((TrackBar)sender).Value.ToString()) / 10;
            showToolTipValue((TrackBar)sender, value.ToString());
        }

        private void changeSlider(char bar, double value, int entry)
        {
            switch (bar)
            {
                case 'x':
                    {

                        boneSliderDatabase[entry].boneXValue = value;
                        break;
                    }
                case 'y':
                    {
                        boneSliderDatabase[entry].boneYValue = value;
                        break;
                    }
                case 'z':
                    {
                        boneSliderDatabase[entry].boneZValue = value;
                        break;
                    }
                case 'b':
                    {
                        boneSliderDatabase[entry].boneScale = value;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Something went wrong.");
                        break;
                    }
            }

            changeLine(entry);
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            string tag = ((CheckBox)sender).Tag.ToString();
            boneSliderDatabase[Int32.Parse(tag)].boneEnabled = ((CheckBox)sender).Checked;

            changeLine(Int32.Parse(tag));
        }

        public void changeLine(int entry)
        {
            // Output string
            string enabled = (boneSliderDatabase[entry].boneEnabled == true) ? "True" : "False";
            string writeLine =  boneSliderDatabase[entry].boneID + "," +
                                boneSliderDatabase[entry].boneName + "," +
                                enabled + "," +
                                boneSliderDatabase[entry].boneXValue + "," +
                                boneSliderDatabase[entry].boneYValue + "," +
                                boneSliderDatabase[entry].boneZValue + "," +
                                boneSliderDatabase[entry].boneScale;

            // Replace the required line with the string above and leave
            // the rest as it is
            string[] lines = File.ReadAllLines(fileName);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == boneSliderDatabase[entry].textFilePos)
                    {
                        writer.WriteLine(writeLine);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }

        private void changeTableWidth(object sender, EventArgs e)
        {
            changeTableSize();
        }

        private void changeTableSize()
        {
            int padding = slidersTable.Padding.Left + slidersTable.Padding.Right + 10;
            slidersTable.Width = (this.Width - padding);

            // Hide the table so it doesn't sap extra performance while
            // it resizes itself and the controls within
            slidersTable.Visible = false;
            slidersTable.SuspendLayout();

            int width = 0;
            foreach (Control tBar in this.slidersTable.Controls.OfType<TrackBar>())
            {
                if(width == 0)
                {
                    // Set the width to whatever our cellposition is
                    width = (int)slidersTable.GetColumnWidths()[2];
                }

                // Apply to controls
                tBar.Width = width;
            }

            slidersTable.ResumeLayout();
            slidersTable.Visible = true;
        }

        private void showToolTipValue(TrackBar sender, string value)
        {
            if (numberDisplay != null) numberDisplay.Dispose();
            components = new System.ComponentModel.Container();
            numberDisplay = new System.Windows.Forms.ToolTip(components);
            numberDisplay.SetToolTip(sender, value);
        }

        private void minMaxSliderShowToolTip(object sender, EventArgs e)
        {
            if (numberDisplay != null) numberDisplay.Dispose();
            components = new System.ComponentModel.Container();
            numberDisplay = new System.Windows.Forms.ToolTip(components);
            numberDisplay.SetToolTip((NumericUpDown)sender, "Remember to reload your Bonemod file with the button at the right.");
        }

        public partial class DBLayoutPanel : TableLayoutPanel
        {
            // Non-twitchy tablelayoutpanel
            public DBLayoutPanel()
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            }

            public DBLayoutPanel(IContainer container)
            {
                container.Add(this);
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            }
        }
    }
}

public class sliderEntry
{
    public int boneID;
    public string boneName;
    public bool boneEnabled = false;
    public double boneXValue;
    public double boneYValue;
    public double boneZValue;
    public double boneScale;
    public int textFilePos; // Line#
};