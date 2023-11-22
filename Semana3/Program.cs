#region Tuples


using System.Data.Common;
using System.IO.Compression;

var tuple3 = (id: 10, nome: "Paulo", born: new DateTime(1986, 06, 14));

Console.WriteLine($"Tuple 3: {tuple3.id}, {tuple3.nome}, {tuple3.born}");

#endregion


#region LambdaExpression

Func<int, int, int> sum = (x, y) => x + y;
Console.WriteLine($"Racionais: {sum(10, 20)}");


Action<string> greet = name =>
{
   string greeting = $"Hello {name}!";
   Console.WriteLine(greeting);
};
string person = Console.ReadLine() ?? "";
greet(person);


Func<string, int, string> isBiggerThan = (string s, int x) => s.Length > x ? "Yes" : "No";
var size = 5;
Console.WriteLine($"The text {person} has more than {size} chars? {isBiggerThan(person, size)}");

string[] people = { "Linq", "Mano", "Favelado" };
char letter = 'P';
Console.WriteLine($"People with name started with '{letter}': {string.Join(", ", people.Where(x => x.StartsWith(letter)))}");

#endregion

#region 

Console.WriteLine("Fechou!");

#endregion