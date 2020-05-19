using LibraryStandard;
using NUnit.Framework;

namespace NUnitLibraryStandard
{
    [TestFixture]
    class JsonNETRecipeTest
    {
        [Test]
        public void AddJObjectProps()
        {
            var recipe = new JsonNETRecipe();
            Assert.Catch(() =>
            {
                recipe.AddJObjectPropsError();
            });
            recipe.AddJObjectProps();
        }
    }
}
