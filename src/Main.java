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
                System.out.print("Ходит игрок "+(player+1)+"\n");
                System.out.println("Введите x(1-3).");
                int x=scan.nextInt();
                scan.nextLine();
                System.out.println("Введите y(1-3).");
                int y=scan.nextInt();
                scan.nextLine();
                if(player==0&&roboplayer==1)
                {
                    if(XYarray[x-1][y-1].writeEmpty()==0)
                    {
                        XYarray[x-1][y-1] = new Krest();

                    }
                    else if (XYarray[x-1][y-1].writeEmpty()!=0)
                    {
                        System.out.println("Ошибка");
                    }
                    if (t==0)player = 1;
                }
              else if(player==1&&roboplayer==0)
                {
                    if(XYarray[x-1][y-1].writeEmpty()==0)
                    {
                        XYarray[x-1][y-1]=new Zero();

                    }
                    else if (XYarray[x-1][y-1].writeEmpty()!=0)
                    {
                        System.out.println("Ошибка");
                    }
                    if (t==0) player=0;
                }
                if(roboplayer==0&&t!=0)
                {
                    int w=0;
                    if((XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[1][1].writeEmpty()==1)&&(w!=1))
                    {
                        if(XYarray[2][2].writeEmpty()==0){XYarray[2][2]=new Krest();
                            w=1;}
                    }
                    if((XYarray[1][1].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1)&&(w!=1))
                    {
                        if(XYarray[0][0].writeEmpty()==0){XYarray[0][0]=new Krest();
                            w=1;}
                    }
                    if(XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[0][0].writeEmpty()==1&&w!=1)
                    {
                        if(XYarray[1][1].writeEmpty()==0){XYarray[1][1]=new Krest();
                            w=1;}
                    }
                    if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[1][1].writeEmpty()==1&&w!=1)
                    {
                        if(XYarray[0][2].writeEmpty()==0){XYarray[0][2]=new Krest();
                            w=1;}
                    }
                    if(XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[2][0].writeEmpty()==1&&w!=1)
                    {
                        if(XYarray[1][1].writeEmpty()==0){XYarray[1][1]=new Krest();
                            w=1;}
                    }
                    if(XYarray[1][1].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1&&w!=1)
                    {
                        if(XYarray[2][0].writeEmpty()==0){XYarray[2][0]=new Krest();
                            w=1;}
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int a = 0; a < 3; a++)
                        {
                            if (XYarray[a][i].writeEmpty()==1)
                            {
                                w1++;
                            }
                            if (XYarray[a][i].writeEmpty()==2)
                            {
                                w2++;
                            }
                        }
                        if (w1 == 0&&w2==2&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[k][i].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[k][i]=new Krest();
                                    w=1;
                                }
                            }
                        }
                        if (w1 == 2&&w2==0&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[k][i].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[k][i]=new Krest();
                                    w=1;
                                }
                            }
                        }
                        w1 = 0;
                        w2 = 0;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int a = 0; a < 3; a++)
                        {
                            if (XYarray[i][a].writeEmpty()==1)
                            {
                                w1++;
                            }
                            if (XYarray[i][a].writeEmpty()==2)
                            {
                                w2++;
                            }
                        }
                        if (w1 == 0&&w2==2&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[i][k].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[i][k]=new Krest();
                                    w=1;
                                }
                            }
                        }
                        if (w1 == 2&&w2==0&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[i][k].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[i][k]=new Krest();
                                    w=1;
                                }
                            }
                        }
                        w1 = 0;
                        w2 = 0;
                    }
                    if(w!=1&&XYarray[1][1].writeEmpty()==0)
                    {
                      XYarray[1][1]=new Krest();
                      w=1;
                    }
                    if(w!=1&&XYarray[0][0].writeEmpty()==0)
                    {
                        XYarray[0][0]=new Krest();
                        w=1;
                    }
                    if(w!=1&&XYarray[2][2].writeEmpty()==0)
                    {
                        XYarray[2][2]=new Krest();
                        w=1;
                    }
                    if(w!=1&&XYarray[2][0].writeEmpty()==0)
                    {
                        XYarray[2][0]=new Krest();
                        w=1;
                    }
                    if(w!=1&&XYarray[0][2].writeEmpty()==0)
                    {
                        XYarray[0][2]=new Krest();
                        w=1;
                    }
                    if(w!=1)
                    {
                        int xr=0;
                        int yr=0;
                        while(XYarray[xr][yr].writeEmpty()!=0)
                        {
                            xr=random.nextInt(3);
                            yr=random.nextInt(3);
                        }
                        XYarray[xr][yr]=new Krest();
                    }
                }
                if(roboplayer==1&&t!=0)
                {
                    int w=0;
                    if(XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[1][1].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[2][2].writeEmpty()==0)
                        {
                            XYarray[2][2] = new Zero();
                            w = 1;
                        }
                    }
                    if(XYarray[1][1].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[0][0].writeEmpty()==0)
                        {XYarray[0][0]=new Zero();
                            w=1;
                        }
                    }
                    if(XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[0][0].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[1][1].writeEmpty()==0)
                        {XYarray[1][1]=new Zero();
                            w=1;
                        }
                    }
                    if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[1][1].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[0][2].writeEmpty()==0)
                        {XYarray[0][2]=new Zero();
                            w=1;
                        }
                    }
                    if(XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[2][0].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[1][1].writeEmpty()==0)
                        {XYarray[1][1]=new Zero();
                            w=1;
                        }
                    }
                    if(XYarray[1][1].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2&&w!=1)
                    {
                        if(XYarray[2][0].writeEmpty()==0)
                        {XYarray[2][0]=new Zero();
                            w=1;
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int a = 0; a < 3; a++)
                        {
                            if (XYarray[a][i].writeEmpty()==1)
                            {
                                w1++;
                            }
                            if (XYarray[a][i].writeEmpty()==2)
                            {
                                w2++;
                            }
                        }
                        if (w2 == 0&&w1==2&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[k][i].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[k][i]=new Zero();
                                    w=1;
                                }
                            }
                        }
                        if (w2 == 2&&w1==0&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[k][i].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[k][i]=new Zero();
                                    w=1;
                                }
                            }
                        }
                        w1 = 0;
                        w2 = 0;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        for (int a = 0; a < 3; a++)
                        {
                            if (XYarray[i][a].writeEmpty()==1)
                            {
                                w1++;
                            }
                            if (XYarray[i][a].writeEmpty()==2)
                            {
                                w2++;
                            }
                        }
                        if (w2 == 0&&w1==2&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[i][k].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[i][k]=new Zero();
                                    w=1;
                                }
                            }
                        }
                        if (w2 == 2&&w1==0&&w!=1)
                        {
                            for(int k=0;k<3;k++)
                            {
                                if (XYarray[i][k].writeEmpty()==0&&w!=1)
                                {
                                    XYarray[i][k]=new Zero();
                                    w=1;
                                }
                            }
                        }
                        w1 = 0;
                        w2 = 0;
                    }
                    if(w!=1&&XYarray[1][1].writeEmpty()==0)
                    {
                        XYarray[1][1]=new Zero();
                        w=1;
                    }
                    if(w!=1&&XYarray[0][0].writeEmpty()==0)
                    {
                        XYarray[0][0]=new Zero();
                        w=1;
                    }
                    if(w!=1&&XYarray[2][2].writeEmpty()==0)
                    {
                        XYarray[2][2]=new Zero();
                        w=1;
                    }
                    if(w!=1&&XYarray[2][0].writeEmpty()==0)
                    {
                        XYarray[2][0]=new Zero();
                        w=1;
                    }
                    if(w!=1&&XYarray[0][2].writeEmpty()==0)
                    {
                        XYarray[0][2]=new Zero();
                        w=1;
                    }
                    if(w!=1)
                    {
                        int xr=0;
                        int yr=0;
                        while(XYarray[xr][yr].writeEmpty()!=0)
                        {
                            xr=random.nextInt(3);
                            yr=random.nextInt(3);
                        }
                        XYarray[xr][yr]=new Zero();
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int a = 0; a < 3; a++)
                    {
                        if (XYarray[a][i].writeEmpty()==1)
                        {
                            w1++;
                        }
                        if (XYarray[a][i].writeEmpty()==2)
                        {
                            w2++;
                        }
                        if (w1 == 3 || w2 == 3)win = 1;
                        if(w1==3)winPlayer=2;
                        if(w2==3)winPlayer=1;

                    }
                    w1 = 0;
                    w2 = 0;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int a = 0; a < 3; a++)
                    {
                        if(XYarray[i][a].writeEmpty()==1)
                        {
                            w1++;
                        }
                        if(XYarray[i][a].writeEmpty()==2)
                        {
                            w2++;
                        }
                        if(w1==3||w2==3)win=1;
                        if(w1==3)winPlayer=2;
                        if(w2==3)winPlayer=1;
                    }
                    w1=0;
                    w2=0;
                }
                if(XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1)
                {
                    win=1;
                    winPlayer=2;
                }
                if(XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2)
                {
                    win=1;
                    winPlayer=1;
                }
                if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1)
                {
                    win=1;
                    winPlayer=2;
                }
                if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2)
                {
                    win=1;
                    winPlayer=1;
                }
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
        }
    }
}