public class Zero implements Figure
{
    @Override
    public void write()
    {
        System.out.print("O");
    }
    @Override
    public int writeEmpty()
    {
        return 1;
    }
}
