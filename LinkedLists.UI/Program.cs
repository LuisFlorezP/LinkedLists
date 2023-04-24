using LinkedLists.Logic;

Console.WriteLine("*** Linked Lists ***");
var list = new DoubleList<int>();
list.FillFibonacci(100);
Console.WriteLine(list);


/*
var orange = new Fruit { Name = "Naranja", Price = 5000 };
var pear = new Fruit { Name = "Pera", Price = 5000 };
var kiwy = new Fruit { Name = "Kiwy", Price = 5000 };
var avocado = new Fruit { Name = "Aguacate", Price = 5000 };
var lemon = new Fruit { Name = "Limón", Price = 5000 };
var waterMelon = new Fruit { Name = "Sandia", Price = 5000 };

var fruits = new DoubleList<Fruit>();
fruits.Add(orange);
//fruits.Add(pear);
//fruits.Add(kiwy);
//fruits.Add(avocado);
//fruits.Add(lemon);

Console.WriteLine("Fruits List =>");
Console.WriteLine(fruits);
var response = fruits.Delete(orange);
Console.WriteLine($"Response: {response.Message}");

Console.WriteLine("Fruits List Again =>");
Console.WriteLine(fruits);

Console.WriteLine("List in inverted order =>");
Console.WriteLine(fruits.ToInvertedList());

Console.WriteLine("List converted to array =>");
var fruitsArray = fruits.ToArray();
foreach (var fruit in fruitsArray.OrderByDescending(fruit => fruit.Price))
{
    Console.WriteLine(fruit);
}


var singleList = new SingleList<string>();
FillList();

void FillList()
{
    singleList.Add("a");
    singleList.Add("b");
    singleList.Add("c");
    singleList.Add("d");
    singleList.Add("e");
    singleList.Add("f");
    singleList.Add("g");
}

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