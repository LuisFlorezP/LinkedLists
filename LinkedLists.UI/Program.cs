using LinkedLists.Logic;

int option;
var fruits = new DoubleList<string>();

do
{
    option = Menu();
    switch (option)
    {
        case 1: AddItem(); break;
        case 2: ShowList(); break;
        case 3: RemoveItem(); break;
        case 4: InsertItem(); break;
        case 5: ; break;
    }
} while (option != 0);

int Menu()
{
    Console.WriteLine("MENU LISTA:");
    Console.WriteLine("1. Add item.");
    Console.WriteLine("2. Show List.");
    Console.WriteLine("3. Remove item.");
    Console.WriteLine("4. Insert item.");
    Console.WriteLine("5. Inverted list.");
    Console.WriteLine("0. Exit.");
    Console.Write("Enter your choice: ");
    var option = Console.ReadLine();
    return Convert.ToInt32(option);
}

void AddItem()
{
    Console.Write("\nEnter the item: ");
    var item = Console.ReadLine();
    fruits.Add(item!);
}

void ShowList()
{
    if (fruits.IsEmpty)
    {
        Console.WriteLine("\nThe list is empty.\n");
        return;
    }
    Console.WriteLine("\nThe elements are: ");
    Console.WriteLine(fruits);
}

void RemoveItem()
{
    Console.Write("\nEnter the item: ");
    var item = Console.ReadLine();
    Console.WriteLine(fruits.Delete(item!));
}

void InsertItem()
{
    Console.Write("\nEnter the position: ");
    var position = Console.ReadLine();
    Console.Write("Enter the new item: ");
    var item = Console.ReadLine();
    Console.WriteLine(fruits.Insert(item!, Convert.ToInt32(position)));
}