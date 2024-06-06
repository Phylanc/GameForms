using System;
using System.Drawing;
using System.Windows.Forms;

namespace games_wf
{
    public partial class Form1 : Form
    {
        private GameController gameController;

        public Form1()
        {
            InitializeComponent();
            gameController = new GameController(this);
        }

        public Label LabelHealth
        {
            get { return labelHealth; }
            set { labelHealth = value; }
        }

        public Label LabelCoins
        {
            get { return labelCoins; }
            set { labelCoins = value; }
        }

        public Label LabelLevel
        {
            get { return labelLevel; }
            set { labelLevel = value; }
        }

        public Label LabelRequiredCoins
        {
            get { return labelRequiredCoins;}
            set { labelRequiredCoins = value;}
        }

        public Label LabelStrength
        {
            get { return labelStrength; }
            set { labelStrength = value; }
        }

        public Button ButtonNextLevel
        {
            get { return buttonNextLevel; }
            set { buttonNextLevel = value; }
        }

        public Label LabelMessages { get; set; }
        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
