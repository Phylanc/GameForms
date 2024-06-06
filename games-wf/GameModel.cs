using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace games_wf
{
    public class GameModel
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Coins { get; set; }
        public int Level { get; set; }
        public int RequiredCoins { get; set; }
        public int HeroX { get; set; }
        public int HeroY { get; set; }
        public int Strength { get; set; }
        public int Difficulty { get; set; }
        public int[,] GameField { get; private set; }

        public enum CardType
        {
            Empty,
            Player,
            Sword,
            HealingPotion,
            Chest,
            IceMonster,
            MouseMonster,
            Trap
        }

        public GameModel()
        {
            Health = 6;
            MaxHealth = 10;
            Coins = 0;
            Level = 1;
            Strength = 0;
            RequiredCoins = 30;
            Difficulty = 1;
            InitializeGameField();
        }

        public void InitializeGameField()
        {
            GameField = new int[3, 3];
            Random random = new Random();

            // Размещаем игрока в центре поля
            HeroX = 1;
            HeroY = 1;
            GameField[HeroX, HeroY] = (int)CardType.Player;

            // Размещаем остальные карточки
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == HeroX && j == HeroY) continue; // Пропускаем клетку, где находится игрок
                    GameField[i, j] = GenerateRandomCard(random);
                }
            }
        }

        public void MoveHero(int newX, int newY)
        {
            Random random = new Random();

            // Заполняем старую позицию игрока случайной картой
            if (GameField[HeroX, HeroY] == (int)CardType.Player)
            {
                GameField[HeroX, HeroY] = GenerateRandomCard(random);
            }

            // Обновляем координаты игрока
            HeroX = newX;
            HeroY = newY;

            switch ((CardType)GameField[HeroX, HeroY])
            {
                case CardType.Sword:
                    int swordStrength = Level >= 3 ? 3 : 2;
                    Strength += swordStrength; // Получаем силу меча
                    break;
                case CardType.HealingPotion:
                    if (random.Next(100) < 10) // 10% шанс, что зелье исцеления восстановит 15 здоровья
                    {
                        int rareHealingAmount = 15;
                        Health = Math.Min(MaxHealth, Health + rareHealingAmount);
                    }
                    else
                    {
                        int healingAmount = 2;
                        Health = Math.Min(MaxHealth, Health + healingAmount); // Пополняем здоровье, но не более MaxHealth
                    }
                    break;
                case CardType.Chest:
                    if (random.Next(100) < 15) // 10% шанс, что сундук даст 15 монет
                    {
                        Coins += 15;
                    }
                    else
                    {
                        Coins += 5;
                    }
                    break;
                case CardType.IceMonster:
                    HandleMonsterEncounter(2 * Difficulty);
                    break;
                case CardType.MouseMonster:
                    HandleMonsterEncounter(1 * Difficulty);
                    break;
                case CardType.Trap:
                    Health -= 3 * Difficulty; // Устанавливаем фиксированный урон от ловушки с учетом сложности
                    break;
            }

            // Перемещаем игрока на новую позицию
            GameField[HeroX, HeroY] = (int)CardType.Player;

            // Проверяем, если здоровье игрока меньше или равно нулю, показываем сообщение о смерти и закрываем игру
            if (Health <= 0)
            {
                MessageBox.Show("Вы проиграли! Игра завершена.");
                Environment.Exit(0); // Завершаем выполнение приложения
            }

            // Проверка на достижение необходимого количества монет
            if (Coins >= RequiredCoins)
            {
                // Автоматический переход на следующий уровень
                Level++;
                Coins -= RequiredCoins;
                RequiredCoins += 15; // Увеличиваем требуемое количество монет для следующего уровня

                // Увеличиваем сложность и максимальное здоровье через каждый уровень
                if (Level % 2 == 0)
                {
                    IncreaseDifficulty();
                }

                InitializeGameField();
                MessageBox.Show("Поздравляем! Вы перешли на следующий уровень!");
            }
        }

        private void HandleMonsterEncounter(int monsterHealth)
        {
            if (Strength >= monsterHealth)
            {
                Strength -= monsterHealth; // Тратим силу на поражение монстра
            }
            else
            {
                Health -= monsterHealth - Strength; // Уменьшаем здоровье на остаток от силы монстра
                Strength = 0; // Сбрасываем силу до нуля, если ее не хватило
            }
        }




        private int GenerateRandomCard(Random random)
        {
            // Генерация случайной карточки с учетом сложности
            int emptyCount = Math.Max(1, 4 - Difficulty);  // Чем выше сложность, тем меньше пустых клеток
            int monsterCount = 1 + Difficulty;  // Чем выше сложность, тем больше монстров
            int swordCount = 1 + Difficulty;  // Чем выше сложность, тем больше мечей

            List<int> cardDistribution = new List<int>();

            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.Empty, emptyCount));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.Sword, swordCount));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.HealingPotion, 2));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.Chest, 3));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.IceMonster, monsterCount));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.MouseMonster, monsterCount));
            cardDistribution.AddRange(Enumerable.Repeat((int)CardType.Trap, 1));

            return cardDistribution[random.Next(cardDistribution.Count)];
        }



        public void IncreaseDifficulty()
        {

            Difficulty = (int)Math.Round(Difficulty + 0.5); // Увеличиваем сложность на 0.35 
            MaxHealth += 2; // Увеличиваем максимальное здоровье
            
        }
    }
}
