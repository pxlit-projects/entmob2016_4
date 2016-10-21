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
    private Date created;

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

    public Date getCreated() {
        return created;
    }

    public void setCreated(Date created) {
        this.created = created;
    }

    public String getErrorMessage() {
        return errorMessage;
    }

    public void setErrorMessage(String errorMessage) {
        this.errorMessage = errorMessage;
    }
}
