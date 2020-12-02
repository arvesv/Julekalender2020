using System;
using Program;

var population = 5433000;

int delivered = 0;
int toSkip = 0;

for(int i = 0; i < population; i++) {
    if(toSkip > 0) {
        toSkip--;
        continue;
    }

    if(Util.Contains7(i))
    {
        int down = i;
        while(!Util.IsPrime(down))
            down--;

        toSkip = down;
        continue;
    }

    delivered++;


}

Console.WriteLine(delivered);

