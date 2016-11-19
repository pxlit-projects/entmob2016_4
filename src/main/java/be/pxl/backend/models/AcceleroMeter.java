package be.pxl.backend.models;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.NamedQuery;

import javax.persistence.*;
import javax.persistence.Entity;
import java.io.Serializable;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "AcceleroMeters")
public class AcceleroMeter implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable = false)
    private float x;
    @Column(nullable = false)
    private float y;
    @Column(nullable = false)
    private float z;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "Date", nullable = false)
    private Date date;

    @JsonBackReference
    @ManyToOne
    @JoinColumn(name = "SessionId")
    private Session session;

    public AcceleroMeter() {

    }

    public AcceleroMeter(float x, float y, float z, Date date) {
        this.x = x;
        this.y = y;
        this.z = z;
        this.date = date;
    }

    public Session getSession() {
        return session;
    }

    public void setSession(Session session) {
        this.session = session;
    }

    public int getId() {
        return id;
    }

    public float getX() {
        return x;
    }

    public float getY() {
        return y;
    }

    public float getZ() {
        return z;
    }

    public Date getDate() {
        return date;
    }

}
