using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace games_wf
{
    public class GameView
    {
        public Label LabelHealth { get; set; }
        public Label LabelCoins { get; set; }
        public Label LabelLevel { get; set; }
        public Label LabelRequiredCoins { get; set; }
        public Label LabelStrength { get; set; }
        public PictureBox[,] PictureBoxes { get; set; }
        private GameModel.CardType[,] _cardTypes;
        public Button ButtonNextLevel { get; set; }

        public GameView(Form1 form)
        {
            LabelHealth = form.LabelHealth;
            LabelCoins = form.LabelCoins;
            LabelLevel = form.LabelLevel;
            LabelRequiredCoins = form.LabelRequiredCoins;
            LabelStrength = form.LabelStrength;
            ButtonNextLevel = form.ButtonNextLevel;
            InitializePictureBoxes(form);
            _cardTypes = new GameModel.CardType[3, 3];
        }

        private void InitializePictureBoxes(Form1 form)
        {
            int pictureBoxSize = 85;
            int pictureBoxMargin = 10;
            int x = (form.ClientSize.Width - (pictureBoxSize * 3 + pictureBoxMargin * 2)) / 2;
            int y = (form.ClientSize.Height - (pictureBoxSize * 3 + pictureBoxMargin * 2)) / 2;

            PictureBoxes = new PictureBox[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBoxes[i, j] = new PictureBox();
                    PictureBoxes[i, j].Size = new Size(pictureBoxSize, pictureBoxSize);
                    PictureBoxes[i, j].Location = new Point(x, y);
                    PictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    form.Controls.Add(PictureBoxes[i, j]);
                    x += pictureBoxSize + pictureBoxMargin;
                }
                y += pictureBoxSize + pictureBoxMargin;
                x = (form.ClientSize.Width - (pictureBoxSize * 3 + pictureBoxMargin * 2)) / 2;
            }
        }

        public void UpdatePictureBoxes(GameModel gameModel)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _cardTypes[i, j] = (GameModel.CardType)gameModel.GameField[i, j];
                    switch (_cardTypes[i, j])
                    {
                        case GameModel.CardType.Empty:
                            PictureBoxes[i, j].Image = Properties.Resources.pusto;
                            break;
                        case GameModel.CardType.Player:
                            PictureBoxes[i, j].Image = Properties.Resources.player;
                            break;
                        case GameModel.CardType.Sword:
                            PictureBoxes[i, j].Image = Properties.Resources.sword;
                            break;
                        case GameModel.CardType.HealingPotion:
                            PictureBoxes[i, j].Image = Properties.Resources.heal;
                            break;
                        case GameModel.CardType.Chest:
                            PictureBoxes[i, j].Image = Properties.Resources.chest;
                            break;
                        case GameModel.CardType.IceMonster:
                            PictureBoxes[i, j].Image = Properties.Resources.iceMob;
                            break;
                        case GameModel.CardType.MouseMonster:
                            PictureBoxes[i, j].Image = Properties.Resources.mouseMob;
                            break;
                        case GameModel.CardType.Trap:
                            PictureBoxes[i, j].Image = Properties.Resources.trap;
                            break;
                    }
                }
            }
        }

        public void UpdateGameInfo(GameModel gameModel)
        {
            LabelHealth.Text = "Здоровье : " + gameModel.Health;
            LabelCoins.Text = "Монеты : " + gameModel.Coins;
            LabelLevel.Text = "Уровень : " + gameModel.Level;
            LabelRequiredCoins.Text = "Нужно монет : " + gameModel.RequiredCoins;
            LabelStrength.Text = "Сила : " + gameModel.Strength;
            ButtonNextLevel.Visible = gameModel.Coins >= gameModel.RequiredCoins;
        }
    }
}
