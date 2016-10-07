package be.pxl.backend.models;

import javax.persistence.*;
import java.util.Date;

/**
 * Created by Jonas on 7/10/16.
 */

@Entity
@Table(name = "Temperatures")
public class Temperature {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Column(name = "Temperature")
    private float temperature;

    @Temporal(TemporalType.TIMESTAMP)
    @Column(name = "Date")
    private Date date;

    public int getId() {
        return id;
    }

    public float getTemperature() {
        return temperature;
    }

    public void setTemperature(float temperature) {
        this.temperature = temperature;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }



}
