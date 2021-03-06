using System;
using Xunit;

namespace Interpreter.Tests
{
    public class InterpreterTests
    {
        [Fact]
        public void Should_Succes_When_AddAndSubMultipleNumbers()
        {
            string text = "3+2-1+9";
            Interpreter inter = new Interpreter(text);
            Assert.Equal(13, inter.Expr());
        }

        [Fact]
        public void Should_Succes_When_Add()
        {
            string text = "3+2";
            Interpreter inter = new Interpreter(text);
            Assert.Equal(5, inter.Expr());
        }


        [Fact]
        public void Should_Succes_When_Substract()
        {
            string text = "3-2";
            Interpreter inter = new Interpreter(text);
            Assert.Equal(1, inter.Expr());
        }

        [Fact]
        public void Should_Succes_When_SubstractMultipDigit()
        {
            string text = "13-11";
            Interpreter inter = new Interpreter(text);
            Assert.Equal(2, inter.Expr());
        }


        [Theory]
        [InlineData("")]
        public void Should_ConstructorThrowException_WhenInvalidExpression(string text)
        {
            Assert.ThrowsAny<Exception>(() => new Interpreter(text));
        }

        [Theory]
        [InlineData("3+")]
        [InlineData("+")]
        public void Should_ThrowException_WhenInvalidExpression(string text)
        {
            Interpreter inter = new Interpreter(text);
            Assert.ThrowsAny<Exception>(() => inter.Expr());
        }
    }
}
