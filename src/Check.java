public class Check {
    public int winPlay;
    public int winP;
    public void checkVictory(Figure[][] XYarray)
    {
        int w1=0;
        int w2=0;
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
                if (w1 == 3 || w2 == 3)winP = 1;
                if(w1==3)winPlay=2;
                if(w2==3)winPlay=1;

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
                if(w1==3||w2==3)winP=1;
                if(w1==3)winPlay=2;
                if(w2==3)winPlay=1;
            }
            w1=0;
            w2=0;
        }
        if(XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1)
        {
            winP=1;
            winPlay=2;
        }
        if(XYarray[0][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[0][0].writeEmpty()==XYarray[2][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2)
        {
            winP=1;
            winPlay=1;
        }
        if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==1)
        {
            winP=1;
            winPlay=2;
        }
        if(XYarray[2][0].writeEmpty()==XYarray[1][1].writeEmpty()&&XYarray[2][0].writeEmpty()==XYarray[0][2].writeEmpty()&&XYarray[1][1].writeEmpty()==2)
        {
            winP=1;
            winPlay=1;
        }
        w1 = 0;
        w2 = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++) {
                XYarray[a][i].write();
            }
            System.out.print("\n");
        }
    }
}

