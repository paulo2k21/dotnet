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

#region 


    static Tuple<string, int> CriarTuplaNomeIdade(string nome, int idade)
    {
        return Tuple.Create(nome, idade);
    }

  
       
        var resultado1 = CriarTuplaNomeIdade("João", 25);
        var resultado2 = CriarTuplaNomeIdade("Maria", 30);
        var resultado3 = CriarTuplaNomeIdade("Carlos", 22);

        Console.WriteLine(resultado1);
        Console.WriteLine(resultado2);
        Console.WriteLine(resultado3);
    
#endregion


#region Linq Examples

List<int> list = new() { 1, 2, 3, 4, 5 };
var squaredList = list.Select(x => x * x);
Console.WriteLine($"Original List: {string.Join(", ", list)}");
Console.WriteLine($"Squared  List: {string.Join(", ", squaredList)}");
// Original List: 1, 2, 3, 4, 5
// Squared  List: 1, 4, 9, 16, 25
var summedList = list.Select((x,index) => x + squaredList.ElementAt(index));
Console.WriteLine($"Summed   List: {string.Join(", ", summedList)}");
// Summed   List: 2, 6, 12, 20, 30

var listMultipleOfThree = list.Where(x => x % 3 == 0).ToList();
listMultipleOfThree.AddRange(squaredList.Where(x => x % 3 == 0).ToList());
listMultipleOfThree.AddRange(summedList.Where(x => x % 3 == 0).ToList());
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree)}");
// List Multiple of Three: 3, 9, 6, 12, 30
Console.WriteLine($"List Multiple of Three: {string.Join(", ", listMultipleOfThree.Order())}");

var students = new List<Student>{
   new Student(1, "Lima", "123456789", new DateTime(1987, 9, 24), new List<string>{"123456789", "73988342986"}),
   new Student(2, "Luna", "987654321", new DateTime(2019, 1, 12), new List<string>{"123456789", "73987654321"}),
   new Student(3, "Psquila", "123456789", new DateTime(1984, 11, 24), new List<string>{"123456789", "77988237086"})
};

var any = students.Any();
var anyHelder = students.Any(x => x.FullName.Contains("Helder"));
//var single = students.Single(x => x.Id == 10);
//throw exception
var singleOrDefault = students.SingleOrDefault(x => x.Id == 10);

var select = students.Select(x => x.PhoneNumbers);
var selectMany = students.SelectMany(x => x.PhoneNumbers);

var legalAge = students.Where(x => x.BirthDate <= DateTime.Today.AddYears(-18)).Select(x => x.FullName);
Console.WriteLine($"Legal age people: {string.Join(", ", legalAge)}");


Console.Read();
#endregion

