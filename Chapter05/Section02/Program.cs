namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            var appVer1 = new AppVersion(5, 1);
            var appVer2 = new AppVersion(5, 1);
            if(appVer1 == appVer2) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}



public record AppVersion(int m ,int mi , int b=0,int r = 0) {
    public int Major { get; init; }
    public int Minor { get; init; }
    public int Build { get; init; }
    public int Revision { get; init; }
   
   /* public AppVersion(int major, int minor, int build=0, int revision = 0) {
        Major = major;
        Minor = minor;
        Build = build;
        Revision = revision;
    }*/

    public override string ToString() =>
        $"{Major}.{Minor}.{Build}.{Revision}";

}