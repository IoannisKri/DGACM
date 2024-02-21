namespace Library.Tests;

using Library.Domain;

public class UnitTest1
{
    [Fact]
    public void BadStringInQuantity()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromString("notvalid");
        });


    }

    [Fact]
    public void ZeroStringInQuantity()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromString("0");
        });


    }

    [Fact]
    public void NegativeFromInt()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Quantity quantity = Quantity.FromInt(-1);
        });


    }

    [Fact]
    public void TooLongBookTitle()
    {
        Assert.Throws<System.ArgumentOutOfRangeException>(() =>
        {
            BookTitle title = BookTitle.FromString(new string('*', 101));
        });


    }






}
