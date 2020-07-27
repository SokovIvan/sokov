public class Empty implements Figure
{
    @Override
    public void write()
    {
        System.out.print(" ");
    }
    @Override
    public int writeEmpty()
    {
        return 0;
    }
}
