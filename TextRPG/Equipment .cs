class Equipment // 장비
{
    public string? type; // 장비 종류
    public class Item //아이템 정의  
    {
        public string name;
        public string type;
        public int attack;
        public int defense;
        public int health;
        public int gold;
        public bool isEquipped;
        public bool isPurchased;
        public string buydescription;

        public Item(string name,string type, int attack, int defense, int health, int gold)
        {
            this.name = name;
            this.type = type; 
            this.attack = attack;
            this.defense = defense;
            this.health = health;
            this.gold = gold;
            this.isEquipped = false;
            this.isPurchased = false;
            this.buydescription = "구매 가능";
        }
        public override string ToString()
        {
            return $"{name} ({type}) - ATK:{attack}, DEF:{defense}, HP:{health}";
        }
    }


}