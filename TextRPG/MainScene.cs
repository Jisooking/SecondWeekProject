using System.Numerics;
internal class Program
{
    static bool isGame = true;

    static void Main(string[] args)
    {
        // 키 입력 감지 스레드 시작
        Thread inputThread = new Thread(CheckForEscape);
        inputThread.Start();

        Console.WriteLine("Welcome to \"폭싹 속았수다\"\n당신은 누구입니까?\n1.양관식\t2.오애순\t3.양금명");
        string? input = Console.ReadLine();
        int playerNum;
        if (!int.TryParse(input, out playerNum))
        {
            playerNum = -1;
        }
        Player player = new Player();
        player.SetPlayerName(playerNum);
        Console.Clear();
        Console.WriteLine($"어서오세요 {player.name}님 당신의 직업은 무엇입니까?\n1.어부\t2.작가\t3.CEO");
        input = Console.ReadLine();
        if (!int.TryParse(input, out playerNum))
        {
            playerNum = -1;
        }
        player.SetPlayerJob(playerNum);
        player.SetPlayerStatus(playerNum);
        Inventory inventory = new(player);
        Store store = new Store(inventory);
        Console.Clear();
        Console.WriteLine($"당신의 직업은 {player.job}입니다.\n\n게임을 시작합니다.\n아무 키나 입력해 주세요.");
        Thread.Sleep(1500);
        while (isGame)
        {
            Console.Clear();
            Console.WriteLine($"여기는 도동리입니다.\n{player.name}님 무엇을 하시겠습니까?\n1.상태 보기\t2.인벤토리\t3.상점");
            input = Console.ReadLine();
            if (!int.TryParse(input, out playerNum))
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadKey();
                continue;
            }
            switch (playerNum)
            {
                case 1: //상태 창
                    Console.Clear();
                    player.ShowStatus(inventory);
                    inventory.ShowIsEquipped();
                    Console.ReadKey();
                    break;
                case 2: //인벤토리
                    Console.Clear();
                    Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");
                    Thread.Sleep(1500);
                    inventory.ShowInventory();
                    break;
                case 3: //상점
                    Console.Clear();
                    Console.WriteLine("상점");
                    store.ShowStore(player);
                    break;
            }
        }
    }
    static void CheckForEscape()
    {
        while (isGame)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\n[ESC 감지] 게임을 종료합니다.");
                    isGame = false;
                }
            }

            Thread.Sleep(100);
        }
    }
}