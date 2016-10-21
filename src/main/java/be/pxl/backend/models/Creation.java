package be.pxl.backend.models;

import javax.persistence.*;
import java.util.Date;

/**
 * Created by Jonas on 21/10/16.
 */
@Entity
@Table(name = "Creations")
public class Creation {

    @Id
    @GeneratedValue
    private int id;

    private int userId;

    private boolean succes;

    @Temporal(TemporalType.TIMESTAMP)
    private Date date;

    private String errorMessage;

    public int getId() {
        return id;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public boolean isSucces() {
        return succes;
    }

    public void setSucces(boolean succes) {
        this.succes = succes;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public String getErrorMessage() {
        return errorMessage;
    }

    public void setErrorMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }
}
