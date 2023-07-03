namespace SquareEquationBDD;

using TechTalk.SpecFlow;
using SquareEquationLib;

namespace SquareEquationBDD
{
    [Binding]
    public class TestBDD
    {
        private double a, b, c;
        private double[] roots;
        private Exception actualException;

        [Given(@"^Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void КвадратноеУравнение(string p0, string p1, string p2)
        {
            a = double.Parse(p0);
            b = double.Parse(p1);
            c = double.Parse(p2);
        }

        [When(@"^вычисляются корни квадратного уравнения")]
        public void НахождениеКорней()
        {
            try
            {
                roots = SquareEquation.Solve(a, b, c);
            }
            catch (Exception e)
            {
                actualException = e;
            }
        }

        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double expectedRoot1, double expectedRoot2)
        {
            double[] expectedRoots = new double[] { expectedRoot1, expectedRoot2 };
            Array.Sort(expectedRoots);
            Array.Sort(roots);
            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(expectedRoots[i], roots[i], 6);
            }
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва(double expectedRoot)
        {
            double[] expectedRoots = new double[] { expectedRoot };
            Array.Sort(expectedRoots);
            Array.Sort(roots);
            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(expectedRoots[i], roots[i], 6);
            }
        }

        [Then(@"множество корней квадратного уравнения пустое")]
        public void ТоКвадратноеУравнениеНеИмеетКорней()
        {
            Assert.Empty(roots);
        }

        [Then(@"выбрасывается исключение ArgumentException")]
        public void ТоВыбрасываетсяИсключениеArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => throw actualException);
        }
    }
}
