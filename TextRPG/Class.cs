class Player
{
    public int level = 1;//레벨
    public string name = "";//이름
    public string job = "";//직업
    public int attack = 0;
    public int defense = 0;//방어력
    public int health = 0;//체력
    public int gold = 0;//Gold

    public void SetPlayerName(int num)
    {
        switch (num)
        {
            case 1:
                name = "양관식";
                break;
            case 2:
                name = "오애순";
                break;
            case 3:
                name = "양금명";
                break;
            default:
                name = "뭐랭하멘";
                break;
        }
    }
    public void SetPlayerJob(int num)
    {
        switch (num)
        {
            case 1:
                job = "어부";
                break;
            case 2:
                job = "작가";
                break;
            case 3:
                job = "CEO";
                break;
            default:

                job = "유튜버";
                break;
        }
    }
    public void SetPlayerStatus(int num)
    {
        switch (num)
        {
            case 1:
                attack = 10;
                defense = 5;
                health = 100;
                gold = 1500;
                break;
            case 2:
                attack = 10;
                defense = 5;
                health = 100;
                gold = 1500;
                break;
            case 3:
                attack = 10;
                defense = 5;
                health = 100;
                gold = 1500;
                break;
            default:
                attack = 5;
                defense = 5;
                health = 200;
                gold = 3000;
                break;
        }
    }
    public void ShowStatus(Inventory inventory)
    {
        var (bonusAtk, bonusDef, bonusHp) = inventory.GetEquippedStatBonus();
        
        Console.WriteLine($"이름 : {name}");
        Console.WriteLine($"직업 : {job}");
        Console.WriteLine($"레벨 : {level}");
        Console.WriteLine($"공격력 : {attack} {(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}");
        Console.WriteLine($"방어력 : {defense} {(bonusDef > 0 ? $"(+{bonusDef})" : "")}");
        Console.WriteLine($"체력 : {health} {(bonusHp > 0 ? $"(+{bonusHp})" : "")}");
        Console.WriteLine($"골드 : {gold}");
        Console.WriteLine("아이템 이름\r\t\t\t공격력\t방어력\t체력\t골드\t타입");
    }
}
