import java.util.Random;
public class Robot
{
    public int robotpl;
    public int winr;
    public void robotplay(Figure[][] XY)
    {
        Random random=new Random();
        if(robotpl==0)
        {
            int w=0;
            int w1=0;
            int w2=0;
            if((XY[0][0].writeEmpty()==XY[1][1].writeEmpty()&&XY[1][1].writeEmpty()==1)&&(w!=1))
            {
                if(XY[2][2].writeEmpty()==0){XY[2][2]=new Krest();
                    w=1;}
            }
            if((XY[1][1].writeEmpty()==XY[2][2].writeEmpty()&&XY[1][1].writeEmpty()==1)&&(w!=1))
            {
                if(XY[0][0].writeEmpty()==0){XY[0][0]=new Krest();
                    w=1;}
            }
            if(XY[0][0].writeEmpty()==XY[2][2].writeEmpty()&&XY[0][0].writeEmpty()==1&&w!=1)
            {
                if(XY[1][1].writeEmpty()==0){XY[1][1]=new Krest();
                    w=1;}
            }
            if(XY[2][0].writeEmpty()==XY[1][1].writeEmpty()&&XY[1][1].writeEmpty()==1&&w!=1)
            {
                if(XY[0][2].writeEmpty()==0){XY[0][2]=new Krest();
                    w=1;}
            }
            if(XY[2][0].writeEmpty()==XY[0][2].writeEmpty()&&XY[2][0].writeEmpty()==1&&w!=1)
            {
                if(XY[1][1].writeEmpty()==0){XY[1][1]=new Krest();
                    w=1;}
            }
            if(XY[1][1].writeEmpty()==XY[0][2].writeEmpty()&&XY[1][1].writeEmpty()==1&&w!=1)
            {
                if(XY[2][0].writeEmpty()==0){XY[2][0]=new Krest();
                    w=1;}
            }
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    if (XY[a][i].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[a][i].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
                if (w1 == 0&&w2==2&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[k][i].writeEmpty()==0&&w!=1)
                        {
                            XY[k][i]=new Krest();
                            w=1;
                        }
                    }
                }
                if (w1 == 2&&w2==0&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[k][i].writeEmpty()==0&&w!=1)
                        {
                            XY[k][i]=new Krest();
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
                    if (XY[i][a].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[i][a].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
                if (w1 == 0&&w2==2&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[i][k].writeEmpty()==0&&w!=1)
                        {
                            XY[i][k]=new Krest();
                            w=1;
                        }
                    }
                }
                if (w1 == 2&&w2==0&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[i][k].writeEmpty()==0&&w!=1)
                        {
                            XY[i][k]=new Krest();
                            w=1;
                        }
                    }
                }
                w1 = 0;
                w2 = 0;
            }
            if(w!=1&&XY[1][1].writeEmpty()==0)
            {
                XY[1][1]=new Krest();
                w=1;
            }
            if(w!=1&&XY[0][0].writeEmpty()==0)
            {
                XY[0][0]=new Krest();
                w=1;
            }
            if(w!=1&&XY[2][2].writeEmpty()==0)
            {
                XY[2][2]=new Krest();
                w=1;
            }
            if(w!=1&&XY[2][0].writeEmpty()==0)
            {
                XY[2][0]=new Krest();
                w=1;
            }
            if(w!=1&&XY[0][2].writeEmpty()==0)
            {
                XY[0][2]=new Krest();
                w=1;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    if (XY[a][i].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[a][i].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
            }
            if (w1+w2==9&&winr!=1)
            {
                winr=1;
                System.out.println("Ничья");
            }
            else if(w!=1)
            {
                int xr=0;
                int yr=0;
                while(XY[xr][yr].writeEmpty()!=0)
                {
                    xr=random.nextInt(3);
                    yr=random.nextInt(3);
                }
                XY[xr][yr]=new Krest();
            }
            w1=0;
            w2=0;
        }
        if(robotpl==1)
        {
            int w=0;
            int w1=0;
            int w2=0;
            if(XY[0][0].writeEmpty()==XY[1][1].writeEmpty()&&XY[1][1].writeEmpty()==2&&w!=1)
            {
                if(XY[2][2].writeEmpty()==0)
                {
                    XY[2][2] = new Zero();
                    w = 1;
                }
            }
            if(XY[1][1].writeEmpty()==XY[2][2].writeEmpty()&&XY[1][1].writeEmpty()==2&&w!=1)
            {
                if(XY[0][0].writeEmpty()==0)
                {XY[0][0]=new Zero();
                    w=1;
                }
            }
            if(XY[0][0].writeEmpty()==XY[2][2].writeEmpty()&&XY[0][0].writeEmpty()==2&&w!=1)
            {
                if(XY[1][1].writeEmpty()==0)
                {XY[1][1]=new Zero();
                    w=1;
                }
            }
            if(XY[2][0].writeEmpty()==XY[1][1].writeEmpty()&&XY[1][1].writeEmpty()==2&&w!=1)
            {
                if(XY[0][2].writeEmpty()==0)
                {XY[0][2]=new Zero();
                    w=1;
                }
            }
            if(XY[2][0].writeEmpty()==XY[0][2].writeEmpty()&&XY[2][0].writeEmpty()==2&&w!=1)
            {
                if(XY[1][1].writeEmpty()==0)
                {XY[1][1]=new Zero();
                    w=1;
                }
            }
            if(XY[1][1].writeEmpty()==XY[0][2].writeEmpty()&&XY[1][1].writeEmpty()==2&&w!=1)
            {
                if(XY[2][0].writeEmpty()==0)
                {XY[2][0]=new Zero();
                    w=1;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    if (XY[a][i].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[a][i].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
                if (w2 == 0&&w1==2&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[k][i].writeEmpty()==0&&w!=1)
                        {
                            XY[k][i]=new Zero();
                            w=1;
                        }
                    }
                }
                if (w2 == 2&&w1==0&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[k][i].writeEmpty()==0&&w!=1)
                        {
                            XY[k][i]=new Zero();
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
                    if (XY[i][a].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[i][a].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
                if (w2 == 0&&w1==2&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[i][k].writeEmpty()==0&&w!=1)
                        {
                            XY[i][k]=new Zero();
                            w=1;
                        }
                    }
                }
                if (w2 == 2&&w1==0&&w!=1)
                {
                    for(int k=0;k<3;k++)
                    {
                        if (XY[i][k].writeEmpty()==0&&w!=1)
                        {
                            XY[i][k]=new Zero();
                            w=1;
                        }
                    }
                }
                w1 = 0;
                w2 = 0;
            }
            if(w!=1&&XY[1][1].writeEmpty()==0)
            {
                XY[1][1]=new Zero();
                w=1;
            }
            if(w!=1&&XY[0][0].writeEmpty()==0)
            {
                XY[0][0]=new Zero();
                w=1;
            }
            if(w!=1&&XY[2][2].writeEmpty()==0)
            {
                XY[2][2]=new Zero();
                w=1;
            }
            if(w!=1&&XY[2][0].writeEmpty()==0)
            {
                XY[2][0]=new Zero();
                w=1;
            }
            if(w!=1&&XY[0][2].writeEmpty()==0)
            {
                XY[0][2]=new Zero();
                w=1;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    if (XY[a][i].writeEmpty()==1)
                    {
                        w1++;
                    }
                    if (XY[a][i].writeEmpty()==2)
                    {
                        w2++;
                    }
                }
            }
            if (w1+w2==9&&winr!=1)
            {
                winr=1;
                System.out.println("Ничья");
            }
            else  if(w!=1)
            {
                int xr=0;
                int yr=0;
                while(XY[xr][yr].writeEmpty()!=0)
                {
                    xr=random.nextInt(3);
                    yr=random.nextInt(3);
                }
                XY[xr][yr]=new Zero();
            }
            w1=0;
            w2=0;
        }
    }
}
