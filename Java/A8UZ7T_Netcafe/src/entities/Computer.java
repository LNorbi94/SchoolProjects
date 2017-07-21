package entities;

import java.util.Objects;

public class Computer {
    
    public String desc;
    public String os;
    public String signIn;
    
    public static String[] fields = { "Azonosító"
            , "Hardver Leírás"
            , "Operációs Rendszer"
            , "Bejelentkezés Időpontja" };
    
    public Computer(String desc, String os, String signIn) {
        this.desc = desc;
        this.os = os;
        this.signIn = signIn;
    }
    
    public Computer() {
        
    }
    
    public Object[] getData(int id) {
        String signed;
        signed = signIn == null ? "(null)" : signIn;
        return new Object[] { id, desc, os, signed };
    }
    
    @Override
    public boolean equals(Object obj) {
       if (!(obj instanceof Computer))
            return false;
        if (obj == this)
            return true;

        Computer rhs = (Computer) obj;
        if (signIn == null && rhs.signIn == null)
            return true;
        return desc.equals(rhs.desc) && os.equals(rhs.os) && signIn.equals(rhs.signIn);
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 97 * hash + Objects.hashCode(this.desc);
        hash = 97 * hash + Objects.hashCode(this.os);
        hash = 97 * hash + Objects.hashCode(this.signIn);
        return hash;
    }
    
}
