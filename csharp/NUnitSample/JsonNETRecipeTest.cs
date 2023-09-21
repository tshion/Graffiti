using SampleLibrary;

namespace NUnitSample
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
