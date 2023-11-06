using FluentValidation.Results;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace PetSystem.Tests.Common;

public class Assert : Xunit.Assert
{
    public static void True(bool condition,
                            string userMessage,
                            ITestOutputHelper output,
                            object objeto)
    {
        if (objeto != null)
            output.WriteLine(JsonConvert.SerializeObject(objeto));

        Assert.True(condition, userMessage);
    }

    public static void False(bool condition,
                             string userMessage,
                             ITestOutputHelper output,
                             object objeto)
    {
        if (objeto != null)
            output.WriteLine(JsonConvert.SerializeObject(objeto));

        var condicao = new bool?(condition);
        if (!condicao.GetValueOrDefault() && !string.IsNullOrEmpty(userMessage.Trim()))
            output.WriteLine(userMessage);

        Assert.False(condicao, userMessage);
    }

    public static void Equal<T>(object expected,
                                object actual,
                                ITestOutputHelper output)
    {
        if (actual != null)
            output.WriteLine("actual: " +
                JsonConvert.SerializeObject(actual));

        if (expected != null)
            output.WriteLine("expected: " +
                JsonConvert.SerializeObject(expected));

        Assert.True(CheckObjectsEquality<T>(expected, actual));
    }

    private static bool CheckObjectsEquality<T>(object expected,
                                                object actual)
    {
        try
        {
            var expectedNormalized = NormalizeObjects<T>(expected);
            var actualNormalized = NormalizeObjects<T>(actual);
            return CompareObjects(expectedNormalized, actualNormalized);
        }
        catch
        {
            return false;
        }
    }

    private static T NormalizeObjects<T>(object objeto)
    {
        var serialized = JsonConvert.SerializeObject(objeto);
        var deserialized = JsonConvert.DeserializeObject<T>(serialized);
        return deserialized;
    }

    private static bool CompareObjects(object expected,
                                       object actual)
    {
        if (Object.ReferenceEquals(expected, actual))
            return true;

        if (expected is null)
            return false;

        if (expected.Equals(actual))
            return true;

        if (expected is IComparable comparableA)
            return comparableA.CompareTo(actual) == 0;

        if (actual is null)
            return false;

        if (actual.Equals(expected))
            return true;

        var type = expected.GetType();
        if (type != actual.GetType())
            return false;

        if (expected is System.Collections.ICollection listA)
        {
            var listB = actual as System.Collections.ICollection;

            if (listA.Count != listB.Count)
                return false;

            var aEnumerator = listA.GetEnumerator();
            var bEnumerator = listB.GetEnumerator();

            while (aEnumerator.MoveNext() && bEnumerator.MoveNext())
            {
                if (!CompareObjects(aEnumerator.Current, bEnumerator.Current))
                    return false;
            }

            return true;
        }

        var properties = type.GetProperties().Where(x => x.GetMethod != null);
        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(ValidationFailure))
                continue;

            if (!CompareObjects(property.GetValue(expected), property.GetValue(actual)))
                return false;
        }

        return true;
    }
}