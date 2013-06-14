using System.Collections.Generic;
using System.Linq;
using Should;

namespace GenogramGenerator.Tests
{
    public static class TestExtentions
    {
         public static void ShouldBeEquivalentTo<T>(this IEnumerable<T> actual, IEnumerable<T> expected, string message = "")
         {
             var expectedItems = expected as T[] ?? expected.ToArray();
             var actualItems = actual as T[] ?? actual.ToArray();

             actualItems.Count().ShouldEqual(expectedItems.Count(), string.Format("Count of items differed. {0}", message));

             foreach (var expectedItem in expectedItems)
             {
                 actualItems.ShouldContain(expectedItem);
             }
         }
    }
}