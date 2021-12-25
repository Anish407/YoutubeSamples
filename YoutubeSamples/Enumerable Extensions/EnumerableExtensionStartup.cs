using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using YoutubeSamples.Enumerable_Extensions;


IEnumerable<MyClass> source = new List<MyClass>()
{
    new MyClass{ Id=1, Address="aa", Name="anish"   },
    new MyClass{ Id=1, Address="aa", Name="anish"   },
    new MyClass{ Id=1, Address="aa", Name="anish"   },
    new MyClass{ Id=1, Address="aa", Name="anish"   },
    new MyClass{ Id=13, Address="aa", Name="anish"   },
    new MyClass{ Id=13, Address="aa", Name="anish"   }
};
var obj = new MyClass { Id = 1, Address = "aa", Name = "anish" };
var obj2 = new MyClass { Id = 2, Address = "aa", Name = "anish" };
HashSet<MyClass> actual = new HashSet<MyClass>();
var x=actual.Add(obj);
var z = actual.Add(obj);
var z3= actual.Add(obj2);



var result= source.DistinctBy(i=> i.Id).ToList();
var result2= source.DistinctBy(i=> new { i.Id, i.Name }).ToList();
var result3= source.DistinctBy(i=> new { i.Id, i.Address }).ToList();
Console.Read();

public class MyComparer : IEqualityComparer<MyClass>
{
    public bool Equals(MyClass x, MyClass y)
    {
        return x.Id == y.Id & x.Address.Equals(y.Address) & x.Name.Equals(y.Name);
    }

    public int GetHashCode([DisallowNull] MyClass obj)
    {
        return obj.Id.GetHashCode() ^ obj.Name.GetHashCode() ^ obj.Address.GetHashCode();
    }
}

public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string  Address { get; set; }

}