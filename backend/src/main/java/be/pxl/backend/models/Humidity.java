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
@Table(name = "Humidities")
public class Humidity implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    @Column(nullable = false)
    private float humidity;

    @Column(nullable = false)
    @Temporal(TemporalType.TIMESTAMP)
    private Date date;

    @JsonBackReference
    @ManyToOne
    @JoinColumn(name = "SessionId")
    private Session session;

    public Humidity() {

    }

    public Humidity(float humidity, Date date) {
        this.humidity = humidity;
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

    public float getHumidity() {
        return humidity;
    }

    public Date getDate() {
        return date;
    }

}
