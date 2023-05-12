using LinkedLists.Logic;

var list1 = new List<string>()
{
    "Los",
    "Perro",
    "Pan",
    "La vida es bella",
    "saroihdsrgpoigreu89er5wuyaesfoipwy4tyhdfgsalkjrsthjgdfasviouyergoihvdasiodfshñoasdifywoer9yhgadfrsjklñhdsbfljkys"
};

var list2 = new List<string>()
{
    "Sol",
    "Gato",
    "Paz",
    "Bella es tu boca",
    "dpioujvdfkjdhrsgidsfhasrfgyiughjkdfgrliergiÁopaegrpegru´90we5tñvdfjlisrteuyp9gdfuadsofyvdsalkjhergwoiuyewsefiode"
};

var angrams = Angrams.Anagrams(list1, list2);
foreach (var angram in angrams)
{
	Console.WriteLine($"Anagrama:\n - Palabras: {angram.Key}.\n - Cambios: {angram.Value}.\n");
}
