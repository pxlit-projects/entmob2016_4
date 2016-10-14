package be.pxl.backend.models;

import com.fasterxml.jackson.annotation.JsonBackReference;
import org.hibernate.annotations.JoinColumnOrFormula;
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
@NamedQuery(name = "Session.getAllSessions", query = "select s from Session s")
public class Session implements Serializable {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Temporal(TemporalType.TIMESTAMP)
    private Date start;

    @Temporal(TemporalType.TIMESTAMP)
    private Date end;

    @ManyToOne
    @JoinColumn(name = "UserId")
    private User user;

    //@JsonBackReference
    @OneToMany(mappedBy = "session")
    private List<Temperature> temperatures;

    @JsonBackReference
    @OneToMany(mappedBy = "session")
    private List<Pressure> pressures;

    //@JsonBackReference
    @OneToMany(mappedBy = "session")
    private List<Humidity> humidities;

    //@JsonBackReference
    @OneToMany(mappedBy = "session")
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
