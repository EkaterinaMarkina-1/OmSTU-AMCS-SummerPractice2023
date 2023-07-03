namespace SquareEquationBDD;

using TechTalk.SpecFlow;
using SquareEquationLib;

namespace SquareEquationBDD
{
    [Binding]
    public class TestBDD
    {
        private double a;
        private double b;
        private double c;
        private double[] roots;

        [Given(@"квадратное уравнение с коэффициентами a = (.+), b = (.+), c = (.+)")]
        public void КвадратноеУравнение(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        [When(@"находим корни квадратного уравнения")]
        public void НахождениеКорней()
        {
            roots = SquareEquation.Solve(a, b, c);
        }

        [Then(@"квадратное уравнение имеет два корня, кратности один")]
        public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин()
        {
            Assert.Equal(2, roots.Length);
            Assert.NotEqual(roots[0], roots[1]);
        }

        [Then(@"квадратное уравнение имеет один корень, кратности два")]
        public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва()
        {
            Assert.Equal(2, roots.Length);
            Assert.Equal(roots[0], roots[1]);
        }

        [Then(@"квадратное уравнение не имеет корней")]
        public void ТоКвадратноеУравнениеНеИмеетКорней()
        {
            Assert.Empty(roots);
        }

        [Then(@"выбрасывается исключение ArgumentException")]
        public void ТоВыбрасываетсяИсключениеArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }
    }
}