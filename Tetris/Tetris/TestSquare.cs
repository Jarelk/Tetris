using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestSquare : Block
{
    public TestSquare() : base()
    {
        blockMatrix[0, 1] = 1; blockMatrix[1,1] = 1; blockMatrix[0, 2] = 1; blockMatrix[1, 2] = 1;
    }
}