public class Krest implements Figure
{
    @Override
    public void write()
    {
        System.out.print("X");
    }
    @Override
    public int writeEmpty()
    {
        return 2;
    }
}
