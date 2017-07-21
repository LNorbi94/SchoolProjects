import gui.CostumerWindow;
import java.sql.SQLException;
import javax.swing.JOptionPane;

public class Netcafe {
    
    public static void main(String[] args) {
        try {
            db.DataBase.getInstance().getConnection();
            new CostumerWindow(null, null);
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, "Nem sikerült csatlakozni az adatbázishoz!");
        }
    }
    
}
