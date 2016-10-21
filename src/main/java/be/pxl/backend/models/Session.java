package be.pxl.backend.models;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import org.hibernate.annotations.NamedQuery;
import javax.persistence.*;
import javax.persistence.Entity;
import java.io.Serializable;
import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "Sessions")
public class Session implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    @Temporal(TemporalType.TIMESTAMP)
    private Date start;

    @Temporal(TemporalType.TIMESTAMP)
    private Date end;

    @JsonBackReference
    @ManyToOne
    @JoinColumn(name = "userId")
    private User user;

    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Temperature> temperatures;

    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Pressure> pressures;

    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Humidity> humidities;

    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<AcceleroMeter> acceleroMeters;

    public int getId() {
        return id;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
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
