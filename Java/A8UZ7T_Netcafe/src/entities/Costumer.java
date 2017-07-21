package entities;

import java.util.Objects;

public class Costumer {
    
    public String password;
    public String location;
    public String idCard;
    public Integer compID;
    public Integer balance;
    public Integer points;
    
    public static String[] fields = { "Azonosító"
            , "Jelszó"
            , "Cím"
            , "Személyi Igazolvány Szám"
            , "Számítógép Azonosító"
            , "Egyenleg"
            , "Kedvezmény" };
    
    public Costumer(String password, String location
                    , String idCard, Integer compID
                    , Integer balance, Integer points) {
        this.password = password;
        this.location = location;
        this.idCard = idCard;
        this.compID = compID;
        this.balance = balance;
        this.points = points;
    }
    
    public Costumer(String password, String location, String idCard) {
        this.password = password;
        this.location = location;
        this.idCard = idCard;
        this.balance = 0;
        this.points = 0;
    }
    
    public Costumer() { }
    
    public Object[] getData(int id) {
        String iCard, cCard, bal;
        iCard = idCard == null ? "(null)" : idCard;
        cCard = compID == null ? "(null)" : compID.toString();
        bal = balance == null ? "(null)" : balance.toString();
        return new Object[] { id, password, location, iCard, cCard, bal, points };
    }
        
    @Override
    public boolean equals(Object obj) {
        if (obj == null || !(obj instanceof Costumer))
            return false;
        if (obj == this)
            return true;

        Costumer rhs = (Costumer) obj;
        if (compID == null && rhs.compID == null)
            return true;
        if (compID == null || rhs.compID == null)
            return false;
        return password.equals(rhs.password)    && location.equals(rhs.location)
                && idCard.equals(rhs.idCard)    && compID.equals(rhs.compID)
                && balance.equals(rhs.balance)  && points.equals(rhs.points);
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 97 * hash + Objects.hashCode(this.password);
        hash = 97 * hash + Objects.hashCode(this.location);
        hash = 97 * hash + Objects.hashCode(this.idCard);
        return hash;
    }
    
}
