
using Microsoft.VisualBasic;
using System.Text;

public class Identifier
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine(Identifier.Clean("My   Id"));
        Console.WriteLine(Identifier.Clean("my\0Id"));
        Console.WriteLine(Identifier.Clean("à-ḃç"));
        Console.WriteLine(Identifier.Clean("1😀2😀3😀"));
        Console.WriteLine(Identifier.Clean("MyΟβιεγτFinder"));
    }

    public static string Clean(string ident)
    {
        var sb = new StringBuilder();

        bool find_ = false;
        foreach (char c in ident) 
        {
            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == '-')
            {

                find_ = true;

            }
            else if (find_)
            {

                sb.Append(char.ToUpper(c));
                find_ = false;
            }
            else if (c >= 'α' && c <= 'ω')
            {

            }
            else if (char.IsLetter(c))
            {
                sb.Append(c);
            }

        }

        return sb.ToString();
    }
}