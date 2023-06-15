using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
namespace DesignPatternsDemo.Model
{
    /*Strategy is a behavioral design pattern that lets you define a family of algorithms, put each of them into a separate class, and make their objects exchangeable. 
    the strategy pattern is a behavioral software design pattern that enables selecting an algorithm at runtime. 
    Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.*/
    public class StrategyModel : PageModel
    {
        public class ModelApplicant : IEquatable<ModelApplicant>, IComparable<ModelApplicant>
        {
            public int Id;
            public string Name;
            public int Age;
            public int Height;
            public int Weight;
            public int Bust;
            public int Waist;
            public int Hip;

            public int CompareTo(ModelApplicant other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return Id.CompareTo(other.Id);
            }
            public ModelApplicant(int id, string name, int age, int height, int weight, int bust, int waist, int hip)
            {
                Id = id;
                Name = name;
                Age = age;
                Height = height;
                Weight = weight;
                Bust = bust;
                Waist = waist;
                Hip = hip;
            }
            public bool Equals(ModelApplicant other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Id == other.Id;
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((ModelApplicant)obj);
            }
            public override int GetHashCode()
            {
                return Id;
            }
            public static bool operator ==(ModelApplicant left, ModelApplicant right)
            {
                return Equals(left, right);
            }
            public static bool operator !=(ModelApplicant left, ModelApplicant right)
            {
                return !Equals(left, right);
            }
            private sealed class NameRelationalComparer : IComparer<ModelApplicant>
            {
                public int Compare(ModelApplicant x, ModelApplicant y)
                {
                    if (ReferenceEquals(x, y)) return 0;
                    if (ReferenceEquals(null, y)) return 1;
                    if (ReferenceEquals(null, x)) return -1;
                    return string.Compare(x.Name, y.Name,
                    StringComparison.Ordinal);
                }
            }
            public static IComparer<ModelApplicant> NameComparer { get; }
            = new NameRelationalComparer();
            private sealed class AgeRelationalComparer : IComparer<ModelApplicant>
            {
                public int Compare(ModelApplicant x, ModelApplicant y)
                {
                    if (ReferenceEquals(x, y)) return 0;
                    if (ReferenceEquals(null, y)) return 1;
                    if (ReferenceEquals(null, x)) return -1;
                    return x.Age.CompareTo(y.Age);
                }
            }
            public static IComparer<ModelApplicant> AgeComparer { get; }
            = new AgeRelationalComparer();
            private sealed class HeightRelationalComparer : IComparer<ModelApplicant>
            {
                public int Compare(ModelApplicant x, ModelApplicant y)
                {
                    if (ReferenceEquals(x, y)) return 0;
                    if (ReferenceEquals(null, y)) return 1;
                    if (ReferenceEquals(null, x)) return -1;
                    return x.Height.CompareTo(y.Height);
                }
            }
            public static IComparer<ModelApplicant> HeightComparer { get; }
            = new HeightRelationalComparer();
        }
    }
}
