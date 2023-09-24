import java.io.FileWriter;

/**
 * エントリーポイント
 */
public class Program {
    public static void main(String[] args) {
        var size = 1024;
        var model = new GraphModel();

        double[] max = { 0.50, 1.00 };
        double[] min = { -1.50, -1.00 };

        System.out.println("Start Calculation");
        var map = model.MakeMandelbrotSet(max, min, size, 100, 500);
        System.out.println("Finish Calculation");

        System.out.println("Start File Output");
        try (var writer = new FileWriter("image.pgm")) {
            writer.write("P2\n");
            writer.write(String.format("%d %d\n", size, size));
            writer.write("255\n");
            for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    writer.write(String.format("%d\t", map[row][col]));
                }
                writer.write("\n");
            }
        } catch (Exception e) {
            // TODO: handle exception
        }

        System.out.println("Finish File Output");
    }
}
