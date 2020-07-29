import java.util.Scanner;
public class HumanPlayer {
    public int playerH;
    public int roboplayerH;
    public int tH;
    public void step(Figure[][] XYarray)
    {
        Scanner scan=new Scanner(System.in);
        System.out.print("Ходит игрок "+(playerH+1)+"\n");
        System.out.println("Введите x(1-3).");
        int x=scan.nextInt();
        scan.nextLine();
        System.out.println("Введите y(1-3).");
        int y=scan.nextInt();
        scan.nextLine();
        if(playerH==0&&roboplayerH==1)
        {
            if(XYarray[x-1][y-1].writeEmpty()==0)
            {
                XYarray[x-1][y-1] = new Krest();

            }
            else if (XYarray[x-1][y-1].writeEmpty()!=0)
            {
                System.out.println("Ошибка");
            }
            if (tH==0)
            {
                playerH=1;
            }
        }
        else if(playerH==1&&roboplayerH==0)
        {
            if(XYarray[x-1][y-1].writeEmpty()==0)
            {
                XYarray[x-1][y-1]=new Zero();

            }
            else if (XYarray[x-1][y-1].writeEmpty()!=0)
            {
                System.out.println("Ошибка");
            }
            if (tH==0)
            {
                playerH=0;
            }
        }
    }
}
