using WebApplicationEmployees.Business;

namespace TestProject
{
    public class Tests
    {  

        [Test]
        public void Test1()
        {
            //Arrange
            const decimal defaultValue = 120000;
            decimal salary = 10000;
            //Act
            decimal annualSalary = EmployeeBusiness.GetAnnualSalary(salary);
            //Assert
            Assert.That(annualSalary, Is.EqualTo(defaultValue));
        }
    }
}