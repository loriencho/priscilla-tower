public class Day07_CallStack {
    public static int f(int x){
        return 4 * x + 3;
    }

    public static int g(int x, int y){
        return 2 * f(y-3) + f(x);
    }

    public static int h(int x, int y) {
        return g(x, x + y) + g(y, x-y);
    }


    public static void main(String[] args) {
        System.out.println(h(14, 20));
    }
}

