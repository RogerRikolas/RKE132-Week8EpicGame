string folderPath = @"C:\Data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));

//string[] heroes = { "Mike Ehrmantraut", "Jesse Pinkman", "Saul Goodman", "Walter White" };
//string[] villains = { "Skyler White", "Hank Schrader", "Gustavo Fring", "Hector Salamanca" };


string hero = GetRandomValue(heroes);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP})is enjoying the beautiful day.");


string villain = GetRandomValue(villains);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;  
Console.WriteLine($"Oh no {villain} ({villainHP}) RKO-s {hero} out of nowhere!!");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");
if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins");

}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValue(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;

}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}


static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;
}