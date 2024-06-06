using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace games_wf
{
    public class GameController
    {
        private GameModel gameModel;
        private GameView gameView;

        public GameController(Form1 form)
        {
            gameModel = new GameModel();
            gameView = new GameView(form);
            UpdateView();

            // Привязываем события кликов по клеткам игрового поля
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = i;
                    int y = j;
                    gameView.PictureBoxes[i, j].Click += (sender, e) => OnCellClick(x, y);
                }
            }

            // Привязываем событие клика по кнопке "Перейти на следующий уровень"
            form.ButtonNextLevel.Click += (sender, e) => OnNextLevelClick();
        }

        private void OnCellClick(int x, int y)
        {
            if (Math.Abs(gameModel.HeroX - x) + Math.Abs(gameModel.HeroY - y) == 1)
            {
                gameModel.MoveHero(x, y);
                UpdateView();
            }
        }

        private void OnNextLevelClick()
        {
            if (gameModel.Coins >= gameModel.RequiredCoins)
            {
                gameModel.Level++;
                gameModel.Coins -= gameModel.RequiredCoins;
                gameModel.RequiredCoins += 15; // Увеличиваем требуемое количество монет для следующего уровня

                // Увеличиваем сложность и максимальное здоровье через каждый уровень
                if (gameModel.Level % 2 == 0)
                {
                    gameModel.IncreaseDifficulty();
                }

                gameModel.InitializeGameField();
                UpdateView();
            }
        }

        private void UpdateView()
        {
            gameView.UpdatePictureBoxes(gameModel);
            gameView.UpdateGameInfo(gameModel);

            // Проверка на автоматический переход на следующий уровень
            if (gameModel.Coins >= gameModel.RequiredCoins)
            {
                gameModel.Level++;
                gameModel.Coins -= gameModel.RequiredCoins;
                gameModel.RequiredCoins += 15; // Увеличиваем требуемое количество монет для следующего уровня

                // Увеличиваем сложность и максимальное здоровье через каждый уровень
                if (gameModel.Level % 2 == 0)
                {
                    gameModel.IncreaseDifficulty();
                }

                gameModel.InitializeGameField();
                MessageBox.Show("Поздравляем! Вы перешли на следующий уровень!");
            }
        }
    }
}
