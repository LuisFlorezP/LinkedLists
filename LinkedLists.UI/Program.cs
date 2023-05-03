using LinkedLists.Logic;

var list1 = new List<string>()
{
	"manzana",
	"perita",
	"reconocer",
	"pedro",
	"romper",
	"Jose"
};

var list2 = new List<string>()
{
	"caminar",
	"perris",
	"reconocer",
	"pepe",
	"rascar",
	"Sejo"
};

var angrams = Angrams.Anagrams(list1, list2);
foreach (var angram in angrams)
{
	Console.WriteLine($"Anagrama:\n - Palabras: {angram.Key}.\n - Cambios: {angram.Value}.\n");
}
