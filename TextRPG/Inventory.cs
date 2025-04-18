using System.Reflection.Metadata.Ecma335;

class Inventory // 내가 가지고 있는 아이템 정보  
{
    Equipment equipment = new Equipment(); //아이템 객체 생성
    public List<Equipment.Item> allItems = new List<Equipment.Item>(); //아이템 리스트
    public List<Equipment.Item> equipped = new List<Equipment.Item>();//아이템 장착여부 리스트 >> 능력치 계산을 위해 
    public int gold; //내가 가진 골드  
    public Inventory(Player player) // Player 객체를 받아 초기화  
    {
        this.gold = player.gold;
        allItems.Add(new Equipment.Item("성실함","무기", 5, 0, 0, 0)); //인벤토리에 아이템 추가
        allItems.Add(new Equipment.Item("바른심성","방어구", 0, 5, 0, 0)); //인벤토리에 아이템 추가
        allItems.Add(new Equipment.Item("젊음","장신구", 0, 0, 5, 0)); //인벤토리에 아이템 추가
    }

    public void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine("아이템 이름\r\t\t\t공격력\t방어력\t체력\t골드\t타입");
        ShowInventoryItems();
        Console.WriteLine($"내 골드 : {gold}");
        Console.WriteLine("원하시는 행동을 입력 해 주세요.\n1.장착 관리\t2.돌아 가기");
        string? input = Console.ReadLine();
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("장착 관리");
            Console.WriteLine("아이템 이름\r\t\t\t공격력\t방어력\t체력\t골드\t타입");
            ShowInventoryItems();
            Console.WriteLine("관리할 아이템의 번호를 입력하세요.");
            string? itemInput = Console.ReadLine();
            if(!int.TryParse(itemInput, out int inputindex)||(inputindex < 0 || inputindex > allItems.Count))
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1500);
                return;
            }
            else
            {
                int realIndex = inputindex - 1;
                string itemNameToEquip = allItems[realIndex].name;
                Equipment.Item selectedItem = allItems[realIndex];
                bool isequipped = allItems.Contains(selectedItem);
                if (isequipped)
                {
                    ToggleEquip(realIndex);
                }
                else
                {
                    ToggleEquip(realIndex);
                }
                Thread.Sleep(1500);
            }
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("돌아가기");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
        }
    }
  
    public void ShowInventoryItems()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            var item = allItems[i];
            if (item == null) continue;
            bool isEquipped = allItems.Contains(item);
            string displayName = item.isEquipped ? $"[E]{item.name}" : item.name;

            Console.WriteLine($"{i + 1}. {displayName}\r\t\t\t{item.attack}\t{item.defense}\t{item.health}\t{item.gold}\t{item.type}");
        }
    }
    public void ToggleEquip(int index)
    {
        var item = allItems[index];

        if (item.isEquipped)
        {
            item.isEquipped = false;
            Console.WriteLine($"{item.name}을(를) 해제했습니다.");
            equipped.Remove(item);
        }
        else
        {
            // 같은 타입의 장비가 있으면 해제
            var alreadyEquipped = allItems.FirstOrDefault(i => i.type == item.type && i.isEquipped);
            if (alreadyEquipped != null)
            {
                alreadyEquipped.isEquipped = false;
                Console.WriteLine($"{alreadyEquipped.name}을(를) 해제하고 {item.name} 장착.");
                equipped.Remove(alreadyEquipped);
            }

            item.isEquipped = true;
            Console.WriteLine($"{item.name}을(를) 장착했습니다.");
            equipped.Add(item);
        }
    }
    public void ShowIsEquipped()
    {
        foreach (var item in allItems)
        {
            if (item.isEquipped)
            {
                Console.WriteLine($"[E]{item.name}\r\t\t\t{item.attack}\t{item.defense}\t{item.health}\t{item.gold}\t{item.type}");
            }
        }
    }
    public (int atk, int def, int hp) GetEquippedStatBonus()
    {
        int totalAtk = 0;
        int totalDef = 0;
        int totalHp = 0;

        foreach (var item in allItems)
        {
            if (item != null && item.isEquipped)
            {
                totalAtk += item.attack;
                totalDef += item.defense;
                totalHp += item.health;
            }
        }

        return (totalAtk, totalDef, totalHp);
    }
}

