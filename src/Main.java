import java.util.Random;
import java.util.Scanner;
public class Main
{
    public static void main(String[] args)
    {
        int winPlayer;
        int roboplayer=0;
        int w1=0;
        int w2=0;
        Random random=new Random();
        Check check=new Check();
        Robot robot=new Robot();
        HumanPlayer human=new HumanPlayer();
        Figure[][] XYarray=new Figure[3][3];
        int firstplayer=random.nextInt(2);
        Scanner scan=new Scanner(System.in);
        System.out.println("Введите Start,чтобы начать.");
        while(!(scan.nextLine().equalsIgnoreCase("Start")))
        {}
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++) {
                XYarray[i][a]=new Empty();
            }
        }
        int player=firstplayer;
        int t=0;
        System.out.println("Чтобы включить ИИ,введите 'Включить бота'");
        if(scan.nextLine().equalsIgnoreCase("Включить бота"))
        {

            if(player==0)
            {
                t=2;
                roboplayer=1;
            }
            else if(player==1)
            {
                t=1;
                roboplayer=0;
            }
        }
        else
        {
            t=0;
            roboplayer=3;
        }
        while(1==1)
        {
            int win=0;
            winPlayer=0;
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++) {
                    XYarray[i][a]=new Empty();
                }
            }
            System.out.println("Начата новая игра.");
            while  (win==0)
            {
                human.playerH=player;
                human.roboplayerH=roboplayer;
                human.tH=t;
                human.step(XYarray);
                 if (t!=0)
                 {
                   robot.robotpl=roboplayer;
                   robot.winr=win;
                   robot.robotplay(XYarray);
                   win=robot.winr;
                 }
                  check.checkVictory(XYarray);
                  winPlayer=check.winPlay;
                  win=check.winP;
                for (int i = 0; i < 3; i++)
                {
                    for (int a = 0; a < 3; a++) {
                        XYarray[a][i].write();
                    }
                    System.out.print("\n");
                }
            }
            if (winPlayer == 1)System.out.println("Победил игрок 1");
            if (winPlayer == 2)System.out.println("Победил игрок 2");
            if (player==1&&t!=0){player=0;roboplayer=1;}
            else if(player==0&&t!=0){player=1;roboplayer=0;}
            win=0;
            check.winP=0;
            robot.winr=0;
        }
    }
}