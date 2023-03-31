using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace TestLogic
{
    public class TestCourse
    {
        ICourseDao dao;
        [Fact]
        public void TestPropriete()
        {
            //test bonne valeur
            Course course1 = new Course(dao, false);
            course1.Code = "TestCode";
            course1.Name = "TestName";
            course1.Weight = "20";
            Assert.Equal("TestCode",course1.Code);
            Assert.Equal("TestName", course1.Name);
            Assert.Equal("20", course1.Weight);



            //test exception
            Course course2 = new Course(dao, false);
            Assert.Throws<Exception>(() => course2.Name = null);
            Assert.Throws<Exception>(() => course2.Code = null);
            Assert.Throws<Exception>(() => course2.Weight = "0");
            Assert.Throws<Exception>(() => course2.Weight = "40");
            Assert.Throws<Exception>(() => course2.Weight = "-40");




        }
    }
}
