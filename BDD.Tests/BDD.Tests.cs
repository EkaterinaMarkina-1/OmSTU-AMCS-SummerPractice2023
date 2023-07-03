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
        string[] numb = new string[]{p0, p1, p2};
        double[] numbDouble = new double[numb.Length];
        for (int i=0; i < numb.Length; i++){
            if(numb[i] == "NaN"){
                numbDouble[i] = double.NaN;
            }
            else if(numb[i] == "Double.NegativeInfinity"){
                numbDouble[i] = double.NegativeInfinity;
            }
            else if(numb[i] == "Double.PositiveInfinity"){
                numbDouble[i] = double.PositiveInfinity;
            }
            else{
                numbDouble[i] = double.Parse(numb[i]);
            }
        } 
        a = numbDouble[0]; b = numbDouble[1]; c = numbDouble[2];
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
