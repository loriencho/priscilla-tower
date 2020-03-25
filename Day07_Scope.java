public class Day07_Scope{

    public static void main(String[] args) {
        int x = 14;

        if (x > 5) {

            if (y > 3) {
                int z = 20;

                SSystem.out.println(x + y + z);
            }
        }
    }
}