package be.pxl.backend.models;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.NamedQuery;

import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;
import java.io.Serializable;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */

@Entity
@Table(name = "Temperatures")
public class Temperature implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable = false)
    private float temperature;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(nullable = false)
    private Date date;

    @ManyToOne
    @JsonBackReference
    @JoinColumn(name = "sessionId")
    private Session session;

    public Temperature() {

    }

    public Temperature(float temperature, Date date) {
        this.temperature = temperature;
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

    public float getTemperature() {
        return temperature;
    }

    public Date getDate() {
        return date;
    }

}
