using System;

namespace console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(respects(102));
            System.Console.WriteLine(respects(112));
            System.Console.WriteLine(respects(11124));
            var cnt=0;
            for(int i=136760;i<595730;i++){ 
                var r=respects2(i);
                System.Console.WriteLine($"{i}  - {r}");
                if(r)cnt++;
            }
            System.Console.WriteLine($"cnt={cnt}");
        }
       static bool respects2(int n){
            int prevcifra=n%10;

            n=(n-prevcifra)/10;
            var dup=false;
            
            var dupsize=1;

            while(n>0){
                
                var cifra=n%10;

                if(cifra>prevcifra)
                    return false;

                if(cifra!=prevcifra){
                    if(dupsize==2)
                        dup=true;
                    dupsize=1;
                }

                if(cifra==prevcifra){
                    dupsize++;
                }

                prevcifra=cifra;

                n=(n-prevcifra)/10;
            }
            if(dupsize==2)
                dup=true;
            return dup;
        }
  
       static bool respects(int n){
            int prevcifra=n%10;

            n=(n-prevcifra)/10;
            var dup=false;

            while(n>0){
                var cifra=n%10;

                if(cifra>prevcifra)
                    return false;

                if(cifra==prevcifra)
                    dup=true;

                prevcifra=cifra;

                n=(n-prevcifra)/10;
            }

            return dup;
        }
  
    }
}
