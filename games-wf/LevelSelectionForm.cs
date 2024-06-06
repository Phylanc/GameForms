using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace games_wf
{
    public partial class LevelSelectionForm : Form
    {
        public LevelSelectionForm()
        {
            InitializeComponent();
        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1(); // Передаем номер выбранного уровня в конструктор GameForm
            gameForm.ShowDialog();
        }

        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Уровень 2 еще не доступен.");
        }

        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Уровень 3 еще не доступен.");
        }
    }
}
