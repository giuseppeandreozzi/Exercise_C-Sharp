namespace Level52_TheFinalBattle {
    internal class Game {
        public enum Gamemode {
            PVP, //Player vs Player
            PVC, //Player vs Computer
            CVC //Computer vs Computer
        }
        private List<Character>[] monstersParties;
        private List<Item>[] monstersInventories;
        public List<Character> heroesParty { get; private set; }
        public List<Character> monstersParty { get; private set; }
        public List<Item> heroesInventory { get; private set; }
        public List<Item> monstersInventory { get; private set; }
        private int currentTurn;
        private int currentHeroesTurn;
        private int currentMonstersTurn;
        private int currentMonsterParty;
        private Gamemode gamemode;

        public Character? currentCharacter { get; private set; }

        public Game(List<Character> heroesParty, List<Character>[] monstersParties, Gamemode gamemode) {
            this.gamemode = gamemode;
            this.heroesParty = heroesParty;
            this.monstersParties = monstersParties;
            monstersParty = this.monstersParties[0];
            currentTurn = 0;
            currentHeroesTurn = 0;
            currentMonstersTurn = 0;
            currentMonsterParty = 0;
            currentCharacter = heroesParty[0];
            heroesInventory = [new HealthPotion(), new HealthPotion(), new HealthPotion()];
            monstersInventories = [[new HealthPotion()], [new HealthPotion()], [new HealthPotion()]];
            monstersInventory = monstersInventories[0];
        }

        public String NextTurn(int actionHero = 1, int actionMonster = 1) {
            Random random = new Random();
            string actionPhrase = "";
            Character enemy;

            if (heroesParty.Contains(currentCharacter)) { //hero turn
                if (actionHero >= 2) {
                    if (heroesInventory.Count > 0) {
                        heroesInventory[0].Use(currentCharacter);
                        heroesInventory.RemoveAt(0);
                        actionPhrase += $"\n{currentCharacter} healed!";
                    } else {
                        actionPhrase += "Inventory is empty";
                    }
                } else {
                    enemy = monstersParty[random.Next(monstersParty.Count)];
                    actionPhrase = currentCharacter.action[actionHero](enemy);
                    if (enemy.currentHP == 0) {
                        actionPhrase += $"\n{enemy.name} has been defeated!";
                        monstersParty.Remove(enemy);
                    }
                }
                currentHeroesTurn = (currentHeroesTurn + 1 < heroesParty.Count) ? currentHeroesTurn + 1 : 0;
                currentCharacter = (currentMonstersTurn >= monstersParty.Count) ? null : monstersParty[currentMonstersTurn]; 
            } else { //monster turn
                if (actionMonster == 2) {
                    if (monstersInventory.Count > 0) {
                        monstersInventory[0].Use(currentCharacter);
                        monstersInventory.RemoveAt(0);
                        actionPhrase += $"\n{currentCharacter} healed!";
                    } else {
                        actionPhrase += "Inventory is empty";
                    }
                } else {
                    enemy = heroesParty[random.Next(heroesParty.Count)];
                    actionPhrase = currentCharacter.action[actionMonster](enemy);

                    if (enemy.currentHP == 0) {
                        actionPhrase += $"\n{enemy.name} has been defeated!";
                        heroesParty.Remove(enemy);
                    }
                }
                currentMonstersTurn = (currentMonstersTurn + 1 < monstersParty.Count) ? currentMonstersTurn + 1 : 0;
                currentCharacter = (currentHeroesTurn >= heroesParty.Count) ? null : heroesParty[currentHeroesTurn];
            }

            currentTurn++;

            return actionPhrase;
        }

        public String? CheckEnd() {
            if(monstersParty.Count == 0) {
                currentMonsterParty++;
                if (currentMonsterParty < monstersParties.Length) {
                    monstersParty = monstersParties[currentMonsterParty];
                    monstersInventory = monstersInventories[currentMonsterParty];
                    currentCharacter = monstersParty[0];
                    return null;
                }
                return $"The heroes won, and the Uncoded One was defeated";
            } else if (heroesParty.Count == 0) {
                return $"The heroes lost and the Uncoded One’s forces have prevailed";
            }

            return null;
        }

        public bool IsHeroTurn() {
            return heroesParty.Contains(currentCharacter);
        }

        public bool IsMonstersInventoryEmpty() {
            return monstersInventory.Count == 0;
        }

        public bool IsHeroesInventoryEmpty() {
            return heroesInventory.Count == 0;
        }
    }

    public abstract class Character {
        public Func<Character, String>[] action { get; protected set; }
        public string? name { get; protected set; }
        public short maxHP { get; protected set; }
        public short currentHP { get; internal set; }
    }

    public class Skeleton : Character {
        public Skeleton() {
            name = "SKELETON";
            maxHP = currentHP = 5;
            action = new Func<Character, string>[2];
            action[0] = (Character enemy) => $"{name} did NOTHING";
            action[1] = (Character enemy) => {
                Random random = new Random();
                short damage = (short) random.Next(2);
                enemy.currentHP -= (enemy.currentHP >= damage) ? (short) damage : (short) enemy.currentHP;
                string actionPhrase = $"{name} used BONE CRUNCH on {enemy.name}\n" + $"BONE CRUNCH dealt {damage} damage to {enemy.name}.\n" + $"{enemy.name} is now at {enemy.currentHP}/{enemy.maxHP} HP.";

                
                return actionPhrase;
            };
        }
    }

    public class Hero : Character {
        public Hero(string? name) {
            base.name = name;
            maxHP = currentHP = 25;
            action = new Func<Character, string>[2];
            action[0] = (Character enemy) => $"{name} did NOTHING";
            action[1] = (Character enemy) => {
                enemy.currentHP -= (enemy.currentHP > 0) ? (short) 1 : (short) 0;
                string actionPhrase = $"{name} used PUNCH on {enemy.name}\n" + $"PUNCH dealt 1 damage to {enemy.name}.\n" + $"{enemy.name} is now at {enemy.currentHP}/{enemy.maxHP} HP.";
                return actionPhrase;
            };
        }
    }

    public class TheUncodedOne : Character {
        public TheUncodedOne() {
            base.name = "THE UNCODED ONE";
            maxHP = currentHP = 15;
            action = new Func<Character, string>[2];
            action[0] = (Character enemy) => $"{name} did NOTHING";
            action[1] = (Character enemy) => {
                Random random = new Random();
                short damage = (short)random.Next(3);
                enemy.currentHP -= (enemy.currentHP >= damage) ? (short) damage : (short)enemy.currentHP;
                string actionPhrase = $"{name} used UNRAVELING on {enemy.name}\n" + $"PUNCH dealt {damage} damage to {enemy.name}.\n" + $"{enemy.name} is now at {enemy.currentHP}/{enemy.maxHP} HP.";
                return actionPhrase;
            };
        }
    }

    public interface Item {
        public void Use(Character character);
    }

    public class HealthPotion : Item {
        public HealthPotion() {

        }

        public void Use(Character character) {
            character.currentHP += 10;

            if(character.currentHP > character.maxHP)
                character.currentHP = character.maxHP;
        }
    }
}



