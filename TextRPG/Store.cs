using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Store // 상점
{
    private Inventory Inventory; // 인벤토리 객체
    public List<Equipment.Item> storeitems; // 상점 아이템 리스트
    Dictionary<string, string> storeItemDescriptions = new Dictionary<string, string>()
{
    { "양배추", "달아요" },
    { "공책", "애순이의 만점비법" },
    { "보리콩", "보리콩 완 보리콩" },
    { "낚시대","관식이의 소울웨폰" },
    { "합격증","금명이의 서울대합격증" },
    { "영화관티켓","금명이의 운명의퍼즐" },
    { "오징어낚시배","금은동호" },
    { "시집","오애순작가의\'폭싹 속았수다\'" },
    { "???의 갑티슈","모 유튜버의 눈물로 흥건하다" }
};

    public Store(Inventory inventory) // Inventory를 매개변수로 받는 생성자
    {
        this.Inventory = inventory; // 인벤토리 객체 초기화
        this.storeitems = new List<Equipment.Item>(); // storeitems 초기화
        storeitems.Add(new Equipment.Item("양배추", "무기", 10, 0, 0, 500)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("공책", "무기", 0, 10, 0, 500)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("보리콩", "무기", 0, 0, 10, 500)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("낚시대", "무기", 10, 10, 5, 2500)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("합격증", "무기", 20, 10, 0, 4000)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("영화관티켓", "장신구", 0, 0, 30, 4000)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("오징어낚시배", "방어구", 25, 25, 10, 10000)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("시집", "장신구", 30, 20, 20, 20000)); // 상점에 아이템 추가
        storeitems.Add(new Equipment.Item("???의 갑티슈", "방어구", 100, 100, 100, 50000)); // 상점에 아이템 추가
    }

    public void ShowStore(Player player) // 상점 보여주기
    {
        Console.Clear();
        Console.WriteLine("상점에 오신 것을 환영합니다.");
        Console.WriteLine("아이템 이름\r\t\t\t공격력\t방어력\t체력\t골드\t타입\t구매가능여부\t설명");
        ShowStoreItems();
        Console.WriteLine($"내 골드 : {player.gold}");
        Console.WriteLine("원하시는 행동을 입력 해 주세요.\n1.구매하기\t2.돌아 가기");
        string? input = Console.ReadLine();
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("구매할 아이템의 번호를 눌러주세요");
            ShowStoreItems();
            input = Console.ReadLine();
            if (!int.TryParse(input, out int inputindex) || (inputindex < 0 || inputindex > storeitems.Count))
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1500);
                return;
            }
            else
            {
                int realIndex = inputindex - 1;
                buyStoreItem(realIndex, player);
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
    public void ShowStoreItems()
    {
        for (int i = 0; i<storeitems.Count; i++)
        {
            var item = storeitems[i];   
            if (item == null) continue; //아이템이 비어있으면 넘어감
            if (storeItemDescriptions.ContainsKey(item.name))
            {
                Console.WriteLine($"설명:{storeitems.IndexOf(item) + 1}.{item.name}\r\t\t\t{item.attack}\t{item.defense}\t{item.health}\t{item.gold}\t{item.type}\t{item.buydescription}\t{storeItemDescriptions[item.name]}");
            }
        }
    }

    public void buyStoreItem(int itemIndex, Player player) // 상점 아이템 구매
    {
        if (itemIndex < 0 || itemIndex >= storeitems.Count)
        {
            Console.WriteLine("잘못된 아이템 번호입니다.");
            return;
        }
        else
        {
            Equipment.Item selectedItem = storeitems[itemIndex];
            if (player.gold >= selectedItem.gold)
            {
                if (selectedItem.isPurchased)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }
                else 
                {
                    player.gold -= selectedItem.gold;
                    Console.WriteLine($"{selectedItem.name}을(를) 구매했습니다.");
                    var boughtitem = new Equipment.Item(selectedItem.name, selectedItem.type, selectedItem.attack, selectedItem.defense, selectedItem.health, selectedItem.gold); // 구매한 아이템을 인벤토리에 추가
                                                                                                                                                                       // 구매한 아이템을 인벤토리에 추가하는 코드
                    Inventory.allItems.Add(boughtitem); // 인벤토리에 아이템 추가
                    selectedItem.isPurchased = true; // 구매한 아이템을 구매 불가능으로 설정
                    selectedItem.buydescription = "구매 불가능"; // 구매한 아이템을 구매 불가능으로 설정
                }
            }
            else
            {
                Console.WriteLine("골드가 부족합니다.");
            }
        }
    }
}
