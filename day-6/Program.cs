using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day_6
{
    class Program
    {
        static Dictionary<string,List<string>> p;
        static Dictionary<string,int> o;

        static void Main(string[] args)
        {
        //    puzzle("stuff","input.txt");
        //    puzzle("stuff","input2.txt");
           puzzle("stuff","problem.txt");
        }


        static void puzzle(string descr,string input){
            var dic=File.ReadLines(input).ToArray<string>();
            System.Console.WriteLine(descr);
            // print1(dic);

            p=new Dictionary<string,List<string>>();
            o=new Dictionary<string,int>();

            p["COM"]=new List<string>();
            o["COM"]=0;

            foreach(var s in dic){
                var vals=s.Split(")");
                var around=vals[0];
                var planet=vals[1];
                if(!p.ContainsKey(around)){
                    p[around]=new List<string>();
                }
                p[around].Add(planet);

                if(o.ContainsKey(planet)){
                    throw new Exception($"{planet} already there");
                }
                o[planet]=0;
            }
           
            print2(o);
            calc("COM",0);
            
            int total=0;
            foreach(var item in o){
                total+=item.Value;
            }
            System.Console.WriteLine(total);

            show("YOU","SAN");
        }

        static int calc(string planet, int pos){
            // System.Console.WriteLine(($"calc for {planet}").PadLeft(pos,'.'));
            var cnt=0;
             o[planet]=pos;
            if(!p.ContainsKey(planet)){
                // System.Console.WriteLine("final.."+planet);
               
                return 0;
            }
            foreach(var item in p[planet]){
                //o[item]++;
                cnt+=calc(item,pos+1)+1;
            }
            // System.Console.WriteLine($"{cnt} for {planet}");
            return cnt;
        }

        static void show(string you,string san){
            int max=0;
            foreach(var item in o){
                var cy=contains(item.Key,"YOU");
                var cs=contains(item.Key,"SAN");
                // System.Console.WriteLine($"{item.Key}:{cy}/{cs}");
                if(max<item.Value && cy && cs)
                    max=item.Value;
            }

            System.Console.WriteLine($"max is {max}; san is {o["SAN"]}; you is {o["YOU"]}");
            System.Console.WriteLine($"result is "+(o["SAN"]-max+o["YOU"]-max-1-1));
        }
        static bool contains(string root,string planet){
            // System.Console.WriteLine($"{root} contains {planet}?");
            if(root==planet)
                return true;
            if(!p.ContainsKey(root)){
                // System.Console.WriteLine("final.."+planet);
               
                return false;
            }
            foreach(var item in p[root]){
                if(contains(item,planet))
                    return true;
                //o[item]++;
            }
            return false;
        }
 
        static void print2(Dictionary<string,int> a){
            foreach(var item in a)
                Console.WriteLine($"{item.Key}:{item.Value}");
        }

        static void print1(string[] a){
            for(int i=0;i<a.Length-1;i++)
                Console.Write($"{a[i]},");
            Console.WriteLine(a[a.Length-1]);
        }
    }
}
