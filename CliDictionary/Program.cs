using System;
using DictionaryCore;

var datafile = new FileReader().ReadLines();
var dictionary = new StringsDictionary(10);
dictionary.Fill(datafile,dictionary);

while (true)
{
	var n = Console.ReadLine();
	var def = dictionary.Get(n.ToUpper());
	Console.WriteLine(def);
}