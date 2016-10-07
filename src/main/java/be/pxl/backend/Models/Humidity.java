package be.pxl.backend.models;

import javax.persistence.*;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "Humidities")
public class Humidity {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Column(name = "Humidity")
    private float humidity;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "Date")
    private Date date;

    public int getId() {
        return id;
    }

    public float getHumidity() {
        return humidity;
    }

    public void setHumidity(float humidity) {
        this.humidity = humidity;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }
}
