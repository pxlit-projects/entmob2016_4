package be.pxl.backend.models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "Pressures")
public class Pressure implements Serializable {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Column(name = "Pressure")
    private float pressure;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "Date")
    private Date date;

    @ManyToOne
    @JoinColumn(name = "SessionId")
    private Session session;

    public Session getSession() {
        return session;
    }

    public void setSession(Session session) {
        this.session = session;
    }

    public int getId() {
        return id;
    }

    public float getPressure() {
        return pressure;
    }

    public void setPressure(float pressure) {
        this.pressure = pressure;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
