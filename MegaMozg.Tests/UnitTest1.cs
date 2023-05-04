using FluentAssertions;
using MegaMozg.App.Abstract;
using MegaMozg.App.Concrete;
using MegaMozg.App.Managers;
using MegaMozg.Domain.Entity;
using Moq;

namespace MegaMozg.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Answer answer = new Answer(1,1,"Odpowiedü nr. 1",true);
            var mock = new Mock<IService<Answer>>(); 
            mock.Setup(s =>s.GetItem(1)).Returns(answer);
            
            //act
            
            //Assert
           

        }
    }
}