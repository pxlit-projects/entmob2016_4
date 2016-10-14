package be.pxl.backend.models;

import org.hibernate.annotations.NamedQuery;
import javax.persistence.*;
import javax.persistence.Entity;
import javax.persistence.Table;
import java.io.Serializable;
import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@NamedQuery(name = "Session.allSessions", query = "select s from Session")
@Table(name = "Sessions")
public class Session implements Serializable {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @ManyToOne
    @JoinColumn(name = "")
    private User user;

    @Temporal(TemporalType.TIMESTAMP)
    private Date start;

    @Temporal(TemporalType.TIMESTAMP)
    private Date end;

    @OneToMany(mappedBy = "Sessions")
    private List<Temperature> temperatures;

    @OneToMany(mappedBy = "Sessions")
    private List<Pressure> pressures;

    @OneToMany(mappedBy = "Sessions")
    private List<Humidity> humidities;

    @OneToMany(mappedBy = "Sessions")
    private List<AcceleroMeter> acceleroMeters;

    public int getId() {
        return id;
    }

    public Date getStart() {
        return start;
    }

    public void setStart(Date start) {
        this.start = start;
    }

    public Date getEnd() {
        return end;
    }

    public void setEnd(Date end) {
        this.end = end;
    }

    public List<Temperature> getTemperatures() {
        return temperatures;
    }

    public void setTemperatures(List<Temperature> temperatures) {
        this.temperatures = temperatures;
    }

    public List<Pressure> getPressures() {
        return pressures;
    }

    public void setPressures(List<Pressure> pressures) {
        this.pressures = pressures;
    }

    public List<Humidity> getHumidities() {
        return humidities;
    }

    public void setHumidities(List<Humidity> humidities) {
        this.humidities = humidities;
    }

    public List<AcceleroMeter> getAcceleroMeters() {
        return acceleroMeters;
    }

    public void setAcceleroMeters(List<AcceleroMeter> acceleroMeters) {
        this.acceleroMeters = acceleroMeters;
    }
}
