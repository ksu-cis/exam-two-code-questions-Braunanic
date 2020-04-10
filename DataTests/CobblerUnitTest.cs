using System;
using ExamTwoCodeQuestions.Data;
using Xunit;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        /// <summary>
        /// Testing that Cobbler.cs implements INotfiyPropertyChanged interface properly
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cobbler);
        }

        /// <summary>
        /// Testing that the INotifyPropertyChange is invoked when Fruit is changed.
        /// </summary>
        [Fact]
        public void ChangingFruitWillInvokePropertyChangedForFruit()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Fruit", () => {
                cobbler.Fruit = FruitFilling.Blueberry;
            });
            Assert.PropertyChanged(cobbler, "Fruit", () => {
                cobbler.Fruit = FruitFilling.Cherry;
            });
            Assert.PropertyChanged(cobbler, "Fruit", () => {
                cobbler.Fruit = FruitFilling.Peach;
            });
        }



        /// <summary>
        /// Testing that the INotifyPropertyChange is invoked when WithIceCream is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamWillInvokePropertyChangedForWithIceCream()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "WithIceCream", () => {
                cobbler.WithIceCream = false;
            });
        }

        /// <summary>
        /// Testing that the INotifyPropertyChange is invoked when WithIceCream is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamWillInvokePropertyChangedForSpecialInstructions()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "SpecialInstructions", () => {
                cobbler.WithIceCream = false;
            });
        }

        /// <summary>
        /// Testing that the INotifyPropertyChange is invoked when WithIceCream is changed.
        /// </summary>
        [Fact]
        public void ChangingWithIceCreamWillInvokePropertyChangedForPrice()
        {
            var cobbler = new Cobbler();
            Assert.PropertyChanged(cobbler, "Price", () => {
                cobbler.WithIceCream = false;
            });
        }
    }
}
