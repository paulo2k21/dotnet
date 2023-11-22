#region Tuples


using System.Data.Common;
using System.IO.Compression;

var tuple3 = (id: 10, nome: "Paulo", born: new DateTime(1986, 06, 14));

Console.WriteLine($"Tuple 3: {tuple3.id}, {tuple3.nome}, {tuple3.born}");

#endregion