//string[] heroes = { "Good Donald Trump", "Good Sponge Bob", "Good Ozzy osbourne", "Good Guf" };
//string[] villains = { "Evil Dimebag Darrell", "Evil John Mayer", "Evil Vin Diesel", "Evil Basta", "Evil Cardi B" };

string folderPath = @"C:\\Users\\Admin\\Documents\\progging\\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));

string[] weapon = { "Guitar", "Plastic bag", "Actual sword", "Used socks", "Bronze dagger" };






string hero = GetRandomValueFromArray(heroes);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
string heroWeapon = GetRandomValueFromArray(weapon);
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");



string villain = GetRandomValueFromArray(villains);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
string villainWeapon = GetRandomValueFromArray(weapon);
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}

Console.WriteLine($"Hero {hero} HP. {heroHP}");
Console.WriteLine($"villain {villain} HP. {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day");
}   
else if (villainHP > 0)
    {
    Console.WriteLine($"{villain} takes over the world");
}
else
{
    Console.WriteLine($"Draw");
}    



static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0,someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }    
    else
    {
        return characterName.Length;
    }

}

static int Hit(string characterName,int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0,characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed");
      
    }   
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} crits");
    }
    else
    {
        Console.WriteLine($"{characterName} hits {strike}");
    }
    return strike;
}